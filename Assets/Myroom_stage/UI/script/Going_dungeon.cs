using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Going_dungeon : MonoBehaviour
{
    [SerializeField] string scene_name = "SampleScene";
    public void go_dungeon()
    {
        Map_update_object.hierarchy_num = -1;
        Map_generate_stair.unitlHierarchy_list = new List<int>();
        Map_generate_stair.unitlHierarchy_list.Add(Map_update_object.hierarchy_num);
        SceneManager.LoadScene(scene_name);
    }
}
