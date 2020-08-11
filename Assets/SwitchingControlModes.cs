using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchingControlModes : MonoBehaviour
{
    public GameObject ManualControl;
    public GameObject ComputerControl;

    public void Switching()
    {
        float Value = GetComponent<Scrollbar>().value;
        Value = Mathf.Clamp(Value, 0, 1);

        if (Value == 1)
        {
            ManualControl.SetActive(false);
            ComputerControl.SetActive(true);
        }
        else if (Value == 0)
        {
            ManualControl.SetActive(true);
            ComputerControl.SetActive(false);
        }
    }
}
