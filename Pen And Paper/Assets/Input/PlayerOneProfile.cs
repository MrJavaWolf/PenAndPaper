using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PlayerOneProfile : UnityInputDeviceProfile
{
    public PlayerOneProfile()
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
            Source = KeyCodeButton(KeyCode.Return)
            }
        };

        AnalogMappings = new []
        {
            new InputControlMapping
            {
            Handle = "Move X",
            Target = InputControlType.LeftStickX,
            // KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
            Source = MouseXAxis
            },
            new InputControlMapping
            {
            Handle = "Move Y",
            Target = InputControlType.LeftStickY,
            // Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
            Source = MouseYAxis
            },
            new InputControlMapping
            {
            Handle = "Look Y",
            Target = InputControlType.RightStickY,
            Source = new UnityMouseButtonAxisSource(MouseButton0, MouseButton1)
            }
        };
    }
}