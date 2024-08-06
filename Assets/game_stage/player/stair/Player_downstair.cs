using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_downstair : MonoBehaviour
{
    private Player_movig_stair movig_stair;
    private void Start()
    {
        movig_stair=GetComponent<Player_movig_stair>();
    }
    void Update()
    {
        movig_stair.move_stair(Map_update_object.exit_stair_num, -1);
    }
}
