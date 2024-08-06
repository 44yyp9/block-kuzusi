using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Map_generate_stair : MonoBehaviour
{
    [SerializeField] GameObject exit_stair;  //出口オブジェクト
    [SerializeField] GameObject inlet_stair;  //入口オブジェクト

    [SerializeField] GameObject[] _player_tag;
    // Start is called before the first frame update
    async Task maptask()
    {
        while (_player_tag.Length==0) //playerを見つけるまで繰り返す
        {
            _player_tag = GameObject.FindGameObjectsWithTag("Player");
            await Task.Delay(1);
        }
    }
    async void Start()
    {
        await maptask();
        var map_updateform = Map_update_object.map_formupdate;
        //入口オブジェクトの出現
        Vector3 _player_posi = _player_tag[0].transform.position;
        Instantiate(inlet_stair, _player_posi, Quaternion.identity);
        var _player_map_posi = Mapposition.isMapposition((int)_player_posi.x, (int)_player_posi.y);
        Map_update_object.map_formupdate[_player_map_posi[0], _player_map_posi[1]] = Map_update_object.inlet_stair_num;
        //
        //出口オブジェクトの出現
        var generate_emepty_area = Enemy_generator.enemygenerate(map_updateform);
        int emepty_area_count = generate_emepty_area.Count;
        List<int> appear_exit_stair()
        {
            int random_area = Random.Range(0, emepty_area_count);
            List<int> list = new List<int>();
            var enempty_coordinate = generate_emepty_area[random_area];
            int coordinatex = enempty_coordinate[0];
            list.Add(coordinatex);
            int coordinatey = enempty_coordinate[1];
            list.Add(coordinatey);
            return list;
        }
        var exit_stair_posi = appear_exit_stair();
        int coordinatex = exit_stair_posi[0];
        int coordinatey = exit_stair_posi[1];
        while (coordinatex != _player_map_posi[0] && coordinatey != _player_map_posi[1]) //出口オブジェクトとの重複を阻止
        {
            exit_stair_posi = appear_exit_stair();
            coordinatex = exit_stair_posi[0];
            coordinatey = exit_stair_posi[1];
        }
        Map_update_object.map_formupdate[coordinatex,coordinatey] = Map_update_object.exit_stair_num;
        Enemy_generator.enemygenerateInstantiate(exit_stair, coordinatex, coordinatey);
    }
}
