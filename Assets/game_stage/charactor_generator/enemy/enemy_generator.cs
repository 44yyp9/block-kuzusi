using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_generator : MonoBehaviour
{
    //player��10�@enemy��-10 wall��1�@�����Ȃ��X�y�[�X��0
    
    // Start is called before the first frame update
    
    public static List<int[]> enemygenerate(int[,] map_form) //�}�b�v�̋󔒂̃X�y�[�X�������郁�\�b�h
    {
        var empty_map_area = new List<int[]>();
        for (int x = 0; x < map_form.GetLength(0); x++)
        {
            for(int y = 0; y < map_form.GetLength(1); y++)
            {
                if (map_form[x, y] == 0)
                {
                    var empty_feild =new[] { x, y };
                    empty_map_area.Add(empty_feild);
                }
            }
        }
        return empty_map_area;
    }
    public static void enemygenerateInstantiate(GameObject enemy, int x,int y)�@//�}�b�v��ɃI�u�W�F�N�g���o�������郁�\�b�h
    {
        x = x - 9;
        y = y - 5;
        Vector2 vec2 = new Vector2(x, y);
        Instantiate(enemy,vec2, Quaternion.identity);
    }
}
