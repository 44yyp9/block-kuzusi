using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_over : MonoBehaviour
{
    [SerializeField] GameObject gameover_text;
    private void Update()
    {
        var game_timer = Time_UI.time_counter;
        if ((int)game_timer > 0) return;
        //以下からゲームオーバー中のメソッド
        Game_end_loop.isgame_end_method();
        //ゲームオーバーテキストの表示
        gameover_text.SetActive(true);
    }
}
