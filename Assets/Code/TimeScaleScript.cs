using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeScaleScript : MonoBehaviour
{
    public float Value;
    InputField Field;
    float resault = 1;
    Rigidbody2D body;
    Text CurrentScale;

    void Start()
    {
        body = SystemControler.Ship.GetComponent<Rigidbody2D>();
        Field = GetComponent<InputField>();
        CurrentScale = transform.Find("CurrentScale").GetComponent<Text>();
    }

    
    void Update()
    {
        
    }

    public void TimeScaler()
    {
        Value = SystemControler.GetFloat(Field.text, Value);
        Value = Mathf.Clamp(Value, 0, 100f);
        
        CurrentScale.text = "X" + Value;
        Time.timeScale = Value;
    }
}
