using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Diagnostics;

public class Map_update_object : MonoBehaviour
{
    //playerは10　enemyは-10 wallは1　何もないスペースは0 穴は5 穴のサイズ大きいほうから4,3,2とする
    public const int enemy_num = -10;
    public const int play_num = 10;
    public const int wall_num = 1;
    public const int nullspace_num = 0;
    public const int hole_num = 5;
    public const int hole_size_4_num = 4;
    public const int hole_size_3_num = 3;
    public const int hole_size_2_num = 2;


    public static int[,] map_formupdate; //マップの状況取得する値

    [SerializeField] bool startmethodend = true; //スタートメソッドが終わったことを知らせるbool

    async Task reAsync()
    {
        //非同期処理の概念からやらかしていると思われるので後に修正が必要
        while (Map_start_object_genator.game_start)
        {
            map_formupdate = Map_start_object_genator.map_form;
            await Task.Delay(1);
        }
    }
    private async void Start()
    {
        await reAsync();
        startmethodend = false;
    }

    void Update()
    {
        if (startmethodend) return; //値の取得後以下の処理を実行
    }
}
