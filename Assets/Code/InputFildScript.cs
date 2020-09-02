using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InputFildScript : MonoBehaviour
{
    public float Value;
    InputField Field;

    void Start()
    {
        Field = GetComponent<InputField>();
    }

    
    void Update()
    {
        
    }

    public void SetValue()
    {
        Value = SystemControler.GetFloat(Field.text, Value);
        Value = Mathf.Clamp(Value, 0, 10f);
        Field.text = "" + Value;
        Value *= SystemControler.TimeScaleConst;

    }
        
}
