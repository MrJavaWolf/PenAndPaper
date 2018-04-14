using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public Transform lookPoint;
    public float Duration = 5;
    private float timer;
    private bool Attached;

    public void MountCamera(Camera cam)
    {
        cam.transform.position = transform.position;
        cam.transform.SetParent(transform);
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
