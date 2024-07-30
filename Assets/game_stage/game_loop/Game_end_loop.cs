using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_end_loop : MonoBehaviour
{

    public static void isgame_end_method()
    {
        //“GƒLƒƒƒ‰‚ÌÁ‹
        GameObject[] _enemy_tag = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in _enemy_tag)
        {
            obj.SetActive(false);
        }
        //player‚ÌÁ‹
        GameObject[] _player_tag = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in _player_tag)
        {
            obj.SetActive(false);
        }
        //ƒV[ƒ“‘JˆÚ
        string start_scene_name = "start-scnen";
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(start_scene_name);
        }
    }
}
