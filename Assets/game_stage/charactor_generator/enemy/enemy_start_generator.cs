using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy_start_generator : MonoBehaviour
{
    public static int nunmberofenemy = 0; //難易度によって敵の数を変えるため

    [SerializeField] GameObject enemy;  //召喚する敵

    [SerializeField] int[,] map_updateform; //敵が出現できるようにするために取得する変数
    // Start is called before the first frame update
    async Task maptask()
    {
        while (map_updateform == null)
        {
            map_updateform = Map_update_object.map_formupdate;
            await Task.Delay(1);
        }
    }
    async void Start()
    {
        await maptask();
        var generate_emepty_area = Enemy_generator.enemygenerate(map_updateform);
        int emepty_area_count = generate_emepty_area.Count;
        for(int i = 0; i < nunmberofenemy; i++) //この処理だと重複が起こりうる→多分whileで処理した方がいいかも
        {
            int random_area = Random.Range(0, emepty_area_count);
            var enempty_coordinate = generate_emepty_area[random_area];
            int coordinatex = enempty_coordinate[0];
            int coordinatey = enempty_coordinate[1];
            Map_update_object.map_formupdate[coordinatex, coordinatey] = Map_update_object.enemy_num;
            Enemy_generator.enemygenerateInstantiate(enemy, coordinatex, coordinatey, this.transform);
        }
    }
}
