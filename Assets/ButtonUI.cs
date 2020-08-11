using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{

    bool presed = true;

    public void Presed()
    {
        if (presed)
        {
            switch (gameObject.name)
            {
                case "M1":
                    {
                        ShipStatus.Marsh1 = false;
                    }
                    break;
                case "M2":
                    {
                        ShipStatus.Marsh2 = false;
                    }
                    break;
                case "M3":
                    {
                        ShipStatus.Marsh3 = false;
                    }
                    break;
            }
            GetComponentInChildren<Toggle>().isOn = false;
            presed = false;
        }
        else
        {
            switch (gameObject.name)
            {
                case "M1":
                    {
                        ShipStatus.Marsh1 = true;
                    }
                    break;
                case "M2":
                    {
                        ShipStatus.Marsh2 = true;
                    }
                    break;
                case "M3":
                    {
                        ShipStatus.Marsh3 = true;
                    }
                    break;
            }
            GetComponentInChildren<Toggle>().isOn = true;
            presed = true;
        }
       
    }
}
