using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_clear : MonoBehaviour
{
    void Update()
    {
        GameObject[] _enemy_tag = GameObject.FindGameObjectsWithTag("Enemy");
        //�������^�[���ɂ���ăl�X�g��󂭂���
        if (_enemy_tag.Length != 0) return;
        //�Q�[���N���A���̏���
    }

}
