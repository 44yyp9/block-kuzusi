using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Map_form_editor : EditorWindow
{
    private const int first_posi_x = 10;

    private const int first_posi_y = 10;

    private int[,] mapform;
    [Serialize] GameObject game_bgm;

    [MenuItem("tools/Mapwindow")]
    public static void create_window()
    {
        EditorWindow.GetWindow<Map_form_editor>(title: "Mapwindow");

    }
    private void Update()
    {
        Repaint();
    }
    private async void OnGUI()
    {
        await maptask();
        mapform = Map_update_object.map_formupdate;
        isaxis_Label();
        isMapposition_cretae();
        restart_button();
    }
    private void isaxis_Label() //x軸とy軸の作成
    {
        var posi_x = first_posi_x;
        //x軸の宣言
        for(int i = 0; i < mapform.GetLength(0); i ++)
        {
            posi_x += 20;
            Rect rect = new Rect((float)posi_x, (float)first_posi_y, 20, 15);
            GUI.Label(rect, i.ToString());
        }
        var posi_y = first_posi_y;
        for(int i = 0; i<mapform.GetLength(1); i++)
        {
            posi_y += 15;
            Rect rect = new Rect((float)first_posi_x, posi_y, 20, 15);
            GUI.Label(rect, i.ToString());
        }
        
    }
    private void isMapposition_cretae()　//マップ上の整数の描画
    {
        var posi_x = first_posi_x + 20;
        var posi_y = first_posi_y + 15;
        int mapnum;
        for(int x = 0; x < mapform.GetLength(0); x++)
        {
            posi_y=first_posi_y+15;
            if (x != 0) posi_x += 20;
            for(int y = 0;y< mapform.GetLength(1); y++)
            {
                if(y!=0) posi_y += 15;
                mapnum = mapform[x,y];
                create_numbercolor(0, Color.white);
                create_numbercolor(Map_update_object.enemy_num, Color.red);
                create_numbercolor(1, Color.black);
                create_numbercolor(Map_update_object.play_num, Color.blue);
                create_numbercolor(Map_update_object.hole_num, Color.yellow);
                create_numbercolor(Map_update_object.hole_size_4_num, Color.yellow);
                create_numbercolor(Map_update_object.hole_size_3_num, Color.yellow);
                create_numbercolor(Map_update_object.hole_size_2_num, Color.yellow);
                create_numbercolor(Map_update_object.inlet_stair_num, Color.red);
                create_numbercolor(Map_update_object.exit_stair_num, Color.cyan);
            }
        }
        void create_numbercolor(int num,Color color) //場合分けとそのときの色の扱い
        {
            if (mapnum == num)
            {
                GUIStyle labelStyle = new GUIStyle(EditorStyles.label);
                labelStyle.normal.textColor = color;
                Rect rect = new Rect(posi_x, posi_y, 20, 15);
                GUI.Label(rect, mapnum.ToString(),labelStyle);
            }
        }
    }
    async Task maptask()
    {
        while (Map_update_object.map_formupdate == null)
        {
            await Task.Delay(1);
        }
    }
    void restart_button()
    {
        Rect buttonRect = new Rect(10, 200, 100, 30);
        if (GUI.Button(buttonRect, "Restart Game"))
        {
            Game_end_loop.Initialise_map();
            string current_scenename = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(current_scenename);
        }
    }
}
