using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController004 : MonoBehaviour
{
    float mouseWheel;

    void Start()
    {
        mouseWheel = 0;
    }

    void Update()
    {
        // ��ɃX�N���[�� 0.1 , ���ɃX�N���[�� -0.1 
        mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        transform.position += transform.forward * mouseWheel; 
    }
}
