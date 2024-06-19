//--------------------------------------------------------------------
// 科目：ゲームアルゴリズム1年
// 内容：当たり判定
// 日時：2024.06.12 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // Text型を利用可能にする
using UnityEngine.SceneManagement;  // SceneManager.LoadSceneメソッドを利用可能にする

public class PlayerController006 : MonoBehaviour
{
    public Text speedText;  // UI-Legacy-TEXTのTextコンポーネントを保存する
    public Text powerText;  // UI-Legacy-TEXTのTextコンポーネントを保存する
    GameObject bulletPre;   // 弾のプレハブを保存する

    Vector3 dir;            // 移動方向を保存する変数
    float speed;            // 移動量を保存する変数
    float axel;             // 加速度を保存する変数
    int bdash;              // Bダッシュ係数を保存する変数
    float rad;              // 回転角度を保存する変数
    float rotSpeed;         // 回転速度を保存する変数
    float timer;            // 弾の発射間隔制御用
    int power;              // 武器の強さ

    const float MAX_SPEED = 5; // スピードの上限値を指定する定数

    void Start()
    {
        // 各変数初期化
        dir      = Vector3.zero;
        speed    = 0;
        axel     = 0.02f;
        bdash    = 1;
        rad      = 0;
        rotSpeed = 3;
        timer    = 0;
        power    = 0;

        // Resourcesフォルダ内にある弾のプレハブを取得する
        bulletPre = (GameObject)Resources.Load("BulletPre");
    }

    void Update()
    {
        // 左右キーで回転
        rad = Input.GetAxisRaw("Horizontal") * rotSpeed;
        transform.Rotate(Vector3.up, rad);

        // ↑キーで前進、↓キーで後退
        float z = Input.GetAxisRaw("Vertical");

        // 上下キーが押されているとき
        if (z != 0)
        {
            // スピードアップ
            speed += axel;

            // スピードを増やす（上限設定あり）
            speed = Mathf.Min(speed, MAX_SPEED);

            // 進行方向をセット
            dir = transform.forward * z;
        }
        else
        {
            // 減速処理
            speed *= 0.98f;
        }

        // Bdash処理
        bdash = (Input.GetKey(KeyCode.B)) ? 2 : 1;

        // 移動量を現在値に加算
        transform.position += dir.normalized * speed * bdash * Time.deltaTime;

        // Zキーが押されているとき弾を発射
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;

            for (int i = -power; i < power + 1; i++)
            {
                // 弾の生成位置はプレーヤーの0.5m上の位置
                Vector3 pos = transform.position + new Vector3(0, 0.5f, 0);

                // プレーヤーの回転角度を取得し、15度ずつずらした方向に弾を回転させる
                Vector3 r = transform.rotation.eulerAngles + new Vector3(0, 15f * i, 0);
                Quaternion rot = Quaternion.Euler(r);

                // 位置と回転情報をセットして生成
                Instantiate(bulletPre, pos, rot);
            }
        }

        // Cキーでpower変更
        if (Input.GetKeyDown(KeyCode.C))
        {
            power = (power + 1) % 13;
        }

        // エンターキーでリスタート
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0); // シーンをリスタート           
        }

        // 速度表示
        float sokudo = speed * bdash;
        speedText.text = "速度 " + sokudo.ToString("F2") + " m/s";

        // 弾レベル表示
        powerText.text = "弾レベル " + (power+1).ToString("D2");
    }
}
