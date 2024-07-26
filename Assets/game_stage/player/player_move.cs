using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    void Update()
    {
        isplayer_moving(KeyCode.RightArrow, 1, 0, 0, -1);
        isplayer_moving(KeyCode.LeftArrow, -1, 0, 0, 1);
        isplayer_moving(KeyCode.UpArrow, 0, 1, 90, 1);
        isplayer_moving(KeyCode.DownArrow, 0, -1, 90, -1);
    }
    private void isplayer_moving(KeyCode key,int transform_x,int transform_y,int rorate,int scale)
    {
        //èoóàÇÍÇŒtransform_x,yÇÃÉKÅ[ÉhêﬂÇì¸ÇÍÇΩÇ¢
        if (Input.GetKeyDown(key))
        {
            var mapform = Map_update_object.map_formupdate;
            var player_mapposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
            var mapposi_x = player_mapposi[0];
            var mapposi_y= player_mapposi[1];
            if (mapform[mapposi_x+transform_x, mapposi_y+transform_y] != Map_update_object.wall_num)
            {
                var plaer_transform_posi = Mapposition.isUnityposition(mapposi_x + transform_x, mapposi_y + transform_y);
                transform.position = plaer_transform_posi;
                transform.rotation = Quaternion.Euler(0, 0, rorate);
                transform.localScale = new Vector3((float)scale * 0.5f, 0.5f, 1);
                Debug.Log("scusec");
            }
        }
    }
}
