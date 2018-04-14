using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilBrokeScript : Singleton<PencilBrokeScript>
{

    public Vector3 CameraOffset = new Vector3(2, 3, -5);

    public void Play(Action onDone)
    {
        StartCoroutine(PlaySequence(onDone));
    }

    private IEnumerator PlaySequence(Action onDone)
    {
        var cameraPosition = PenController.Instance.GetTipPosition() + CameraOffset;
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.LookAt(PenController.Instance.GetTipPosition());
        yield return new WaitForSeconds(4);
        onDone();
    }
}
