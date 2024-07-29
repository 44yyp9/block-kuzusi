using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_script : MonoBehaviour
{
    private bool boolean_game_strat = false;
    [SerializeField] GameObject object1;
    [SerializeField] GameObject object2;
    //[SerializeField] GameObject object3;
    //[SerializeField] GameObject object4;
    // Start is called before the first frame update
    void Start()
    {
        while (boolean_game_strat == false)
        {
            StartCoroutine(game_start());
            object1.SetActive(true);
            object2.SetActive(true);
            //object3.SetActive(true);
            //object4.SetActive(true);
        }
    }
    private IEnumerator game_start()
    {
        yield return null;
        boolean_game_strat = true;
    }
}
