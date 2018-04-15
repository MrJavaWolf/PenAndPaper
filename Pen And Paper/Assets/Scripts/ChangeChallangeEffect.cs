using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChallangeEffect : Singleton<ChangeChallangeEffect>
{
    public Transform RightHand;
    public Transform LeftHand;
    public Transform WinCameraParent;


    public Vector3 CameraOffset = new Vector3(1, 5, 8);

    public void Play(Action onDone)
    {
        StartCoroutine(PlaySequence(onDone));
    }

    public IEnumerator PlaySequence(Action onDone)
    {
        PlaySceneController.Instance.DisablePlayScripts();

        PlayCamera.Instance.transform.parent = null;
        var paperCentralPosition = (LeftHand.position + RightHand.position) / 2;
        var cameraPosition = paperCentralPosition + CameraOffset;
        var cameraRotation = Quaternion.LookRotation((paperCentralPosition - cameraPosition).normalized, Vector3.up);
        PlayCamera.Instance.transform.DOMove(cameraPosition, 1).SetEase(Ease.OutCubic);
        PlayCamera.Instance.transform.DORotate(cameraRotation.eulerAngles, 1);
        yield return new WaitForSeconds(0.95f);


        WinCameraParent.position = paperCentralPosition + Vector3.down * 2;
        PlayCamera.Instance.transform.position = cameraPosition;
        PlayCamera.Instance.transform.LookAt(paperCentralPosition);
        PlayCamera.Instance.transform.parent = WinCameraParent;

        WinCameraParent.DORotateQuaternion(WinCameraParent.rotation * Quaternion.Euler(new Vector3(0, 45, 0)), 5)
            .SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(5);
        PlaySceneController.Instance.EnablePlayScripts();
        onDone();
    }
}
