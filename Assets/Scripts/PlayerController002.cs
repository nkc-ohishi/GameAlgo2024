using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController002 : MonoBehaviour
{
    float speed = 5f;   // 速度(m/s)を保存する変数

    void Start()
    {
    }

    void Update()
    {
        Vector3 dir = Vector3.zero; // 移動方向を保存する変数

        // カーソル入力により、移動方向を決定
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");

        // 現在の位置 += 移動方向ｘ速度ｘ0.016667秒
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
