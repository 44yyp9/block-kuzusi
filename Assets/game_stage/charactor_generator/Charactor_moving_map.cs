using UnityEngine;

public class Charactor_moving_map : MonoBehaviour
{
    public static void ischaractor_moving_map(Vector2 gameobject_past_posi,Vector2 gameobject_feature_posi,int charactor_num)
    {
        //ここラムダ式にしたい
        var map_past_posi = Mapposition.isMapposition((int)gameobject_past_posi.x, (int)gameobject_past_posi.y);
        var map_past_posi_x = map_past_posi[0];
        var map_past_posi_y= map_past_posi[1];
        var map_feature_posi = Mapposition.isMapposition((int)gameobject_feature_posi.x, (int)gameobject_feature_posi.y);
        var map_feature_posi_x = map_feature_posi[0];
        var map_feature_posi_y = map_feature_posi[1];

        //メソッドでまとめられないのでここに直書きする
        //出口オブジェクトの移動処理
        if (Map_update_object.map_formupdate[map_past_posi_x, map_past_posi_y] == Map_update_object.exit_stair_num)
        {
            Map_update_object.map_formupdate[map_feature_posi_x, map_feature_posi_y] = charactor_num;
            return;
        }
        if (Map_update_object.map_formupdate[map_feature_posi_x, map_feature_posi_y] == Map_update_object.exit_stair_num)
        {
            Map_update_object.map_formupdate[map_past_posi_x, map_past_posi_y] = Map_update_object.nullspace_num;
            return;
        }
        //入口オブジェクトの移動処理
        if (Map_update_object.map_formupdate[map_past_posi_x, map_past_posi_y] == Map_update_object.inlet_stair_num)
        {
            Map_update_object.map_formupdate[map_feature_posi_x, map_feature_posi_y] = charactor_num;
            return;
        }
        if (Map_update_object.map_formupdate[map_feature_posi_x, map_feature_posi_y] == Map_update_object.inlet_stair_num)
        {
            Map_update_object.map_formupdate[map_past_posi_x, map_past_posi_y] = Map_update_object.nullspace_num;
            return;
        }
        

        //この追加はオブジェクト指向的に良くない
        if (Map_update_object.map_formupdate[map_past_posi_x, map_past_posi_y] == Map_update_object.wall_num) { }
        else if (Map_update_object.map_formupdate[map_past_posi_x,map_past_posi_y] != Map_update_object.hole_num) Map_update_object.map_formupdate[map_past_posi_x, map_past_posi_y] = Map_update_object.nullspace_num;
        if(Map_update_object.map_formupdate[map_feature_posi_x, map_feature_posi_y]!=Map_update_object.hole_num) Map_update_object.map_formupdate[map_feature_posi_x, map_feature_posi_y] = charactor_num;
    }
}
