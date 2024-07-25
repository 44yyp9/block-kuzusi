using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_test_script : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            var mapposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
            var mapform = Map_update_object.map_formupdate;
            Debug.Log(mapform[mapposi[0], mapposi[1]]);
        }
    }
}
