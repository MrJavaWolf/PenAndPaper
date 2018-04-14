using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    public float MovementSpeed = 2;
    public HandObject LeftHand;
    public HandObject RightHand;
    public Transform Paper;



    // Update is called once per frame
    void Update()
    {
        var input = InputController.Instance.GetXBoxInput();
        //var leftHandMovement = input.LeftStick.x * LeftHand.Hand.right * MovementSpeed * Time.deltaTime +
        //    input.LeftStick.y * LeftHand.Hand.up * MovementSpeed * Time.deltaTime;

        var movement = input.LeftStick.x * transform.right * MovementSpeed * Time.deltaTime +
            input.LeftStick.y * transform.up * MovementSpeed * Time.deltaTime;
        transform.position += movement;


    }

    private void UpdateHand(HandObject hand)
    {

    }


    public struct HandObject
    {
        public Transform Hand;
        public float UserInputVerticalSpeed;
        public float BaseVerticalSpeed;
        public float VerticalShakiness;
    }
}
