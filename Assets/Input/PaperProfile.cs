using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PaperProfile : UnityInputDeviceProfile
{
    public PaperProfile()
    {
        Name = "Input Profile";

        SupportedPlatforms = new[]
        {
            "Windows",
            "Mac",
            "Linux"
        };

        Sensitivity = 1.0f;
        LowerDeadZone = 0.0f;
        UpperDeadZone = 1.0f;

        ButtonMappings = new[]
        {
            new InputControlMapping
            {
                Handle = "Fire",
                    Target = InputControlType.Action1,
                    Source = KeyCodeButton(KeyCode.Space)
            }
        };

        AnalogMappings = new[]
        {
            new InputControlMapping
            {
                Handle = "Move X",
                Target = InputControlType.LeftStickX,
				// KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
				Source = KeyCodeAxis(KeyCode.A, KeyCode.D)
            },
            new InputControlMapping
            {
                Handle = "Move Y",
                Target = InputControlType.LeftStickY,
				// Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
				Source = KeyCodeAxis(KeyCode.S, KeyCode.W)
            },
            new InputControlMapping
            {
                Handle = "Look X",
                Target = InputControlType.RightStickX,
                Source = KeyCodeAxis(KeyCode.LeftArrow, KeyCode.RightArrow)
            },
            new InputControlMapping
            {
                Handle = "Look Y",
                Target = InputControlType.RightStickY,
                Source = KeyCodeAxis(KeyCode.DownArrow, KeyCode.UpArrow)
            }
        };
    }
}