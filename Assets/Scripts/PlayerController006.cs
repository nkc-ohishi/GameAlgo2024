//--------------------------------------------------------------------
// �ȖځF�Q�[���A���S���Y��1�N
// ���e�F�����蔻��
// �����F2024.06.12 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // Text�^�𗘗p�\�ɂ���
using UnityEngine.SceneManagement;  // SceneManager.LoadScene���\�b�h�𗘗p�\�ɂ���

public class PlayerController006 : MonoBehaviour
{
    public Text speedText;  // UI-Legacy-TEXT��Text�R���|�[�l���g��ۑ�����
    public Text powerText;  // UI-Legacy-TEXT��Text�R���|�[�l���g��ۑ�����
    GameObject bulletPre;   // �e�̃v���n�u��ۑ�����

    Vector3 dir;            // �ړ�������ۑ�����ϐ�
    float speed;            // �ړ��ʂ�ۑ�����ϐ�
    float axel;             // �����x��ۑ�����ϐ�
    int bdash;              // B�_�b�V���W����ۑ�����ϐ�
    float rad;              // ��]�p�x��ۑ�����ϐ�
    float rotSpeed;         // ��]���x��ۑ�����ϐ�
    float timer;            // �e�̔��ˊԊu����p
    int power;              // ����̋���

    const float MAX_SPEED = 5; // �X�s�[�h�̏���l���w�肷��萔

    void Start()
    {
        // �e�ϐ�������
        dir      = Vector3.zero;
        speed    = 0;
        axel     = 0.02f;
        bdash    = 1;
        rad      = 0;
        rotSpeed = 3;
        timer    = 0;
        power    = 0;

        // Resources�t�H���_���ɂ���e�̃v���n�u���擾����
        bulletPre = (GameObject)Resources.Load("BulletPre");
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
            speed = Mathf.Min(speed, MAX_SPEED);

            // �i�s�������Z�b�g
            dir = transform.forward * z;
        }
        else
        {
            // ��������
            speed *= 0.98f;
        }

        // Bdash����
        bdash = (Input.GetKey(KeyCode.B)) ? 2 : 1;

        // �ړ��ʂ����ݒl�ɉ��Z
        transform.position += dir.normalized * speed * bdash * Time.deltaTime;

        // Z�L�[��������Ă���Ƃ��e�𔭎�
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;

            for (int i = -power; i < power + 1; i++)
            {
                // �e�̐����ʒu�̓v���[���[��0.5m��̈ʒu
                Vector3 pos = transform.position + new Vector3(0, 0.5f, 0);

                // �v���[���[�̉�]�p�x���擾���A15�x�����炵�������ɒe����]������
                Vector3 r = transform.rotation.eulerAngles + new Vector3(0, 15f * i, 0);
                Quaternion rot = Quaternion.Euler(r);

                // �ʒu�Ɖ�]�����Z�b�g���Đ���
                Instantiate(bulletPre, pos, rot);
            }
        }

        // C�L�[��power�ύX
        if (Input.GetKeyDown(KeyCode.C))
        {
            power = (power + 1) % 13;
        }

        // �G���^�[�L�[�Ń��X�^�[�g
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0); // �V�[�������X�^�[�g           
        }

        // ���x�\��
        float sokudo = speed * bdash;
        speedText.text = "���x " + sokudo.ToString("F2") + " m/s";

        // �e���x���\��
        powerText.text = "�e���x�� " + (power+1).ToString("D2");
    }
}
