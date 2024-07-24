using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy_move : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] const float movigtime = 0.5f;
    [SerializeField] int movig_rule_counter;

    [SerializeField] int moving_count0;
    [SerializeField] int moving_count1;
    [SerializeField] int moving_count2;
    [SerializeField] int moving_count3;

    [SerializeField] int movied_rule_counter_limit = 5;
    private void Start()
    {
        time = 0;
        movig_rule_counter = 0;
        move_rules();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > movigtime)
        {
            movig_rule_counter+= 1;
            var gameobject_posi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
            var enemyposi_x = gameobject_posi[0];
            var enemyposi_y = gameobject_posi[1];
            //二次元配列の取得
            var mapform = Map_update_object.map_formupdate;
            mapform[enemyposi_x, enemyposi_y] = Map_update_object.enemy_num;
            var wallspace = Map_update_object.wall_num;
            var canmove_list = new List<List<int>>();
            void add_movelist(int posix,int posiy,int rotate_direction,int enemy_direction)
            {
                var posi_list = new List<int>();
                if (mapform[posix, posiy] != wallspace)
                {
                    posi_list.Add(posix);
                    posi_list.Add(posiy);
                    posi_list.Add(rotate_direction);
                    posi_list.Add(enemy_direction) ;
                    if (posi_list.Count != 4) return;
                    canmove_list.Add(posi_list);
                }
            }
            //ポジションの取得
            for(int num = 0; num < moving_count0; num++) add_movelist(enemyposi_x, enemyposi_y + 1, 90, -1);
            for (int num = 0; num < moving_count1; num++) add_movelist(enemyposi_x, enemyposi_y - 1, 90, 1);
            for (int num = 0; num < moving_count2; num++) add_movelist(enemyposi_x + 1, enemyposi_y, 0, -1);
            for (int num = 0; num < moving_count3; num++) add_movelist(enemyposi_x - 1, enemyposi_y, 0, 1);
            //
            int moveRange = canmove_list.Count;
            var moveRandom=Random.Range(0, moveRange);
            var movingDirections = canmove_list[moveRandom];
            var unityposi = Mapposition.isUnityposition(movingDirections[0], movingDirections[1]);
            var unityposi_x = unityposi.x;
            var unityposi_y = unityposi.y;
            transform.position = new Vector2(unityposi_x, unityposi_y);
            transform.rotation = Quaternion.Euler(0, 0, movingDirections[2]);
            transform.localScale = new Vector3((float)movingDirections[3]*0.5f, 0.5f, 1);
            time = 0;
        }
        if(movig_rule_counter>movied_rule_counter_limit)
        {
            movig_rule_counter = 0;
            move_rules();
        }
    }
    private void move_rules()
    {
        moving_count0 = Random.Range(1, 10);
        moving_count1 = Random.Range(1, 10);
        moving_count2 = Random.Range(1, 10);
        moving_count3 = Random.Range(1, 10);
    }
}
