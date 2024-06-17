using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TogglePassedValueOnCollision : MonoBehaviour
{
    [Tooltip("Item to be turned when collision occurs.")]
    [SerializeField] private GameObject targetObject;
    [Tooltip("What the target object is set to.")]
    [SerializeField] private bool boolValue;

    private void Awake()
    {
        Collider collider = GetComponent<Collider>();
        if (collider == null || !collider.isTrigger) 
        {
            Debug.LogWarning($"{targetObject.name} requires a trigger.");
        }
        if (targetObject == null) 
        {
            Debug.LogWarning("Target object not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetObject != null) 
        {
            targetObject.SetActive(boolValue);
        }
    }
}
