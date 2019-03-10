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
    public ParticleSystem WinEffect;
    public Transform GoodJobText;

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
        WinEffect.transform.position = paperCentralPosition + Vector3.forward;
        WinEffect.Play();
        PlayCamera.Instance.transform.DOMove(cameraPosition, 1).SetEase(Ease.OutCubic);
        PlayCamera.Instance.transform.DORotate(cameraRotation.eulerAngles, 1);
        yield return new WaitForSeconds(0.95f);

        GoodJobText.localScale = Vector3.one * 0.001f;
        GoodJobText.position = paperCentralPosition + Vector3.up * 2.25f;
        GoodJobText.gameObject.SetActive(true);
        GoodJobText.transform.DOScale(1, 0.5f)
            .SetEase(Ease.OutBack);

        WinCameraParent.position = paperCentralPosition + Vector3.down * 2;
        PlayCamera.Instance.transform.position = cameraPosition;
        PlayCamera.Instance.transform.LookAt(paperCentralPosition);
        PlayCamera.Instance.transform.parent = WinCameraParent;

        WinCameraParent.DORotateQuaternion(WinCameraParent.rotation * Quaternion.Euler(new Vector3(0, 45, 0)), 5)
            .SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(5);
        GoodJobText.DOScale(0.01f, 1)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                GoodJobText.gameObject.SetActive(false);
            });

        WinEffect.Stop();
        PlaySceneController.Instance.EnablePlayScripts();
        onDone();
    }
}
