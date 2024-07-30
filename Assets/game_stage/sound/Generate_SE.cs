using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_SE : MonoBehaviour
{
    [SerializeField] AudioSource se;
    private void Start()
    {
        se = GetComponent<AudioSource>();
    }
    void Update()
    {
        isplayer_generate_hole(KeyCode.W);
        isplayer_generate_hole(KeyCode.A);
        isplayer_generate_hole(KeyCode.S);
        isplayer_generate_hole(KeyCode.D);
    }
    private void isplayer_generate_hole(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            se.Play();
        }
    }
}
