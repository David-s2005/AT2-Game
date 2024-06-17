using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SprintScript : MonoBehaviour
{
    //StaminaBar.fillAmount = (float) currentStamina / StaminaMax;

    [SerializeField] private PlayerController playerController;
    [Tooltip("Speed that is applied to the movement speed when the sprint key is pressed.")]
    [SerializeField] private float movementAddition;
    [Tooltip("Maximum stamina the player has. Influences how long they can sprint for.")]
    [SerializeField] private int StaminaMax = 1000;
    [Tooltip("This influences how quickly the player loses stamina.")]
    [SerializeField] private int StaminaLossRate = 2;
    [Tooltip("Defines how much stamina the player can regain.")]
    [SerializeField] private int StaminaRegainRate = 3;
    [Tooltip("Current amount of stamina the player has.")]
    [SerializeField] private int currentStamina = 1000;
    [Tooltip("Image that this script will fill according to the current stamina.")]
    [SerializeField] private Image StaminaBar;

    private bool isRegenerating = false;
    private bool outOfStamina = false;

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentStamina > 50)
            {
                playerController.setCurrentMovementSpeed(movementAddition);
                currentStamina -= StaminaLossRate;
                outOfStamina = false;
            }
            else
            {
                playerController.resetspeed();
                currentStamina = 0;
                if (!isRegenerating && !outOfStamina) 
                {
                    outOfStamina = true;
                    StartCoroutine(delayRegeneration(4.0f));
                }
            };
        }
        else
        {
            if (currentStamina < StaminaMax && !isRegenerating) currentStamina += StaminaRegainRate;
            playerController.resetspeed();
        }

        StaminaBar.fillAmount = (float)currentStamina / StaminaMax;
    }

    private IEnumerator delayRegeneration(float delay)
    {
        isRegenerating = true;
        yield return new WaitForSeconds(delay);
        isRegenerating = false;
    }
}
