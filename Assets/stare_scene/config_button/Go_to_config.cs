using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_to_config : MonoBehaviour
{
    public void  go_to_config()
    {
        SceneManager.LoadScene("config_scene");
    }
}
