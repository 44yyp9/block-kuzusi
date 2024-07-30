using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing_mode : MonoBehaviour
{
    [SerializeField] int enemy_num;
    public void select_enemy_num()
    {
        Enemy_start_generator.nunmberofenemy = enemy_num;
    }
}
