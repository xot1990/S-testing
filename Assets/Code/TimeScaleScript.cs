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
        Value = Mathf.Clamp(Value, 0, 10000000f);
        SystemControler.TimeScaleConst = Value;
        SystemControler.PastTimeScale = SystemControler.NowTimeScale;
        SystemControler.NowTimeScale = Value;

        if (SystemControler.PastTimeScale > SystemControler.NowTimeScale)
        {
            resault = 1 / Mathf.Abs(SystemControler.NowTimeScale - SystemControler.PastTimeScale);
        }
        if (SystemControler.PastTimeScale < SystemControler.NowTimeScale)
        {
            resault = SystemControler.NowTimeScale - SystemControler.PastTimeScale;
        }
        if (SystemControler.PastTimeScale == SystemControler.NowTimeScale)
        {
            resault = 1;
        }

        body.velocity = body.velocity * resault;
        CurrentScale.text = "X" + SystemControler.NowTimeScale;
    }
}
