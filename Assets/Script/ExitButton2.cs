using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton2 : MonoBehaviour {

    public bool buttonEnabled = true;//ボタン押下有効
    public bool exitOk = false;//終了可能

    public GameObject retrybutton;
    RetryButton rb;

    public GameObject titlebutton;
    TitleButton tb;

    public GameObject exitbutton2;
    ExitButton2 eb2;

    GameObject unitychan;
    ResultMgr resultMgr;

    public void ExitGame() {
        if (buttonEnabled == true && exitOk == true) {
            rb = retrybutton.GetComponent<RetryButton>();
            rb.buttonEnabled = false;// リトライボタン無効

            tb = titlebutton.GetComponent<TitleButton>();
            tb.buttonEnabled = false;// タイトルボタン無効

            eb2 = exitbutton2.GetComponent<ExitButton2>();
            eb2.buttonEnabled = false;// EXITボタン無効

            unitychan = GameObject.Find("unitychan");
            resultMgr = unitychan.GetComponent<ResultMgr>();
            Invoke("BeforeQuit", 0.8f);
        }
    }
    private void BeforeQuit() {
        resultMgr.Exit();//Exitアクション
        Invoke("Quit", 2.0f);
    }


    void Quit() {
        Application.Quit();
        /*#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif */
    }
}
