using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryScript : MonoBehaviour
{
    [SerializeField] private int rechargeAmount;
    [SerializeField] private UnityEvent interactionEvents;

    private void OnTriggerEnter(Collider other)
    {
        interactionEvents.Invoke();

        transform.parent.gameObject.SetActive(false);
    }
}
