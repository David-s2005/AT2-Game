using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakingAudio : MonoBehaviour
{
    [SerializeField] private AudioClip enterSound;
    [SerializeField] private AudioClip exitSound;
    [SerializeField] private AudioSource aSrc;

    private bool hasEntered;
    private bool hasExited;

    private void OnTriggerEnter(Collider other)
    {
        if (enterSound != null && !hasEntered) 
        {
            aSrc.PlayOneShot(enterSound);
            hasEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enterSound != null && !hasExited)
        {
            aSrc.PlayOneShot(exitSound);
            hasExited = true;
        }
    }
}
