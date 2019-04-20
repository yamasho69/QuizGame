using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//参考URL　https://freesworder.net/unity-setactive-true-false/

public class Message : MonoBehaviour {
    public GameObject startbutton;
    StartButton sb;
    public GameObject exitbutton;
    ExitButton eb;

    public GameObject MessageWindow;//メッセージウィンドウをゲームオブジェクト型で定義
    // Use this for initialization

    // Update is called once per frame
    public void OffWindow() {
        MessageWindow.SetActive(false);//オブジェクトを非表示に
        startbutton = GameObject.Find("MainCanvas/StartButton");
        sb = startbutton.GetComponent <StartButton>();
        sb.buttonEnabled = true;// スタートボタン有効
        exitbutton = GameObject.Find("MainCanvas/ExitButton");
        eb = exitbutton.GetComponent<ExitButton>();
        eb.buttonEnabled = true;// EXITボタン有効
    }

    public void OnWindow() {
        MessageWindow.SetActive(true);//オブジェクトを表示する
        startbutton = GameObject.Find("MainCanvas/StartButton");
        sb = startbutton.GetComponent<StartButton>();
        sb.buttonEnabled = false;// スタートボタン無効
        exitbutton = GameObject.Find("MainCanvas/ExitButton");
        eb = exitbutton.GetComponent<ExitButton>();
        eb.buttonEnabled = false;// EXITボタン無効
    }
}
