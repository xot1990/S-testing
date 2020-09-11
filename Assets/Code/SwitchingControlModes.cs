using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SwitchingControlModes : MonoBehaviour, IPointerUpHandler
{
    public GameObject ManualControl;
    public GameObject ComputerControl;
    Scrollbar Scroll;
    float StarValue = 0;

    private void Start()
    {
        Scroll = GetComponent<Scrollbar>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Scroll.interactable = true;
    }

    public void Switching()
    {
        if (StarValue - Scroll.value > 0) Scroll.value = 0;
        else Scroll.value = 1;



        if (Scroll.value == 0)
        {
            ManualControl.SetActive(false);
            ComputerControl.SetActive(true);
            StarValue = 0;
        }
        else if (Scroll.value == 1)
        {
            ManualControl.SetActive(true);
            ComputerControl.SetActive(false);
            StarValue = 1;
        }

        Scroll.interactable = false;
    }


}
