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
        //穴が最大以外なら他の敵が来たときに穴が塞がれる処理
        if (boolean_move == false && _map[_mappposi[0], _mappposi[1]] == Map_update_object.enemy_num)
        {
            boolean_move = true;
            _enemy_move.enabled = true;
            return;
        }
        //上から下に処理するためフラグと穴が空のスペースになったらオブジェクトを消去する
        if (boolean_move == false && _map[_mappposi[0], _mappposi[1]] == Map_update_object.nullspace_num) gameObject.SetActive(false); 
        //穴のサイズが最小になって次に穴が空のスペースになったらenemyオブジェクトを消去するためのフラグ
        if (_map[_mappposi[0], _mappposi[1]] != Map_update_object.hole_size_2_num) return;
        boolean_move=false;
        _enemy_move.enabled = false;
    }
}
