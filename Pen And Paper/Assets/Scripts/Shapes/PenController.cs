using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : Singleton<PenController>
{
    public GameObject Tip;

    public Vector3 GetTipPosition()
    {
        return Tip.transform.position;
    }
}
