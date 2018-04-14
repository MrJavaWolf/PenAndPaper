using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public Transform lookPoint;
    public float Duration = 5;

    private float timer;
    private bool Attached;
    private Sequence sequence;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Sequence currentDotSequence;
    private void OnDisable()
    {
        if (currentDotSequence != null)
        {
            currentDotSequence.Kill();
        }
    }

    public void MountCamera(Transform cam)
    {
        currentDotSequence = DOTween.Sequence();
        cam.parent = null;
        float value = 0;
        startPosition = cam.position;
        startRotation = cam.rotation;

        currentDotSequence.Append(DOTween.To(() => value, (v) =>
         {
             value = v;
             var direction = (transform.position - startPosition).normalized;
             var totalDistance = (startPosition - transform.position).magnitude;
             var wantedPosition = startPosition + direction * (totalDistance * value);
             cam.position = wantedPosition;
             cam.rotation = Quaternion.Lerp(startRotation, Quaternion.LookRotation(lookPoint.position - transform.position, transform.up), value);

         }, 1, 2)
         .OnComplete(() =>
         {
             cam.transform.LookAt(lookPoint);
             cam.transform.SetParent(transform);
         })
         .SetEase(Ease.InOutCubic));

        timer = Duration;
        Attached = true;
    }


    private void Update()
    {
        if (timer < 0)
        {
            CameraManager.Instance.NextCameraAngle();
            timer = Duration;
            Attached = false;
        }
        else if (Attached)
            timer -= Time.deltaTime;
    }
}
