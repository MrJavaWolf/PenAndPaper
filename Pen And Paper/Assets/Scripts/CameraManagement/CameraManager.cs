using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private List<CameraPoint> CamPoints = new List<CameraPoint>();

    private int lastIndex;

    private void Start()
    {
        foreach (var camPoint in FindObjectsOfType<CameraPoint>())
        {
            CamPoints.Add(camPoint);
        }

        lastIndex = Random.Range(0, CamPoints.Count - 1);
        CamPoints[lastIndex].MountCamera(PlayCamera.Instance.transform);
    }

    public void GoToNextCameraAngle()
    {
        if (CamPoints.Count < 1)
        {
            CamPoints[Random.Range(0, CamPoints.Count - 1)].MountCamera(PlayCamera.Instance.transform);
            return;
        }

        int nextIndex;

        do
            nextIndex = Random.Range(0, CamPoints.Count);
        while (nextIndex == lastIndex);

        lastIndex = nextIndex;
        CamPoints[nextIndex].MountCamera(PlayCamera.Instance.transform);
    }
}
