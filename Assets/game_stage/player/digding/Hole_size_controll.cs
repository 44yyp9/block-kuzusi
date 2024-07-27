using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_size_controll : MonoBehaviour
{
    public void ishole_size_method(int map_posi_x,int map_posi_y)
    {
        var mapform = Map_update_object.map_formupdate;
        var mapposi = mapform[map_posi_x, map_posi_y];
        if (mapposi == Map_update_object.hole_num)
        {
            ishole_num_method();
        }
        else if (mapposi == Map_update_object.hole_size_4_num)
        {
            ishole_size_4_method();
        }
        else if (mapposi == Map_update_object.hole_size_3_num)
        {
            ishole_size_3_method();
        }
        else if (mapposi == Map_update_object.hole_size_2_num)
        {
            ishole_size_2_method();
        }
        else if (mapposi == Map_update_object.nullspace_num)
        {
            ishole_nullspace();
        }
    }
    public virtual void ishole_num_method()
    {
        
    }
    public virtual void ishole_size_4_method()
    {

    }
    public virtual void ishole_size_3_method()
    {

    }
    public virtual void ishole_size_2_method()
    {

    }
    public virtual void ishole_nullspace()
    {

    }
}
