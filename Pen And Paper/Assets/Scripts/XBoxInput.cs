using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class XBoxInput
{
    /// <summary>
    /// True if the button A is pressed, otherwise false
    /// </summary>
    public bool ButtonA;

    /// <summary>
    /// True if the button B is pressed, otherwise false
    /// </summary>
    public bool ButtonB;

    /// <summary>
    /// True if the button X is pressed, otherwise false
    /// </summary>
    public bool ButtonX;

    /// <summary>
    /// True if the button Y is pressed, otherwise false
    /// </summary>
    public bool ButtonY;

    /// <summary>
    /// True if the button Start is pressed, otherwise false
    /// </summary>
    public bool ButtonStart;

    /// <summary>
    /// The left stick input.
    /// x value: -1 (left), 0 (middle) 1 (right)
    /// y value: -1 (down), 0 (middle) 1 (up)
    /// </summary>
    public Vector2 LeftStick;

    /// <summary>
    /// The right stick input.
    /// x value: -1 (left), 0 (middle) 1 (right)
    /// y value: -1 (down), 0 (middle) 1 (up)
    /// </summary>
    public Vector2 RightStick;
}
