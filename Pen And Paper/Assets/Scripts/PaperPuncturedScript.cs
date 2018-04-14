using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuncturedScript : Singleton<PaperPuncturedScript>
{
    public Transform RightHand;
    public Transform LeftHand;
    public Transform Pen;

    public Vector3 CameraOffset = new Vector3(0, 5, 8);
    public AnimationCurve PenMovement;

    public void Play(Action onDone)
    {
        var lineControllers = FindObjectsOfType<LineController>();

        foreach (var lineController in lineControllers)
        {
            Destroy(lineController.gameObject);
        }
        StartCoroutine(PlaySequence(onDone));
    }

    private IEnumerator PlaySequence(Action onDone)
    {
        var paperCentralPosition = (LeftHand.position + RightHand.position) / 2;
        var cameraPosition = paperCentralPosition + CameraOffset;
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.LookAt(paperCentralPosition);
        Pen.position += -Pen.forward * 0.5f;
        yield return new WaitForSeconds(1);

        Pen.DOMove(Pen.position + Pen.forward * 1.5f, 3).SetEase(PenMovement);
        yield return new WaitForSeconds(4);
        onDone();
    }
}
