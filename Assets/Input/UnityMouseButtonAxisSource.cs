using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class UnityMouseButtonAxisSource : UnityKeyCodeAxisSource
{
	InputControlSource mouseButton1;
	InputControlSource mousebutton2;

	public UnityMouseButtonAxisSource(KeyCode negativeKeyCode, KeyCode positiveKeyCode) : base(negativeKeyCode, positiveKeyCode) { }

	public UnityMouseButtonAxisSource(InputControlSource source1, InputControlSource source2) : base(KeyCode.A, KeyCode.B)
	{
		mouseButton1 = source1;
		mousebutton2 = source2;
	}

	public override float GetValue(InputDevice inputDevice)
	{
		int axisValue = 0;

		if (mouseButton1.GetValue(inputDevice) == 1f)
		{
			axisValue--;
		}

		if (mousebutton2.GetValue(inputDevice) == 1f)
		{
			axisValue++;
		}

		return axisValue;
	}

	public override bool GetState(InputDevice inputDevice)
	{
		return !Mathf.Approximately(GetValue(inputDevice), 0.0f);
	}
}