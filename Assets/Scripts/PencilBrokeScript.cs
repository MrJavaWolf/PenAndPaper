using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EZCameraShake;
using UnityEngine;

public class PencilBrokeScript : Singleton<PencilBrokeScript>
{

    public Vector3 CameraOffsetTipView = new Vector3(2, 3, -5);

    public Vector3 CameraOffsetPencilView = new Vector3(2, 3, -5);

    public Transform Pen;
    public Transform PenTip;
    public Transform[] PenParts;
    public AnimationCurve PartsFlyCurve;
    public AudioClip PenBreakAudio;
    public AudioClip PenTipBreakAudio;
    public ParticleSystem PenTipBreakEffect;

    public AudioSource AudioPlayer;
    public void Play(Action onDone)
    {
        StartCoroutine(PlaySequence(onDone));
    }

    private IEnumerator PlaySequence(Action onDone)
    {
        PlayCamera.Instance.transform.position = PenTip.position + CameraOffsetTipView;
        PlayCamera.Instance.transform.LookAt(PenTip.position);
        PenTipBreakEffect.transform.position = PenTip.position - PenTipBreakEffect.transform.forward * 0.3f;
        PenTipBreakEffect.transform.LookAt(PenTipBreakEffect.transform.position - PenTipBreakEffect.transform.forward);

        Pen.transform.position = new Vector3(Pen.transform.position.x, Pen.transform.position.y, -3f);
        Pen.DOMove(Pen.transform.position + Pen.transform.forward * 0.3f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        PenTipBreakEffect.Play();

        AudioPlayer.PlayOneShot(PenTipBreakAudio);
        PenTip.DOMove(PenTip.position + Vector3.up * 0.2f - PenTip.transform.forward * 0.2f, 0.1f)
            .OnComplete(() =>
            {
                PenTip.DOMove(PenTip.position + Vector3.up * 0.3f, 7);
            });

        PenTip.DORotateQuaternion(PenTip.rotation * Quaternion.Euler(new Vector3(-90, 0, 0)), 0.1f)
            .OnComplete(() =>
            {
                PenTip.DORotateQuaternion(PenTip.rotation * Quaternion.Euler(new Vector3(-360, 50, -50)), 7);
            });

        yield return new WaitForSeconds(0.6f);

        PlayCamera.Instance.transform.position = PenTip.position + CameraOffsetPencilView;
        PlayCamera.Instance.transform.LookAt(PenTip.position);

        yield return new WaitForSeconds(0.6f);
        AudioPlayer.PlayOneShot(PenBreakAudio);

        for (int i = 0; i < PenParts.Length; i++)
        {
            var penPart = PenParts[i];

            Vector3 sideDirections = UnityEngine.Random.insideUnitCircle.normalized;
            Vector3 forwardDirection = penPart.forward;
            var randomRotation = UnityEngine.Random.insideUnitSphere;
            var direction = Vector3.Lerp(sideDirections, forwardDirection, i / (PenParts.Length - 1));
            penPart.DORotate(randomRotation * 30, 0.1f)
                .OnComplete(() =>
                {
                    penPart.DORotate(randomRotation * 90, 7f);
                });
            penPart.DOMove(penPart.position +
                    penPart.up * direction.y +
                    penPart.forward * direction.z +
                    penPart.right * direction.x, 0.1f)
                .OnComplete(() =>
                {
                    penPart.DOMove(penPart.position +
                        penPart.up * direction.y +
                        penPart.forward * direction.z +
                        penPart.right * direction.x, 7f);
                });
        }

        yield return new WaitForSeconds(5);
        onDone();
    }
}