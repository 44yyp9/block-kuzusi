using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_to_title : MonoBehaviour
{
    public void Back_title()
    {
        SceneManager.LoadScene("start-scnen");
    }
}
