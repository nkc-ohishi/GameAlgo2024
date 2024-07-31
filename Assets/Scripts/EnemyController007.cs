//--------------------------------------------------------------------
// 科目：ゲームアルゴリズム1年
// 内容：敵の制御
// 日時：2024.07.10 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController007 : MonoBehaviour
{
    public GameObject expPre;  // 爆発のプレハブを保存
    Renderer render;    // レンダラーコンポーネント保存
    Vector3 dir;        // 移動方向
    float speed = 5;    // 移動速度

    void Start()
    {
        // 移動方向をセット
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

    void OnTriggerEnter(Collider c)
    {
        // 当たってきたオブジェクトのTagが「bullet」だったら
        if (c.tag == "Bullet")
        {
            // 爆発を生成
            Instantiate(expPre, transform.position, transform.rotation);

            Destroy(c.gameObject);  // 当たってきたオブジェクトを削除
            Destroy(gameObject);    // 自分自身を削除           
        }

        // 当たってきたオブジェクトのTagが「Player」だったら
        if (c.tag == "Player")
        {
            // 爆発を生成
            Instantiate(expPre, transform.position, transform.rotation);

            Destroy(gameObject);    // 自分自身を削除
        }
    }

}
