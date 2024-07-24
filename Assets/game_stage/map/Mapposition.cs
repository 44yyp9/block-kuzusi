using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mapposition : MonoBehaviour
{
    public static List<int> isMapposition(int gameobject_x, int gameobject_y) //unityのpositionを二次元配列に置き換えるメソッド
    {
        var mapposi = new List<int>();
        //x,yはgameobjectの位置のこと
        var x = gameobject_x + 9;
        mapposi.Add(x);
        var y = gameobject_y + 5;
        mapposi.Add(y);
        return mapposi;
    }
    public static Vector2 isUnityposition(int mapposi_x,int mapposi_y) //マップのpositionをunityのポジションに置き換えるメソッド
    {
        //mapposiはマップのxy座標
        var x = mapposi_x - 9;
        var y = mapposi_y - 5;
        Vector2 vec2 = new Vector2(x,y);
        return vec2;
    }
}
