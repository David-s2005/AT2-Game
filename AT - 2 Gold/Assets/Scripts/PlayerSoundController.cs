using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [Tooltip("Target audio source compondent")]
    [SerializeField] private AudioClip audioClip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource PlayerAsrc = other.GetComponent<AudioSource>();

            if (PlayerAsrc != null) 
            {
                PlayerAsrc.clip = audioClip;
                PlayerAsrc.loop = true;
                PlayerAsrc.Play();
            }
        }
    }
}
