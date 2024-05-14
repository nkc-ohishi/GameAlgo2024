//--------------------------------------------------------------------
// �ȖځF�Q�[���A���S���Y��1�N
// ���e�F�����Ă�������Ɉړ�
// �����F2024.05.22 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController003 : MonoBehaviour
{
    public Text speedText;  // UI-TEXT�I�u�W�F�N�g��ۑ�����

    Vector3 dir;            // �ړ�������ۑ�����ϐ�
    float speed;            // �ړ��ʂ�ۑ�����ϐ�
    float axel;             // �����x��ۑ�����ϐ�
    int bdash;              // B�_�b�V���W����ۑ�����ϐ�
    float rad;              // ��]�p�x��ۑ�����ϐ�
    float rotSpeed;         // ��]���x��ۑ�����ϐ�

    const float MAX_SPEED = 5; // �X�s�[�h�̏���l���w�肷��萔

    void Start()
    {
        // �e�ϐ�������
        dir = Vector3.zero;
        speed = 0;
        axel = 0.02f;
        bdash = 1;
        rad = 0;
        rotSpeed = 3;
    }

    void Update()
    {
        // ���E�L�[�ŉ�]
        rad = Input.GetAxisRaw("Horizontal") * rotSpeed;
        transform.Rotate(Vector3.up, rad);

        // ���L�[�őO�i�A���L�[�Ō��
        float z = Input.GetAxisRaw("Vertical");

        // �㉺�L�[��������Ă���Ƃ�
        if (z != 0)
        {
            // �X�s�[�h�A�b�v
            speed += axel;

            // �X�s�[�h�𑝂₷�i����ݒ肠��j
            speed = (speed <= MAX_SPEED) ? speed : MAX_SPEED;

            // �i�s�������Z�b�g
            dir = transform.forward * z;
        }
        else
        {
            // ��������
            speed *= 0.9f;
        }

        // �N���b�N�Ń��X�^�[�g
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0); // �V�[�������X�^�[�g           
        }

        // Bdash����
        bdash = (Input.GetKey(KeyCode.B)) ? 2 : 1;

        // �ړ��ʂ����ݒl�ɉ��Z
        transform.position += dir.normalized * speed * bdash * Time.deltaTime;

        // ���x�\��
        float sokudo = speed * bdash;
        speedText.text = "���x " + sokudo.ToString("F2") + " m/s";
    }
}

//PlayerController003.cs �Ɉȉ��̓��{����b���̃R�[�h�ɕϊ�����B
//�P�D���E�L�[�ŉ�]�p�x�𑝌�������
//�@�@��]�p�x�̓f�O���[�ifloat�l�j�ŕۑ�������
//�Q�D���������p�x�����ɁA�x������ɃI�u�W�F�N�g����]������
//�@�@��]�����閽�߂́Atransform.Rotate( ��]��, ��]�p�x(degree) )
//�R�D��]��̃I�u�W�F�N�g�̌������擾
//�@�@�������擾����ɂ́A transform.forward �̒l�𗘗p����
//�S�D�����𗘗p���āA�����Ă�������ɏ�L�[�őO�i�A���L�[�Ō��
//��L�̃X�N���v�g���L�q����ƁA���E�L�[�ŕ����]���A�㉺�L�[�őO�i��ނ���悤�ɂȂ�B
