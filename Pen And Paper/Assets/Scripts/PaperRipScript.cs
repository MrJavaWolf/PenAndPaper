using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperRipScript : Singleton<PaperRipScript>
{
    public Transform RightHand;
    public Transform RightPaper;

    public Transform LeftHand;
    public Transform LeftPaper;

    public Vector3 CameraOffset = new Vector3(0, 5, 8);

    public AnimationCurve PaperMovement;


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
        LeftPaper.parent = LeftHand;
        RightPaper.parent = RightHand;

        PlayCamera.Instance.transform.position = cameraPosition;
        PlayCamera.Instance.transform.LookAt(paperCentralPosition);
        yield return new WaitForSeconds(1);
        LeftHand.DOMove(LeftHand.position - LeftHand.right * 2, 1).SetEase(PaperMovement);
        RightHand.DOMove(RightHand.position + RightHand.right * 2, 1).SetEase(PaperMovement);
        yield return new WaitForSeconds(4);
        onDone();
    }
}
