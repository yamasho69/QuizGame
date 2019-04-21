using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    GameObject unitychan;
    UnityChanLocomotion unitychanLoco;
    public bool buttonEnabled = true;//ボタン押下有効

    public GameObject startbutton;
    StartButton sb;

    public GameObject creditbutton;
    Message cb;

    public GameObject exitbutton;
    ExitButton eb;

    public void StartGame() {
        if (buttonEnabled == true) {
            unitychan = GameObject.Find("unitychan");
            unitychanLoco = unitychan.GetComponent<UnityChanLocomotion>();
            unitychanLoco.StartGame();

            startbutton = GameObject.Find("MainCanvas/StartButton");
            sb = startbutton.GetComponent<StartButton>();
            sb.buttonEnabled = false;// スタートボタン無効

            creditbutton = GameObject.Find("MainCanvas/CreditButton");
            cb = creditbutton.GetComponent<Message>();
            cb.buttonEnabled = false;// クレジットボタン無効

            exitbutton = GameObject.Find("MainCanvas/ExitButton");
            eb = exitbutton.GetComponent<ExitButton>();
            eb.buttonEnabled = false;// EXITボタン無効

            Invoke("QuizStart", 3.5f);
        }
    }

    void QuizStart() {
        sb.buttonEnabled = true;// スタートボタン有効
        cb.buttonEnabled = true;// クレジットボタン有効
        eb.buttonEnabled = true;//　EXITボタン有効
        SceneManager.LoadScene("QuizScene");
    }
}
