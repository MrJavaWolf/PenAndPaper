using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    public float MovementSpeed = 2;


    // Update is called once per frame
    void Update()
    {
        var input = InputController.Instance.GetXBoxInput();
        var movement = input.LeftStick.x * transform.right * MovementSpeed * Time.deltaTime +
            input.LeftStick.y * transform.up * MovementSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
