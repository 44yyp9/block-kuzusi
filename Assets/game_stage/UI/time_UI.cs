using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_UI : MonoBehaviour
{
    public static float time_counter;

    [SerializeField] string time_text;
    [SerializeField] Text time_UI;
    void Start()
    {
        time_counter = 30;
    }

    void Update()
    {
        GameObject[] _enemy_tag = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enemy_tag.Length == 0) return;
        time_counter -= Time.deltaTime;
        time_text = is_timer_countdown(time_counter);
        if (time_counter <= 0)
        {
            time_UI.text = "0 : 00";
            return;
        }
        time_UI.text= time_text;
    }
    string is_timer_countdown(float num)
    {
        var timer_list =new List<float>();
        if (num >= 120)
        {
            timer_list.Add(2);
            num -= 120;
        }
        else if (num >= 60)
        {
            timer_list.Add(1);
            num -= 60;
        }
        else if (num < 60)
        {
            timer_list.Add(0);
        }
        var counting_second =num;
        timer_list.Add((int)counting_second);
        if (timer_list.Count != 2) Debug.Log("timer_list_bug");
        string scond_text = "";
        if (timer_list[1] < 10)
        {
            scond_text = "0" + timer_list[1].ToString();
        }
        else
        {
            scond_text= timer_list[1].ToString();
        }
        var text = timer_list[0].ToString() + " : " + scond_text;
        return text;
    }
}
