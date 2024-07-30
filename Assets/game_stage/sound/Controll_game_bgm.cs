using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll_game_bgm : MonoBehaviour
{
    public static float game_bgm_voice = 0.5f;
    [SerializeField] AudioSource game_bgm;
    void Start()
    {
        game_bgm = GetComponent<AudioSource>();
        game_bgm.volume = game_bgm_voice;
    }
}
