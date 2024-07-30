using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bgm_slider : MonoBehaviour
{
    [SerializeField] Slider bgm_slider;
    private void Update()
    {
        bgm_slider.onValueChanged.AddListener((value) =>
        {
            if (value < 0 || value > 1)
            {
                value = 0.5f;
                return;
            }
            Controll_game_bgm.game_bgm_voice = value;
        });
    }
}
