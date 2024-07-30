using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game_clear : MonoBehaviour
{
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
        var game_timer =(int) Time_UI.time_counter;
        //�������^�[���ɂ���ăl�X�g��󂭂���
        if (_enemy_tag.Length != 0||game_timer==0) return;
        //�Q�[���N���A���̏���
        Game_end_loop.isgame_end_method();
        //�N���A�I�u�W�F�N�g��\��
        game_clear_object.SetActive(true);
    }
    private IEnumerator game_clear_stop()
    {
        yield return new WaitForSeconds(1);
        booleangame_start = true;
    }
}
