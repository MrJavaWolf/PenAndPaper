using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public InAudioEvent AudioEvent;

    private void OnTriggerStay(Collider other)
    {
        if (PlaySceneController.SoundPlay)
            InAudio.PostEvent(gameObject, AudioEvent);
    }
}
