using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//参考URL　https://freesworder.net/unity-setactive-true-false/

public class Message : MonoBehaviour {

    public GameObject MessageWindow;//メッセージウィンドウをゲームオブジェクト型で定義
    // Use this for initialization

    // Update is called once per frame
    public void OffWindow() {
            MessageWindow.SetActive(false);//オブジェクトを非表示に
    }

    public void OnWindow() {
        MessageWindow.SetActive(true);//オブジェクトを表示する
    }
}
