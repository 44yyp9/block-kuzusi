using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_up_stair : MonoBehaviour
{
    private Player_movig_stair movig_stair;
    private int _start_posi_x;
    private int _start_posi_y;
    private bool boolean_start;
    void Start()
    {
        movig_stair = GetComponent<Player_movig_stair>();
    }

    // Update is called once per frame
    void Update()
    {
        movig_stair.move_stair(Map_update_object.inlet_stair_num, 1);
    }
}
