using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    public HandObject LeftHand;
    public HandObject RightHand;
    public Transform Paper;

    /// <summary>
    /// How far the hands are allowed to be vertially compared to eachother, before the paper rips.
    /// </summary>
    public float PaperRipDistance = 3;

    public event EventHandler OnPaperRip;

    // Update is called once per frame
    void Update()
    {
        var input = InputController.Instance.GetXBoxInput();
        UpdateHand(LeftHand, input.LeftStick);
        UpdateHand(RightHand, input.RightStick);
        if (WillPaperRip())
        {
            if (OnPaperRip != null) OnPaperRip(this, EventArgs.Empty);
        }
        else
        {
            UpdatePaperRotation();
        }
    }

    private bool WillPaperRip()
    {
        return Math.Abs(LeftHand.Hand.position.y - RightHand.Hand.position.y) > PaperRipDistance;
    }

    private void UpdatePaperRotation()
    {
        var direction = LeftHand.Hand.position - RightHand.Hand.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        rotation *= Quaternion.Euler(0, 90, 0);
        Paper.transform.rotation = rotation;

    }

    private void UpdateHand(HandObject hand, Vector2 userInput)
    {
        var handMovement =
            //userInput.x * hand.Hand.right * hand.UserInputVerticalSpeed * Time.deltaTime +
            userInput.y * hand.Hand.up * hand.UserInputVerticalSpeed * Time.deltaTime +
            hand.Hand.up * hand.BaseVerticalSpeed * Time.deltaTime +
            hand.Hand.up * UnityEngine.Random.Range(-0.9f, 1) * hand.VerticalShakiness * Time.deltaTime;
        hand.Hand.position += handMovement;
    }

    [Serializable]
    public class HandObject
    {
        public Transform Hand;
        public float UserInputVerticalSpeed;
        public float BaseVerticalSpeed;
        public float VerticalShakiness;
    }
}
