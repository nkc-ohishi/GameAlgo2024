//--------------------------------------------------------------------
// �ȖځF�Q�[���A���S���Y��1�N
// ���e�F�����x�^��
// �����F2024.05.22 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // Text�^�𗘗p�\�ɂ���
using UnityEngine.SceneManagement;  // SceneManager.LoadScene���\�b�h�𗘗p�\�ɂ���

public class PlayerController002 : MonoBehaviour
{
    public Text speedText;  // UI-Legacy-TEXT��Text�R���|�[�l���g��ۑ�����

    Vector3 dir;            // �ړ�������ۑ�����ϐ�
    Vector3 inputDir;       // ���͏���ۑ�����ϐ�
    float speed;            // �ړ��ʂ�ۑ�����ϐ�
    float axel;             // �����x��ۑ�����ϐ�
    int bdash;              // B�_�b�V���W����ۑ�����ϐ�

    const float MAX_SPEED = 5; // �X�s�[�h�̏���l���w�肷��萔

    void Start()
    {
        // �e�ϐ�������
        dir      = Vector3.zero;
        inputDir = Vector3.zero;
        speed    = 0;
        axel     = 0.02f;
        bdash    = 1;
    }

    void Update()
    {
        // �J�[�\���L�[�̓��͏���InputDir�ɕۑ�
        inputDir.x = Input.GetAxisRaw("Horizontal");
        inputDir.z = Input.GetAxisRaw("Vertical");

        // �J�[�\���L�[��������Ă���Ƃ�
        if (inputDir.magnitude != 0)
        {
            // �����x�𑝂₷
            speed += axel;
            // �X�s�[�h�𑝂₷�i����ݒ肠��j
            speed = Mathf.Min(speed, MAX_SPEED);

            // ���͏����ړ������ɔ��f
            dir = inputDir;
        }
        else
        {
            // ��������
            speed *= 0.98f;
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
