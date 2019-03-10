using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProxy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShapeManager.Instance.currShape.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ShapeManager.Instance.currShape.OnTriggerExit(other);
    }
}
