using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy_start_generator : MonoBehaviour
{
    public static int nunmberofenemy = 3; //��Փx�ɂ���ēG�̐���ς��邽��

    [SerializeField] GameObject enemy;  //��������G

    [SerializeField] int[,] map_updateform; //�G���o���ł���悤�ɂ��邽�߂Ɏ擾����ϐ�
    // Start is called before the first frame update
    async Task maptask()
    {
        while (map_updateform == null)
        {
            map_updateform = Map_update_object.map_formupdate;
            await Task.Delay(1);
        }
    }
    async void Start()
    {
        await maptask();
        var generate_emepty_area = Enemy_generator.enemygenerate(map_updateform);
        int emepty_area_count = generate_emepty_area.Count;
        for(int i = 0; i < nunmberofenemy; i++) //���̏������Əd�����N���肤�遨����while�ŏ�������������������
        {
            int random_area = Random.Range(0, emepty_area_count);
            var enempty_coordinate = generate_emepty_area[random_area];
            int coordinatex = enempty_coordinate[0];
            int coordinatey = enempty_coordinate[1];
            //Map_update_object.map_formupdate[coordinatex, coordinatey] = Map_update_object.enemy_num;
            Enemy_generator.enemygenerateInstantiate(enemy, coordinatex, coordinatey);
        }
    }
}
