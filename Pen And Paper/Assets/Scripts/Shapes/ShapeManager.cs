using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : Singleton<ShapeManager>
{
    public event Action PaperPunctured;
    public event Action GameEnded;
    public event Action NewShape;

    public List<GameObject> Shapes = new List<GameObject>();
    private int currShapeIndex;
    public ShapeController currShape { get; set; }

    public bool PenIsOnPaper { get; set; }

    private void Start()
    {
        currShapeIndex = 0;
        currShape = Instantiate(Shapes[currShapeIndex], transform, true).GetComponent<ShapeController>();
    }

    public void GetNextShape()
    {
        if ((currShapeIndex + 1) < Shapes.Count)
        {
            if (NewShape != null)
                NewShape.Invoke();

            currShapeIndex++;
            Destroy(currShape.gameObject);
            currShape = Instantiate(Shapes[currShapeIndex], transform, true).GetComponent<ShapeController>();
            currShape.transform.localPosition = Vector2.zero;
            currShape.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        else
        {
            if (GameEnded != null) GameEnded();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PenIsOnPaper = true;
    }

    private void OnTriggerExit(Collider other)
    {
        PenIsOnPaper = false;
    }

    public void PuncturePaper()
    {
        if (PaperPunctured != null) PaperPunctured();
    }
}
