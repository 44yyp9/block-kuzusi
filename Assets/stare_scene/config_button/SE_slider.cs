using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE_slider : MonoBehaviour
{
    [SerializeField] Slider se_slider;
    private void Update()
    {
        se_slider.onValueChanged.AddListener((value) =>
        {
            if (value < 0 || value > 1)
            {
                value = 0.5f;
                return;
            }
            Controll_digding_se.digding_se_voice = value;
        });
    }
}

