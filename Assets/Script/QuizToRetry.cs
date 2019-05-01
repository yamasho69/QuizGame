using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizToRetry : MonoBehaviour {

    public bool buttonEnabled = true;//ボタン押下有効

    public GameObject retrybutton;
    QuizToRetry qr;

    public GameObject titlebutton;
    QuizToTitle qt;

    public GameObject exitbutton;
    QuizToExit qe;

    public GameObject resumebutton;
    Resume resume;

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

            FadeManager.Instance.LoadScene("QuizScene", 1.0f);
        }
    }
}

