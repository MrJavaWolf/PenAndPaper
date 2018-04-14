using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineController : ShapeController
{
    public List<Transform> positions = new List<Transform>();
    public float Closeness = .2f;

    protected override bool IsShapeFilled()
    {
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

        var avg = distances.Average();
        Debug.Log(avg);

        if (avg < Closeness)
            return true;

        return false;
    }
}
