using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_death : MonoBehaviour
{
    private bool boolean_move;
    private void Start()
    {
        boolean_move = true;
    }
    void Update()
    {
        var _map = Map_update_object.map_formupdate;
        var _mappposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
        var _enemy_move=GetComponent<Enemy_move>();
        //�����ő�ȊO�Ȃ瑼�̓G�������Ƃ��Ɍ����ǂ���鏈��
        if (boolean_move == false && _map[_mappposi[0], _mappposi[1]] == Map_update_object.enemy_num)
        {
            boolean_move = true;
            _enemy_move.enabled = true;
            return;
        }
        //�ォ�牺�ɏ������邽�߃t���O�ƌ�����̃X�y�[�X�ɂȂ�����I�u�W�F�N�g����������
        if (boolean_move == false && _map[_mappposi[0], _mappposi[1]] == Map_update_object.nullspace_num) gameObject.SetActive(false); 
        //���̃T�C�Y���ŏ��ɂȂ��Ď��Ɍ�����̃X�y�[�X�ɂȂ�����enemy�I�u�W�F�N�g���������邽�߂̃t���O
        if (_map[_mappposi[0], _mappposi[1]] != Map_update_object.hole_size_2_num) return;
        boolean_move=false;
        _enemy_move.enabled = false;
    }
}
