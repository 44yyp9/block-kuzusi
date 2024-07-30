using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll_digding_se : MonoBehaviour
{
    public static float digding_se_voice = 1f;
    [SerializeField] AudioSource digding_se;
    void Start()
    {
        digding_se = GetComponent<AudioSource>();
        digding_se.volume = digding_se_voice;
    }
}
