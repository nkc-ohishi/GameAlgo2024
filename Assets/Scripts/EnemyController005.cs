//--------------------------------------------------------------------
// 科目：ゲームアルゴリズム1年
// 内容：敵の制御
// 日時：2024.06.12 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController005 : MonoBehaviour
{
    Renderer render;    // レンダラーコンポーネント保存
    Vector3 dir;        // 移動方向
    float speed = 5;    // 移動速度

    void Start()
    {
        // 登場位置
        //float x = Random.Range(-49, 49);
        //Vector3 pos = new Vector3(x, 0.5f, 50);
        //transform.position = pos;

        // 移動方向をセット
        // transform.Rotate(Vector3.up, 180);
        dir = transform.forward;

        // 色を赤色系ランダム
        render = GetComponent<Renderer>();
        render.material.color = new Color(Random.value, 0, 0);

        // 寿命
        Destroy(gameObject, 20);
    }

    void Update()
    {
        // 向いている方向に移動
        transform.position += dir * speed * Time.deltaTime;
    }
}
