using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_state : Hole_size_controll
{
    [SerializeField] float object_size = 0.5f;
    // Update is called once per frame
    void Update()
    {
        var mapposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
        ishole_size_method(mapposi[0], mapposi[1]);
    }
    public override void ishole_num_method()
    {
        ishole_localscale(0.5f);
    }
    public override void ishole_size_4_method()
    {
        ishole_localscale(0.4f);
    }
    public override void ishole_size_3_method()
    {
        ishole_localscale(0.3f);
    }
    public override void ishole_size_2_method()
    {
        ishole_localscale(0.2f);
    }
    public override void ishole_nullspace()
    {
        gameObject.SetActive(false);
    }
    private void ishole_localscale(float size)
    {
        object_size = size;
        transform.localScale = new Vector3(object_size, object_size, 1f);
    }
}
