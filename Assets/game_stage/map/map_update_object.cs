using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class map_update_object : MonoBehaviour
{
    [SerializeField] int[,] map_formupdate; //�}�b�v�̏󋵎擾����l

    [SerializeField] bool startmethodend = true; //�X�^�[�g���\�b�h���I��������Ƃ�m�点��bool

    async Task reAsync()
    {
        while (map_formupdate == null)
        {
            map_formupdate = map_start_object_genator.map_form;
            await Task.Delay(1);
        }
    }
    private async void Start()
    {
        await reAsync();
        startmethodend = false;
        
    }

    void Update()
    {
        if (startmethodend) return; //�l�̎擾��ȉ��̏��������s
    }
}
