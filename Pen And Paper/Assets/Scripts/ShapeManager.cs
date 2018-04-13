﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : Singleton<ShapeManager>
{
    public List<GameObject> Shapes = new List<GameObject>();
    private int currShapeIndex;
    private GameObject currShape;

    private void Start()
    {
        currShapeIndex = 0;
        currShape = Instantiate(Shapes[currShapeIndex], transform, true);
    }

    public void GetNextShape()
    {
        if ((currShapeIndex + 1) < Shapes.Count)
        {
            currShapeIndex++;
            Destroy(currShape);
            currShape = Instantiate(Shapes[currShapeIndex], transform, true);
        }
        else
        {
            //Game is completed!!
        }
    }
}
