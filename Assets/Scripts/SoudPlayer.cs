using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudPlayer : MonoBehaviour
{
    public InAudioEvent InGameManPen;
    public InAudioEvent InGameManPaper;
    public InAudioEvent InGameWomanPen;
    public InAudioEvent InGameWomanPaper;

    // Update is called once per frame
    void Update()
    {
        if (!PlaySceneController.SoundPlay)
            return;

        if (CharacterManager.Instance.characterPlayerA == 0)
        {
            InAudio.PostEvent(gameObject, InGameManPen);
        }
        else
        {
            InAudio.PostEvent(gameObject, InGameWomanPen);
        }

        if (CharacterManager.Instance.characterPlayerB == 0)
        {
            InAudio.PostEvent(gameObject, InGameManPaper);
        }
        else
        {
            InAudio.PostEvent(gameObject, InGameWomanPaper);
        }
    }
}
