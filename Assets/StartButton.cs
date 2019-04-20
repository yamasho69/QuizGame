using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    GameObject unitychan;
    UnityChanLocomotion unitychanLoco;
    public bool buttonEnabled = true;//ボタン押下有効

    public GameObject startbutton;
    StartButton sb;

    public void StartGame() {
        if (buttonEnabled == true) {
            unitychan = GameObject.Find("unitychan");
            unitychanLoco = unitychan.GetComponent<UnityChanLocomotion>();
            unitychanLoco.StartGame();

            startbutton = GameObject.Find("MainCanvas/StartButton");
            sb = startbutton.GetComponent<StartButton>();
            sb.buttonEnabled = false;// スタートボタン無効

            Invoke("QuizStart", 3.5f);
        }
    }

    void QuizStart() {
    }
}
