using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_end_loop : MonoBehaviour
{
    public static void isgame_end_method(GameObject game_bgm)
    {
        //GLΜΑ
        GameObject[] _enemy_tag = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in _enemy_tag)
        {
            obj.SetActive(false);
        }
        //playerΜΑ
        GameObject[] _player_tag = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in _player_tag)
        {
            obj.SetActive(false);
        }
        //V[JΪ
        string start_scene_name = "start-scnen";
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(start_scene_name);
        }
        game_bgm.SetActive(false);
        Map_start_object_genator.map_form = null;
        Map_update_object.map_formupdate = null;
    }
}
