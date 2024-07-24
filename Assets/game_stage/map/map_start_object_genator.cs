using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_start_object_genator : MonoBehaviour
{
    public static int[,] map_form; //マップの二次元配列

    [SerializeField] int map_xrange = 10; //マップのx座標
    [SerializeField] int map_yrange = 18; //マップのy座標

    [SerializeField] GameObject wall; //壁のオブジェクト

    void Start()
    {
        map_form = map_start_generate();
        for(int i = 0; i <=map_yrange ; i++)
        {
            for(int j = 0; j <= map_xrange; j++)
            {
                if (map_form[i, j] == 2) map_form[i, j] = 1;
                if (map_form[i, j] == 1)
                {
                    Vector2 map_object_xy = new Vector2(i - 9, j - 5);
                    var parent = this.transform;
                    Instantiate(wall, map_object_xy, Quaternion.identity, parent);
                }
            }
        }
    }
    private int[,] map_start_generate() //迷路生成アルゴリズム
    {
        var map_draw = new int[map_yrange+1, map_xrange+1];
        for(int x = 0; x <= map_xrange; x++)
        {
            for(int y = 0; y <= map_yrange; y++)
            {
                if (x == 0 || x == map_xrange || y == 0 || y == map_yrange)
                {
                    map_draw[y, x] = 1;
                    continue;
                }
                if (x % 2 == 0 && y % 2 == 0)
                {
                    map_draw[y, x] = 1;
                }
            }
        }
        //ここから迷路の生成
        for(int x = 0; x <= map_xrange; x++)
        {
            for(int y = 0; y <= map_yrange; y++)
            {
                if (x==map_xrange-2&&y!=0&&y!=map_yrange&&map_draw[y,map_xrange-2] == 1)
                {
                    int random = Random.Range(0, 4);
                     switch (random)
                     {
                       case 0:
                          map_draw[y + 1, map_xrange - 2] = 2;
                          break;
                       case 1:
                          map_draw[y - 1, map_xrange - 2] = 2;
                          break;
                       case 2:
                          map_draw[y, map_xrange - 1] = 2;
                          break;
                       case 3:
                          map_draw[y, map_xrange - 3] = 2;
                          break;
                     }
                }
                else if (x != 0 && y != 0 && x != map_xrange && y != map_yrange && map_draw[y, x] == 1)
                {
                    bool random_generate = true;
                    while (random_generate)
                    {
                        int random = Random.Range(0, 3);
                        if (map_draw[y, x - 1] != 2 && random == 0)
                        {
                            map_draw[y, x - 1] = 2;
                            random_generate = false;
                        }
                        if (map_draw[y - 1, x] != 2 && random == 1)
                        {
                            map_draw[y - 1, x] = 2;
                            random_generate = false;
                        }
                        if (map_draw[y + 1, x] != 2 && random == 2)
                        {
                            map_draw[y + 1, x] = 2;
                            random_generate = false;
                        }
                    }
                }
            }
        }
        return map_draw;
    }
}


