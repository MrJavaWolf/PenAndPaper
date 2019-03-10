using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineController : ShapeController
{
    public List<Transform> positions = new List<Transform>();
    public float Closeness = .2f;

    private void Start()
    {
        foreach (Transform t in transform)
        {
            if (t.name.Contains("Point"))
                positions.Add(t);
        }
    }

    protected override bool IsShapeFilled()
    {
        if (recordedPositions.Count == 0)
            return false;

        List<float> distances = new List<float>();

        foreach (var item in positions)
        {
            float closest = 100;
            foreach (var data in recordedPositions)
            {
                var dist = Vector2.Distance(item.position, data.Pos);
                if (dist < closest)
                    closest = dist;
            }

            distances.Add(closest);
        }

        foreach (var item in distances)
        {
            if (item > Closeness)
                return false;
        }

        return true;
    }
}
