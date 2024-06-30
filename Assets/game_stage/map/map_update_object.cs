using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class map_update_object : MonoBehaviour
{
    [SerializeField] int[,] map_formupdate; //マップの状況取得する値

    [SerializeField] bool startmethodend = true; //スタートメソッドが終わったことを知らせるbool

    async Task reAsync()
    {
        while (map_formupdate == null)
        {
            map_formupdate = map_start_object_genator.map_form;
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
