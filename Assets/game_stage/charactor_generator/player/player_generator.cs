using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player_generator : MonoBehaviour
{
    [SerializeField] GameObject player;  //召喚するplayer

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
        int random_area = Random.Range(0, emepty_area_count);
        var enempty_coordinate = generate_emepty_area[random_area];
        int coordinatex = enempty_coordinate[0];
        int coordinatey = enempty_coordinate[1];
        //Map_update_object.map_formupdate[coordinatex, coordinatey] = Map_update_object.play_num;
        Enemy_generator.enemygenerateInstantiate(player, coordinatex, coordinatey);
    }
}

