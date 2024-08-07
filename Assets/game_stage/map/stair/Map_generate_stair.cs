using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Map_generate_stair : MonoBehaviour
{
    [SerializeField] GameObject exit_stair;  //出口オブジェクト
    [SerializeField] GameObject inlet_stair;  //入口オブジェクト

    [SerializeField] GameObject[] _player_tag;

    private Vector3 _player_posi;
    private List<int> _player_map_posi;
    private int[,] map_updateform;
    public static List<int> unitlHierarchy_list= new List<int>();
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
        //共通の値の取得
        map_updateform = Map_update_object.map_formupdate;
        _player_posi = _player_tag[0].transform.position;
        _player_map_posi = Mapposition.isMapposition((int)_player_posi.x, (int)_player_posi.y);
        //階段を降りるか降りてないかの判定
        if (unitlHierarchy_list.Count == 0) unitlHierarchy_list.Add(-1); //ガード節ゲームの実装するときに消してもいいかも
        bool Upstair; //upstairがfalseなら降りているということ
        var list_length = unitlHierarchy_list.Count - 1;
        var now_hierarchy = unitlHierarchy_list[list_length];
        int one_ago_hierarchy;
        try
        {
            one_ago_hierarchy = unitlHierarchy_list[list_length - 1];
        }
        catch
        {
            one_ago_hierarchy = 0;
        }
        if (now_hierarchy>one_ago_hierarchy) Upstair=false;
        else Upstair=true;
        //階段を登る場合の処理
        if (Upstair)
        {
            isStair_as_playerPosi(inlet_stair, Map_update_object.inlet_stair_num);
            isStair_defferent_playerPosi(exit_stair, Map_update_object.exit_stair_num);
        }else if (!Upstair)  //階段を降りる場合の処理
        {
            isStair_as_playerPosi(exit_stair, Map_update_object.exit_stair_num);
            isStair_defferent_playerPosi(inlet_stair, Map_update_object.inlet_stair_num);
        }

    }
    private void isStair_as_playerPosi(GameObject stairObject,int stair_num)
    {
        Instantiate(stairObject, _player_posi, Quaternion.identity);
        Map_update_object.map_formupdate[_player_map_posi[0], _player_map_posi[1]] = stair_num;
    }
    private void isStair_defferent_playerPosi(GameObject stairObject,int stair_num)
    {
        var generate_emepty_area = Enemy_generator.enemygenerate(map_updateform);
        int emepty_area_count = generate_emepty_area.Count;
        List<int> appear_stair()
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
        var stair_posi = appear_stair();
        int coordinatex = stair_posi[0];
        int coordinatey = stair_posi[1];
        while (coordinatex != _player_map_posi[0] && coordinatey != _player_map_posi[1]) //出口オブジェクトとの重複を阻止
        {
            stair_posi = appear_stair();
            coordinatex = stair_posi[0];
            coordinatey = stair_posi[1];
        }
        Map_update_object.map_formupdate[coordinatex, coordinatey] = stair_num;
        Enemy_generator.enemygenerateInstantiate(stairObject, coordinatex, coordinatey);
    }
}
