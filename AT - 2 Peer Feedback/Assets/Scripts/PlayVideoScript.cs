using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class PlayVideoScript : MonoBehaviour
{

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private UnityEvent triggerEventAfter;
    [SerializeField] private UnityEvent triggerEventNow;

    private void OnTriggerEnter(Collider other)
    {
        if (videoPlayer != null)
        {
            triggerEventNow.Invoke();
            videoPlayer.Play();
            StartCoroutine(delayAndTrigger(34.0f));
        }
    }

    private IEnumerator delayAndTrigger (float seconds)
    {
        yield return new WaitForSeconds (seconds);
        triggerEventAfter.Invoke();
    }
}
