using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ps4Input
{
    /// <summary>
    /// True if the button X is pressed, otherwise false
    /// </summary>
    public bool ButtonX;

    /// <summary>
    /// True if the button Cirlce is pressed, otherwise false
    /// </summary>
    public bool ButtonCircle;

    /// <summary>
    /// True if the button Triangle is pressed, otherwise false
    /// </summary>
    public bool ButtonTriangle;

    /// <summary>
    /// True if the button Square is pressed, otherwise false
    /// </summary>
    public bool ButtonSquare;

    /// <summary>
    /// True if the button Cirlce is pressed, otherwise false
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
