using UnityEngine;

public class Generate_hole : MonoBehaviour
{
    [SerializeField] GameObject hole;
    void Update()
    {
        isplayer_generate_hole(KeyCode.W, 0, 1);
        isplayer_generate_hole(KeyCode.S, 0, -1);
        isplayer_generate_hole(KeyCode.A, -1, 0);
        isplayer_generate_hole(KeyCode.D, 1, 0);
    }
    private void isplayer_generate_hole(KeyCode key, int transform_x, int transform_y)
    {
        //èoóàÇÍÇŒtransform_x,yÇÃÉKÅ[ÉhêﬂÇì¸ÇÍÇΩÇ¢
        if (Input.GetKeyDown(key))
        {
            var mapform = Map_update_object.map_formupdate;
            var player_mapposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
            var mapposi_x = player_mapposi[0];
            var mapposi_y = player_mapposi[1];
            if (mapform[mapposi_x + transform_x, mapposi_y + transform_y] ==Map_update_object.nullspace_num|| mapform[mapposi_x + transform_x, mapposi_y + transform_y] == Map_update_object.enemy_num)
            {
                generate_hole_to_map(mapposi_x + transform_x, mapposi_y + transform_y);
                generate_hole_to_unity(mapposi_x + transform_x, mapposi_y + transform_y);
            }
        }
    }
    private void generate_hole_to_map(int hole_map_posi_x,int hole_map_posi_y)
    {
        Map_update_object.map_formupdate[hole_map_posi_x, hole_map_posi_y] = Map_update_object.hole_num;
    }
    private void generate_hole_to_unity(int hole_map_posi_x, int hole_map_posi_y)
    {
        var hole_posi = Mapposition.isUnityposition(hole_map_posi_x, hole_map_posi_y);
        Instantiate(hole, hole_posi, Quaternion.identity);
    }
}
