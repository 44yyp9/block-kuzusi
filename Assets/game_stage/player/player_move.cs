using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void isplayer_moving(string keycode,int x,int y)
    {
        if (x == 0 || x == -1 || x == 1) return;
        if (y == 0 || y == -1 || y == 1) return;
        KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), keycode);
        if (Input.GetKey(key))
        {
            var mapform = Map_update_object.map_formupdate;
            var player_mapposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
            var mapposi_x = player_mapposi[0];
            var mapposi_y= player_mapposi[1];
            if (mapform[mapposi_x+x, mapposi_y+y] != Map_update_object.wall_num)
            {
                var plaer_transform_posi = Mapposition.isUnityposition(mapposi_x + x, mapposi_y + y);
                transform.position = plaer_transform_posi;
            }
        }
    }
}
