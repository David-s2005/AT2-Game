using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightScript : MonoBehaviour
{
    [Tooltip("Flashlight Light Source")]
    [SerializeField] private GameObject LightSource;
    [Tooltip("Base value for flashlight Capacity, default is 100.")]
    [SerializeField] private int FlashlightCapacity = 100;
    [SerializeField] private int FlashlightRemaining;
    [Tooltip("Value for how quickly the flashlight regains capacity")]
    [SerializeField] private int FlashlightRechargeRate = 1;
    [Tooltip("Value for how quickly the flashlight loses capacity")]
    [SerializeField] private int FlashlightDegradeRate = 2;
    [Tooltip("Image that represent current capcity of flashlight.")]
    [SerializeField] private Image ChargeBar;
    [Tooltip("List of Audio. First one is the flashlight turning on, the other the flashlight powering down.")]
    [SerializeField] private AudioClip[] FlashlightSounds;

    private AudioSource FlashlightAudioSource;

    void Awake()
    {
        if (FlashlightRemaining == 0)
        {
            FlashlightRemaining = FlashlightCapacity;
        }

        if (TryGetComponent(out FlashlightAudioSource) == false)
        {
            Debug.Log("Failed to find audio source compondent!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Will toggle the light source off and on when the user presses F.
        if (Input.GetKeyDown(KeyCode.F) && FlashlightRemaining > 0)
        {
            LightSource.SetActive(!LightSource.activeSelf);
            FlashlightAudioSource.PlayOneShot(FlashlightSounds[0]);
        }
    }

    private void FixedUpdate()
    {
        if (LightSource.activeSelf)
        {
            if (FlashlightRemaining > 0)
            {
                FlashlightRemaining -= FlashlightDegradeRate;
                ChargeBar.fillAmount = FlashlightRemaining / 1500f;
            }

            if (FlashlightRemaining <= 0)
            {
                LightSource.SetActive(false);
                FlashlightRemaining = 0;
                FlashlightAudioSource.PlayOneShot(FlashlightSounds[1]);
            }
        }
        else
        {
            if (FlashlightRemaining < FlashlightCapacity)
            {
                FlashlightRemaining += FlashlightRechargeRate;
                ChargeBar.fillAmount = FlashlightRemaining / 1500f;
            }
        }
    }

    public void addCharge(int _charge) 
    {
        if ((_charge + FlashlightRemaining) < FlashlightCapacity)
        {
            FlashlightRemaining += _charge;
        }
        else 
        {
            FlashlightRemaining = FlashlightCapacity;
        }
    }
}
