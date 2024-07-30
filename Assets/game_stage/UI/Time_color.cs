using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_color : MonoBehaviour
{
    [SerializeField] Text time_text;
    void Update()
    {
        var time_counter=Time_UI.time_counter;
        if (time_counter > 10 || time_counter <= 0) return;
        time_text.color=Color.red;
    }
}
