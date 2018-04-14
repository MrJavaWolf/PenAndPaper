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

    public void MountCamera(Transform cam)
    {
        cam.parent = null;
        float value = 0;
        DOTween.To(() => value, (v) =>
         {
             value = v;
             var direction = (transform.position - startPosition).normalized;
             var totalDistance = (startPosition - transform.position).sqrMagnitude;
             var wantedPosition = startPosition + direction * totalDistance * value;
             cam.position = wantedPosition;

         }, 1, 2)
         .OnComplete(() =>
         {
             cam.transform.LookAt(lookPoint);
             cam.transform.SetParent(transform);
         })
         .SetEase(Ease.InOutCubic);




        timer = Duration;
        Attached = true;
        cam.transform.LookAt(lookPoint);

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
