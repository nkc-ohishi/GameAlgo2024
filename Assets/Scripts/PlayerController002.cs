using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController002 : MonoBehaviour
{
    float speed = 5f;   // ���x(m/s)��ۑ�����ϐ�

    void Start()
    {
    }

    void Update()
    {
        Vector3 dir = Vector3.zero; // �ړ�������ۑ�����ϐ�

        // �J�[�\�����͂ɂ��A�ړ�����������
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");

        // ���݂̈ʒu += �ړ����������x��0.016667�b
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
