using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public InAudioEvent AudioEvent;

    private void OnTriggerStay(Collider other)
    {
        InAudio.PostEvent(gameObject, AudioEvent);
    }
}
