using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public Transform lookPoint;

    public void MountCamera(Camera cam)
    {
        cam.transform.position = transform.position;
        cam.transform.SetParent(transform);
        cam.transform.LookAt(lookPoint);
    }
}
