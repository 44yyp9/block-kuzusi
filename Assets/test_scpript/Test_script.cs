using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_script : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 1f) return;
        Map_update_object.map_formupdate[1, 1] = 10;
        Map_update_object.map_formupdate[15, 1] = 10;
        Map_update_object.map_formupdate[3, 8] = 10;

    }
}