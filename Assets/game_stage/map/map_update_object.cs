using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Map_update_object : MonoBehaviour
{
    //playerは10　enemyは-10 wallは1　何もないスペースは0
    public const int enemy_num = -10;
    public const int play_num = 10;
    public const int wall_num = 1;
    public const int nullspace_num = 0;
    public static int[,] map_formupdate; //マップの状況取得する値

    [SerializeField] bool startmethodend = true; //スタートメソッドが終わったことを知らせるbool

    async Task reAsync()
    {
        while (map_formupdate == null)
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
