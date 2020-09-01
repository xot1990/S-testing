using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    public GameObject Year;
    public GameObject Month;
    public GameObject Day;
    public GameObject Hour;
    public GameObject Minute;

    Text year;
    Text month;
    Text day;
    Text hour;
    Text minute;

    float _minute;
    float _hour;
    float _day;
    float _month;
    float _year;

    float timedelta;

    public static float param = 60;
    

    private void Awake()
    {
        Year = transform.Find("Year").gameObject;
        Month = transform.Find("Month").gameObject;
        Day = transform.Find("Day").gameObject;
        Hour = transform.Find("Hour").gameObject;
        Minute = transform.Find("Minute").gameObject;
    }

    void Start()
    {
        year = Year.GetComponentInChildren<Text>();
        month = Month.GetComponentInChildren<Text>();
        day = Day.GetComponentInChildren<Text>();
        hour = Hour.GetComponentInChildren<Text>();
        minute = Minute.GetComponentInChildren<Text>();

        _minute = 0;
        _hour = 0;
        _day = 0;
        _month = 0;
        _year = 0;

    }

    
    void Update()
    {        
        timedelta = Time.deltaTime * (SystemControler.TimeScaleConst * 1000f);

        if (timedelta < 60)
        {
            param -= timedelta;

            if (param <= 0)
            {
                param = 60 - param;
                _minute++;
            }
            if (_minute >= 60)
            {
                _hour++;
                _minute = 0;
            }

            if (_hour >= 24)
            {
                _day++;
                _hour = 0;
            }

            if (_day >= 30)
            {
                _month++;
                _day = 0;
            }

            if (_month >= 12)
            {
                _year++;
                _month = 0;
            }
        }

        if (timedelta > 60 && timedelta < 1440)
        {
            timedelta /= 60;
            param -= timedelta;

            if (param <= 0)
            {
                param = 24 - param;
                _hour++;
            }            

            if (_hour >= 24)
            {
                _day++;
                _hour = 0;
            }

            if (_day >= 30)
            {
                _month++;
                _day = 0;
            }

            if (_month >= 12)
            {
                _year++;
                _month = 0;
            }
        }

        if (timedelta > 1440 && timedelta < 43200)
        {
            timedelta /= 1440;
            param -= timedelta;

            if (param <= 0)
            {
                param = 30 - param;
                _day++;
            }
           

            if (_day >= 30)
            {
                _month++;
                _day = 0;
            }

            if (_month >= 12)
            {
                _year++;
                _month = 0;
            }
        }

        if (timedelta > 43200 && timedelta < 518400)
        {
            timedelta /= 43200;
            param -= timedelta;

            if (param <= 0)
            {
                param = 12 - param;
                _month++;
            }           

            if (_month >= 12)
            {
                _year++;
                _month = 0;
            }
        }

        if (timedelta > 518400)
        {
            timedelta /= 518400;
            param -= timedelta;

            if (param <= 0)
            {
                param = 60;
                _year++;
            }
        }


        minute.text = "m: "+_minute;
        hour.text = "h: " + _hour;
        day.text = "D: " + _day;
        month.text = "M: " + _month;
        year.text = "Y: " + _year;


    }
}
