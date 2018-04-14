using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : Singleton<PenController>
{
    public GameObject Tip;
    public float MovementSpeed = 2;

    public Vector3 GetTipPosition()
    {
        return Tip.transform.position;
    }

    public void Update()
    {
        var input = InputController.Instance.GetPs4Input();
        var movement = input.LeftStick.x * transform.forward * MovementSpeed * Time.deltaTime +
            input.LeftStick.y * transform.up * MovementSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
