using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growthing_hole : Hole_size_controll
{
    private int hole_num = 0;
    private int hole_size_4 = 0;
    private int hole_size_3 = 0;
    private int hole_size_2 = 0;
    private int mapposi_transform_x;
    private int mapposi_transform_y;

    void Update()
    {
        isplayer_generate_hole(KeyCode.W, 0, 1);
        isplayer_generate_hole(KeyCode.S, 0, -1);
        isplayer_generate_hole(KeyCode.A, -1, 0);
        isplayer_generate_hole(KeyCode.D, 1, 0);
    }
    private void isplayer_generate_hole(KeyCode key, int transform_x, int transform_y)
    {
        if (Input.GetKeyDown(key))
        {
            var mapform = Map_update_object.map_formupdate;
            var player_mapposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
            var mapposi_x = player_mapposi[0];
            var mapposi_y = player_mapposi[1];
            if (mapform[mapposi_x + transform_x, mapposi_y + transform_y] != Map_update_object.wall_num)
            {
                mapposi_transform_x = mapposi_x + transform_x;
                mapposi_transform_y= mapposi_y + transform_y;
                ishole_size_method(mapposi_x + transform_x, mapposi_y + transform_y);
            }
        }
    }
    public override void ishole_num_method()
    {
        hole_num++;
        if (hole_num < 2) return;
        Map_update_object.map_formupdate[mapposi_transform_x, mapposi_transform_y] = Map_update_object.hole_size_4_num;
    }
    public override void ishole_size_4_method()
    {
        hole_size_4++;
        if (hole_size_4 < 2) return;
        Map_update_object.map_formupdate[mapposi_transform_x, mapposi_transform_y] = Map_update_object.hole_size_3_num;
    }
    public override void ishole_size_3_method()
    {
        hole_size_3++;
        if (hole_size_3 < 2) return;
        Map_update_object.map_formupdate[mapposi_transform_x, mapposi_transform_y] = Map_update_object.hole_size_2_num;
    }
    public override void ishole_size_2_method()
    {
        hole_size_2++;
        if (hole_size_2 < 2) return;
        Map_update_object.map_formupdate[mapposi_transform_x, mapposi_transform_y] = Map_update_object.nullspace_num;
    }
}
