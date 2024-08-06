using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Diagnostics;

public class Map_update_object : MonoBehaviour
{
    //player��10�@enemy��-10 wall��1�@�����Ȃ��X�y�[�X��0 ����5 ���̃T�C�Y�傫���ق�����4,3,2�Ƃ���
    //exit_stair��7 inlet_stair�� -7
    public const int enemy_num = -10;
    public const int play_num = 10;
    public const int wall_num = 1;
    public const int nullspace_num = 0;
    public const int hole_num = 5;
    public const int hole_size_4_num = 4;
    public const int hole_size_3_num = 3;
    public const int hole_size_2_num = 2;
    public const int exit_stair_num = 7;
    public const int inlet_stair_num = -7;


    public static int[,] map_formupdate; //�}�b�v�̏󋵎擾����l

    [SerializeField] bool startmethodend = true; //�X�^�[�g���\�b�h���I��������Ƃ�m�点��bool

    async Task maptask()
    {
        while (map_formupdate == null)
        {
            map_formupdate = Map_start_object_genator.map_form;
            await Task.Delay(1);
        }
    }
    private async void Start()
    {
        await maptask();
        startmethodend = false;
    }

    void Update()
    {
        if (startmethodend) return; //�l�̎擾��ȉ��̏��������s
    }
}
