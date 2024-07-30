using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Now_mode_text : MonoBehaviour
{
    [SerializeField] Text mode_text;
    void Update()
    {
        var text = "";
        var enemy_num_now = Enemy_start_generator.nunmberofenemy;
        if (enemy_num_now == 3)
        {
            text = "easy";
        }
        else if (enemy_num_now == 5)
        {
            text = "normal";
        }
        else if (enemy_num_now == 10)
        {
            text = "hard";
        }
        mode_text.text = "now mode " + text;
    }
}
