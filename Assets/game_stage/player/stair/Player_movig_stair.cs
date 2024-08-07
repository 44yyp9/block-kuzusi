using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_movig_stair : MonoBehaviour
{
    public void move_stair(int stair_num,int up_or_down)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var map_form = Map_update_object.map_formupdate;
            var _player_posi = gameObject.transform.position;
            var _player_map_posi = Mapposition.isMapposition((int)_player_posi.x, (int)_player_posi.y);
            if (map_form[_player_map_posi[0], _player_map_posi[1]] == stair_num)
            {
                if (up_or_down < -1 || up_or_down > 1 || up_or_down == 0) return; //ÉKÅ[Éhêﬂ
                Map_update_object.hierarchy_num += up_or_down;
                Map_generate_stair.unitlHierarchy_list.Add(Map_update_object.hierarchy_num);
                Game_end_loop.Initialise_map();
                string current_scenename = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(current_scenename);
            }
        }
    }
}
