using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//参考URL：https://web-dev.hatenablog.com/entry/unity/quit-game

public class ExitButton : MonoBehaviour {

    GameObject unitychan;
    UnityChanLocomotion unitychanLoco;
    public bool buttonEnabled = true;//ボタン押下有効

    public GameObject exitbutton;
    ExitButton eb;

    public GameObject creditbutton;
    Message cb;

    public GameObject startbutton;
    StartButton sb;

    public void ExitGame () {
        if (buttonEnabled == true) {
            unitychan = GameObject.Find("unitychan");
            unitychanLoco = unitychan.GetComponent<UnityChanLocomotion>();
            unitychanLoco.ExitGame();

            exitbutton = GameObject.Find("MainCanvas/ExitButton");
            eb = exitbutton.GetComponent<ExitButton>();
            eb.buttonEnabled = false;// EXITボタン無効

            creditbutton = GameObject.Find("MainCanvas/CreditButton");
            cb = creditbutton.GetComponent<Message>();
            cb.buttonEnabled = false;// クレジットボタン無効

            startbutton = GameObject.Find("MainCanvas/StartButton");
            sb = startbutton.GetComponent<StartButton>();
            sb.buttonEnabled = false;// スタートボタン無効

            Invoke("Quit", 2.2f);
        }
	}

    void Quit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
}
