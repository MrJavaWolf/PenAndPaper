using DG.Tweening;
using EZCameraShake;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilBrokeScript : Singleton<PencilBrokeScript>
{

    public Vector3 CameraOffsetTipView = new Vector3(2, 3, -5);

    public Vector3 CameraOffsetPencilView = new Vector3(2, 3, -5);

    public Transform PenTip;
    public Transform[] PenParts;
    public AnimationCurve PartsFlyCurve;

    public void Play(Action onDone)
    {
        StartCoroutine(PlaySequence(onDone));
    }

    private IEnumerator PlaySequence(Action onDone)
    {
        PlayCamera.Instance.transform.position = PenTip.position + CameraOffsetTipView;
        PlayCamera.Instance.transform.LookAt(PenTip.position);

       // CameraShaker.Instance.ShakeOnce(1, 5, 2, 0.1f);
        yield return new WaitForSeconds(2.5f);

        PenTip.DOMove(PenTip.position + PenTip.up * 0.1f, 0.05f);
        PenTip.DORotateQuaternion(PenTip.rotation * Quaternion.Euler(new Vector3(-125, 0, 0)), 0.05f);

        yield return new WaitForSeconds(1.5f);

        PlayCamera.Instance.transform.position = PenTip.position + CameraOffsetPencilView;
        PlayCamera.Instance.transform.LookAt(PenTip.position);

        yield return new WaitForSeconds(1);
        foreach (var penPart in PenParts)
        {
            penPart.DOMove(penPart.position +
                penPart.up * UnityEngine.Random.Range(-0.3f, 0.3f) +
                penPart.forward * UnityEngine.Random.Range(-0.3f, 0.3f) +
                penPart.right * UnityEngine.Random.Range(-0.3f, 0.3f), 0.1f);
        }

        yield return new WaitForSeconds(4);
        onDone();
    }
}
