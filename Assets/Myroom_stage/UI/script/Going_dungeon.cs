using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Going_dungeon : MonoBehaviour
{
    [SerializeField] string scene_name = "SampleScene";
    public void go_dungeon()
    {
        Map_update_object.hierarchy_num = 0;
        SceneManager.LoadScene(scene_name);
    }
}
