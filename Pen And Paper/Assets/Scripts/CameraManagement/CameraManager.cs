using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private List<CameraPoint> CamPoints = new List<CameraPoint>();

    private void Start()
    {
        foreach (var camPoint in FindObjectsOfType<CameraPoint>())
        {
            CamPoints.Add(camPoint);
        }

        CamPoints[Random.Range(0, CamPoints.Count - 1)].MountCamera(Camera.main);
    }
}
