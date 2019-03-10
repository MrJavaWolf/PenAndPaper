using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PlayerTwoProfile : UnityInputDeviceProfile
{
	public PlayerTwoProfile()
	{
		Name = "Input Profile";

		SupportedPlatforms = new []
		{
			"Windows",
			"Mac",
			"Linux"
		};

		Sensitivity = 1.0f;
		LowerDeadZone = 0.0f;
		UpperDeadZone = 1.0f;

		ButtonMappings = new []
		{
			new InputControlMapping
			{
				Handle = "Fire",
					Target = InputControlType.Action1,
					Source = KeyCodeButton(KeyCode.Space)
			}
		};

		AnalogMappings = new []
		{
			new InputControlMapping
			{
				Handle = "Move X",
					Target = InputControlType.LeftStickX,
					// KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
					Source = KeyCodeAxis(KeyCode.A, KeyCode.D),
					Scale = .5f
			},
			new InputControlMapping
			{
				Handle = "Move Y",
					Target = InputControlType.LeftStickY,
					// Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
					Source = KeyCodeAxis(KeyCode.S, KeyCode.W),
					Scale = .5f
			},
			new InputControlMapping
			{
				Handle = "Look X",
					Target = InputControlType.RightStickX,
					Source = KeyCodeAxis(KeyCode.LeftArrow, KeyCode.RightArrow),
					Scale = .5f
			},
			new InputControlMapping
			{
				Handle = "Look Y",
					Target = InputControlType.RightStickY,
					Source = KeyCodeAxis(KeyCode.DownArrow, KeyCode.UpArrow),
					Scale = .5f
			}
		};
	}
}