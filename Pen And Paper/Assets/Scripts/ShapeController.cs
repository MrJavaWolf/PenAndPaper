using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public float DrawDistance = 1;
    public float BreakDistance = .5f;

    private List<DrawData> recordedPositions = new List<DrawData>();

    private bool isDrawingInside;

    private void Update()
    {
        //Draw trail
    }

    private void FixedUpdate()
    {
        if (GetPenDistance() < DrawDistance)
        {
            recordedPositions.Add(new DrawData(
                PenController.Instance.transform.position,
                isDrawingInside));
        }

        if (GetPenDistance() < BreakDistance)
        {
            //End Game
        }
    }

    private float GetPenDistance()
    {
        var p = PenController.Instance.GetTipPosition();
        return Vector3.Distance(p, new Vector3(p.x, p.y, transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        isDrawingInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isDrawingInside = false;
    }
}

public struct DrawData
{
    Vector2 Pos;
    bool Inside;

    public DrawData(Vector2 pos, bool inside)
    {
        Pos = pos;
        Inside = inside;
    }
}