using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizToExit : MonoBehaviour {

    public bool buttonEnabled = true;//ボタン押下有効

    public GameObject retrybutton;
    QuizToRetry qr;

    public GameObject titlebutton;
    QuizToTitle qt;

    public GameObject exitbutton;
    QuizToExit qe;

    public GameObject resumebutton;
    Resume resume;

    GameObject unitychan;
    UnityChanController unitychanCon;

    public void Click() {
        if (buttonEnabled == true) {
            retrybutton = GameObject.Find("Question/Stop/RetryButton");
            qr = retrybutton.GetComponent<QuizToRetry>();
            qr.buttonEnabled = false;// リトライボタン無効

            titlebutton = GameObject.Find("Question/Stop/GoToTitleButton");
            qt = titlebutton.GetComponent<QuizToTitle>();
            qt.buttonEnabled = false;// タイトルボタン無効

            exitbutton = GameObject.Find("Question/Stop/ExitButton");
            qe = exitbutton.GetComponent<QuizToExit>();
            qe.buttonEnabled = false;// EXITボタン無効

            resumebutton = GameObject.Find("Question/Stop/ResumeButton");
            resume = resumebutton.GetComponent<Resume>();
            resume.buttonEnabled = false;// 再開ボタン無効

            unitychan = GameObject.Find("unitychan");
            unitychanCon = unitychan.GetComponent<UnityChanController>();

            unitychanCon.UnityExit();

            Invoke("Quit", 2.0f);
        }
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
