using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : Singleton<PaperController>
{
    public HandObject LeftHand;
    public HandObject RightHand;
    public Transform Paper;

    /// <summary>
    /// How far the hands are allowed to be vertially compared to eachother, before the paper rips.
    /// </summary>
    public float PaperRipDistance = 3;

    public float PenBreakingLimit = 4;

    /// <summary>
    /// Higher = Easiere to break
    /// </summary>
    public float PenBreakingMultiplier = 30;


    public event EventHandler OnPaperRip;
    public event EventHandler OnPenBreaking;


    // Update is called once per frame
    void Update()
    {
        var input = InputController.Instance.GetPs4Input();
        var prevLeftHandPostition = LeftHand.Hand.position;
        var prevRightHandPostition = RightHand.Hand.position;
        UpdateHand(LeftHand, input.LeftStick);
        UpdateHand(RightHand, input.RightStick);
        var distanceMoved = 0f;
        if (Time.deltaTime != 0)
        {
            distanceMoved = (Vector3.Distance(prevLeftHandPostition, LeftHand.Hand.position) +
             Vector3.Distance(prevRightHandPostition, RightHand.Hand.position) +
             (PenController.Instance.DistanceMoved * PenBreakingMultiplier)) /
              Mathf.Max(Time.deltaTime, 0.001f);
            //Debug.Log("distanceMoved: " + distanceMoved);
        }

        if (WillPaperRip())
        {
            if (OnPaperRip != null) OnPaperRip(this, EventArgs.Empty);
        }
        else if (ShapeManager.Instance.PenIsOnPaper && distanceMoved > PenBreakingLimit)
        {
            if (OnPenBreaking != null) OnPenBreaking(this, EventArgs.Empty);
        }
        else
        {
            UpdatePaperRotation();
            UpdatePaperPosition();
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

    private void UpdatePaperPosition()
    {
        var yPos = LeftHand.Hand.position.y + RightHand.Hand.position.y / 2;
        Paper.transform.position = new Vector3(Paper.transform.position.x, yPos, Paper.transform.position.z);
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
