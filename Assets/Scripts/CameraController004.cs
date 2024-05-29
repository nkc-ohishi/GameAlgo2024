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
        // 上にスクロール 0.1 , 下にスクロール -0.1 
        mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        transform.position += transform.forward * mouseWheel; 
    }
}
