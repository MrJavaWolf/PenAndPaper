using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : Singleton<PenController>
{
    public GameObject Tip;
    public float MovementSpeed = 2;
    public float BaseSpeed = 0.3f;
    public float HorizontalShakiness = 1;
    public float VerticalShakiness = 1;

    public Vector3 GetTipPosition()
    {
        return Tip.transform.position;
    }

    public void Update()
    {
        var input = InputController.Instance.GetXBoxInput();
        var movement =
            transform.forward * input.RightStick.y * MovementSpeed * Time.deltaTime +
            transform.right * input.LeftStick.x * MovementSpeed * Time.deltaTime +
            transform.up * input.LeftStick.y * MovementSpeed * Time.deltaTime +
            transform.forward * BaseSpeed * Time.deltaTime +
            transform.forward * Random.Range(-0.9f, 1) * HorizontalShakiness * Time.deltaTime +
            transform.up * Random.Range(-0.9f, 1) * VerticalShakiness * Time.deltaTime;

        transform.position += movement;
    }
}
