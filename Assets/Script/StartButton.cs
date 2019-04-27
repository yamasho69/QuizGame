using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//参考ブログ　https://materializer.co/lab/blog/139
//フェードイン・フェードアウトを使うシーンには必ずヒエラルキーにFadeManagerを入れること

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

    private void Start() {
        startbutton = GameObject.Find("MainCanvas/StartButton");
        sb = startbutton.GetComponent<StartButton>();
        creditbutton = GameObject.Find("MainCanvas/CreditButton");
        cb = creditbutton.GetComponent<Message>();
        exitbutton = GameObject.Find("MainCanvas/ExitButton");
        eb = exitbutton.GetComponent<ExitButton>();
        sb.buttonEnabled = true;// スタートボタン有効
        cb.buttonEnabled = true;// クレジットボタン有効
        eb.buttonEnabled = true;//　EXITボタン有効
    }

    public void StartGame() {
        if (buttonEnabled == true) {
            unitychan = GameObject.Find("unitychan");
            unitychanLoco = unitychan.GetComponent<UnityChanLocomotion>();
            unitychanLoco.StartGame();

            sb.buttonEnabled = false;// スタートボタン無効
            cb.buttonEnabled = false;// クレジットボタン無効
            eb.buttonEnabled = false;// EXITボタン無効

            Invoke("QuizStart", 1.6f);
        }
    }

    void QuizStart() {
        FadeManager.Instance.LoadScene("QuizScene", 0.5f);
    }
}
