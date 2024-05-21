//--------------------------------------------------------------------
// 科目：ゲームアルゴリズム1年
// 内容：加速度運動
// 日時：2024.05.22 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // Text型を利用可能にする
using UnityEngine.SceneManagement;  // SceneManager.LoadSceneメソッドを利用可能にする

public class PlayerController002 : MonoBehaviour
{
    public Text speedText;  // UI-Legacy-TEXTのTextコンポーネントを保存する

    Vector3 dir;            // 移動方向を保存する変数
    Vector3 inputDir;       // 入力情報を保存する変数
    float speed;            // 移動量を保存する変数
    float axel;             // 加速度を保存する変数
    int bdash;              // Bダッシュ係数を保存する変数

    const float MAX_SPEED = 5; // スピードの上限値を指定する定数

    void Start()
    {
        // 各変数初期化
        dir      = Vector3.zero;
        inputDir = Vector3.zero;
        speed    = 0;
        axel     = 0.02f;
        bdash    = 1;
    }

    void Update()
    {
        // カーソルキーの入力情報をInputDirに保存
        inputDir.x = Input.GetAxisRaw("Horizontal");
        inputDir.z = Input.GetAxisRaw("Vertical");

        // カーソルキーが押されているとき
        if (inputDir.magnitude != 0)
        {
            // 加速度を増やす
            speed += axel;
            // スピードを増やす（上限設定あり）
            speed = Mathf.Min(speed, MAX_SPEED);

            // 入力情報を移動方向に反映
            dir = inputDir;
        }
        else
        {
            // 減速処理
            speed *= 0.98f;
        }

        // クリックでリスタート
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0); // シーンをリスタート           
        }

        // Bdash処理
        bdash = (Input.GetKey(KeyCode.B)) ? 2 : 1;

        // 移動量を現在値に加算
        transform.position += dir.normalized * speed * bdash * Time.deltaTime;

        // 速度表示
        float sokudo = speed * bdash;
        speedText.text = "速度 " + sokudo.ToString("F2") + " m/s";
    }
}
