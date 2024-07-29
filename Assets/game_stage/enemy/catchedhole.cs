using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catchedhole : MonoBehaviour
{
    private int derection = 1;
    private float time;
    [SerializeField] const float delay_time = 0.3f;
    private void Start()
    {
        time = 0;
    }
    private void Update()
    {
        var _mapform = Map_update_object.map_formupdate;
        var _mapposi = Mapposition.isMapposition((int)transform.position.x, (int)transform.position.y);
        //�X�v���C�g�����_���[�̎擾
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (_mapform[_mapposi[0], _mapposi[1]] == Map_update_object.hole_num || _mapform[_mapposi[0], _mapposi[1]] == Map_update_object.hole_size_2_num || _mapform[_mapposi[0], _mapposi[1]] == Map_update_object.hole_size_3_num || _mapform[_mapposi[0], _mapposi[1]] == Map_update_object.hole_size_4_num) { }
        else
        {
            //���ɗ����Ă��Ȃ��Ƃ��̋���
            spriteRenderer.color = new Color(255f, 255f, 255f); 
            return;
        }
        // ���ɗ������Ƃ��̋���
        spriteRenderer.color = new Color(255f, 255f, 0f);
        //���܂�ǂ��Ȃ�����
        time += Time.deltaTime;
        if (time > delay_time)
        {
            catched_enemy_walk();
            time = 0;
        }
    }
    private void catched_enemy_walk()
    {
        derection *= -1;
        transform.localScale = new Vector3(derection * 0.5f, 0.5f, 0.5f);
    }
}
