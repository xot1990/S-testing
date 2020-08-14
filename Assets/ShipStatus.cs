using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatus : MonoBehaviour
{
    public static bool Marsh1 = true;
    public static bool Marsh2 = true;
    public static bool Marsh3 = true;
    public static bool STB = true;
    public static bool shuntingGreen;
    public static bool shuntingBlue;
    public static bool shuntingYellow;
    public static bool shuntingPink;
    public static bool shuntingDarkPink;
    public static bool shuntingSee;
    public static float ValueJoystickX;
    public static float ValueJoystickY;
    public static bool ManualControl;
    public static GameObject Ship;
    public static GameObject ShuntingGreen;
    public static GameObject ShuntingBlue;
    public static GameObject ShuntingYellow;
    public static GameObject ShuntingPink;
    public static GameObject ShuntingDarkPink;
    public static GameObject ShuntingSee;
    public static bool StartEction;
    public static bool MoveX;
    public static bool MoveY;
    public static float gravityconst =  5 * Mathf.Pow(10, -5);
}
