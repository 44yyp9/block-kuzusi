using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Game_clear : MonoBehaviour
{
    [SerializeField] string start_scene_name = "start-scnen";

    [SerializeField] GameObject game_clear_object;

    private bool booleangame_start = false;

    private void Start()
    {
        StartCoroutine(game_clear_stop());
    }
    void Update()
    {
        if (!booleangame_start) return;
        GameObject[] _enemy_tag = GameObject.FindGameObjectsWithTag("Enemy");
        //早期リターンによってネストを浅くする
        if (_enemy_tag.Length != 0) return;
        //ゲームクリア時の処理
        game_clear_object.SetActive(true);
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(start_scene_name);
        }
    }
    private IEnumerator game_clear_stop()
    {
        yield return new WaitForSeconds(1);
        booleangame_start = true;
    }
}
