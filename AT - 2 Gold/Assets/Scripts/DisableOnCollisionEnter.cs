using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCollisionEnter : MonoBehaviour
{
    [Tooltip("Object that is toggled by collider")]
    [SerializeField] private GameObject targetObject;

    private void Awake()
    {
        Collider collider = GetComponent<Collider>();
        if (collider == null || !collider.isTrigger)
        {
            Debug.LogWarning($"{targetObject.name} requires a Collider with a trigger.");
        }
        if (targetObject)
        {
            Debug.LogWarning($"Object hasnt been assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetObject != null)
        {
            StartCoroutine(disableObject(0.3f));
        }
    }

    private IEnumerator disableObject(float delay) 
    {
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(false);
    }
}

