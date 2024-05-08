//--------------------------------------------------------------
// 何かキーが押されたらフェードしながらシーン遷移
//--------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public string sceneName;        // インスペクタでシーン名を登録
    public float changeTime;        // フェード時間

    private void Start()
    {
        // フェード時間の最小値を0.5秒にする
        changeTime = Mathf.Max(0.5f, changeTime);
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            // フェード時間を設定してシーン遷移
            FadeManager.Instance.LoadScene(sceneName, changeTime);
        }
    }
}
