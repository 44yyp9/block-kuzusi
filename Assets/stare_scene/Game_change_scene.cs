using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_change_scene : MonoBehaviour
{
    [SerializeField] string scene_name;
    public void change_scene()
    {
        SceneManager.LoadScene(scene_name);
    }
}
