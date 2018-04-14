using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public float DrawDistance = 1;
    public float BreakDistance = .5f;
    public GameObject Line;
    public float DistanceBetweenLinePoints = .2f;
    public float LineThickness = .3f;

    protected List<DrawData> recordedPositions = new List<DrawData>();
    protected List<GameObject> spawnedObjects = new List<GameObject>();
    protected int LastIndex;

    protected bool isDrawingInside;

    protected virtual bool IsShapeFilled() { return false; }

    private void Update()
    {
        //Add new points
        if (GetPenDistance() < DrawDistance && ShapeManager.Instance.PenIsOnPaper)
        {
            //If its the first
            if (recordedPositions.Count == 0)
            {
                recordedPositions.Add(new DrawData(
                    PenController.Instance.transform.position,
                    isDrawingInside));
            }

            //if its not too close
            //if (Vector2.Distance(PenController.Instance.GetTipPosition(),
            //    recordedPositions.LastOrDefault().Pos) > DistanceBetweenLinePoints)
            var tippos = new Vector2(PenController.Instance.GetTipPosition().x, PenController.Instance.GetTipPosition().y);

            if (tippos != recordedPositions.LastOrDefault().Pos)
            {
                recordedPositions.Add(new DrawData(
                   PenController.Instance.transform.position,
                   isDrawingInside));
            }
        }

        //Instantiate new points
        if (recordedPositions.Count > 0 && LastIndex + 1 < recordedPositions.Count)
        {
            for (int i = LastIndex; i < recordedPositions.Count; i++)
            {
                var pos = recordedPositions[i].Pos;

                var o = Instantiate(Line, new Vector3(pos.x, pos.y, -0.06f), Quaternion.identity);

                if (recordedPositions[i].Inside)
                    o.GetComponent<SpriteRenderer>().color = Color.green;

                else
                    o.GetComponent<SpriteRenderer>().color = Color.red;

                var scale = (1 - (GetPenDistance() / DrawDistance)) * LineThickness;
                o.transform.localScale = new Vector3(scale, scale);
            }

            LastIndex = recordedPositions.Count - 1;
        }

        //Check for shape filled
        if (IsShapeFilled())
        {
            ShapeManager.Instance.GetNextShape();
        }

        //Check for game over
        if (GetPenDistance() < BreakDistance)
        {
            //Break the paper
        }
    }

    protected float GetPenDistance()
    {
        var p = PenController.Instance.GetTipPosition();
        return Vector3.Distance(p, new Vector3(p.x, p.y, transform.position.z));
    }

    public void ClearLine()
    {
        foreach (var item in spawnedObjects)
        {
            Destroy(item);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        isDrawingInside = true;
    }

    protected void OnTriggerExit(Collider other)
    {
        isDrawingInside = false;
    }
}

public struct DrawData
{
    public Vector2 Pos;
    public bool Inside;

    public DrawData(Vector2 pos, bool inside)
    {
        Pos = pos;
        Inside = inside;
    }
}