using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public Transform lookPoint;
    public float Duration = 5;

    public bool HasTween;

    private float timer;
    private bool Attached;
    private Sequence sequence;

    public void MountCamera(Camera cam)
    {
        if (HasTween)
        {
            sequence = DOTween.Sequence();

            foreach (Transform t in transform)
            {
                if (t.name.Contains("tween"))
                    sequence.Append(t.DOMove(t.position, 1));
            }
        }

        cam.transform.position = transform.position;
        cam.transform.SetParent(transform);
        cam.transform.LookAt(lookPoint);

        timer = Duration;
        Attached = true;
    }

    private void Update()
    {
        if (HasTween)
        {
            Camera.main.transform.LookAt(lookPoint);
        }

        else if (timer < 0)
        {
            CameraManager.Instance.NextCameraAngle();
            timer = Duration;
            Attached = false;
        }
        else if (Attached)
            timer -= Time.deltaTime;
    }
}
