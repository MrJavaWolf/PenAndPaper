using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add this script to a gameobject and call the methods.
/// </summary>
public class InputController : MonoBehaviour
{
    private const string XBox_Stick_Left_Horizontal = "XBox_Stick_Left_Horizontal";
    private const string XBox_Stick_Left_Vertical = "XBox_Stick_Left_Vertical";
    private const string XBox_Stick_Right_Horizontal = "XBox_Stick_Right_Horizontal";
    private const string XBox_Stick_Right_Vertical = "XBox_Stick_Right_Vertical";
    private const string XBox_X = "XBox_X";
    private const string XBox_A = "XBox_A";
    private const string XBox_B = "XBox_B";
    private const string XBox_Y = "XBox_Y";
    private const string XBox_Start = "XBox_Start";

    private const string Ps4_Stick_Left_Horizontal = "Ps4_Stick_Left_Horizontal";
    private const string Ps4_Stick_Left_Vertical = "Ps4_Stick_Left_Vertical";
    private const string Ps4_Stick_Right_Horizontal = "Ps4_Stick_Right_Horizontal";
    private const string Ps4_Stick_Right_Vertical = "Ps4_Stick_Right_Vertical";
    private const string Ps4_Square = "Ps4_Square";
    private const string Ps4_X = "Ps4_X";
    private const string Ps4_Circle = "Ps4_Circle";
    private const string Ps4_Triangle = "Ps4_Triangle";
    private const string Ps4_Start = "Ps4_Start";

    /// <summary>
    /// If enabled it will not read the actual controller input, this allowes you to change the values of 'XBox Input' and 'Ps4 Input' in the Unity editor. 
    /// </summary>
    [Tooltip("If enabled it will not read the actual controller input, this allowes you to change the values of 'XBox Input' and 'Ps4 Input' in the Unity editor.")]
    public bool DebugInput = false;

    [SerializeField]
    private XBoxInput xboxInput = new XBoxInput();

    [SerializeField]
    private Ps4Input ps4Input = new Ps4Input();

    void Update()
    {
        GetXBoxInput();
        GetPs4Input();
    }

    /// <summary>
    /// Get the XBox controller input
    /// </summary>
    public XBoxInput GetXBoxInput()
    {
        if (!DebugInput) UpdateXBoxInput();
        return xboxInput;
    }

    /// <summary>
    /// Get the PS4 controller input
    /// </summary>
    /// <returns></returns>
    public Ps4Input GetPs4Input()
    {
        if (!DebugInput) UpdatePs4Input();
        return ps4Input;
    }

    private void UpdateXBoxInput()
    {
        xboxInput.ButtonA = GetButtonInput(XBox_A);
        xboxInput.ButtonB = GetButtonInput(XBox_B);
        xboxInput.ButtonX = GetButtonInput(XBox_X);
        xboxInput.ButtonY = GetButtonInput(XBox_Y);
        xboxInput.ButtonStart = GetButtonInput(XBox_Start);
        xboxInput.LeftStick = GetAxisInput(XBox_Stick_Left_Horizontal, XBox_Stick_Left_Vertical);
        xboxInput.RightStick = GetAxisInput(XBox_Stick_Right_Horizontal, XBox_Stick_Right_Vertical);
    }

    private void UpdatePs4Input()
    {
        ps4Input.ButtonCircle = GetButtonInput(Ps4_Circle);
        ps4Input.ButtonSquare = GetButtonInput(Ps4_Square);
        ps4Input.ButtonTriangle = GetButtonInput(Ps4_Triangle);
        ps4Input.ButtonX = GetButtonInput(Ps4_X);
        ps4Input.ButtonStart = GetButtonInput(Ps4_Start);
        ps4Input.LeftStick = GetAxisInput(Ps4_Stick_Left_Horizontal, Ps4_Stick_Left_Vertical);
        ps4Input.RightStick = GetAxisInput(Ps4_Stick_Right_Horizontal, Ps4_Stick_Right_Vertical);
    }

    private Vector2 GetAxisInput(string horizontal, string vertical)
    {
        return new Vector2(
            Input.GetAxis(horizontal),
            Input.GetAxis(vertical));
    }

    private bool GetButtonInput(string button)
    {
        return Input.GetButton(button);
    }
}
