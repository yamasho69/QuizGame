using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour {

    public bool buttonEnabled = true;//ボタン押下有効

    public GameObject retrybutton;
    RetryButton rb;

    public GameObject titlebutton;
    TitleButton tb;

    public GameObject exitbutton2;
    ExitButton2 eb2;

    public void ExitGame() {
        if (buttonEnabled == true) {
            retrybutton = GameObject.Find("ResultCanvas/RetryButton");
            rb = retrybutton.GetComponent<RetryButton>();
            rb.buttonEnabled = false;// リトライボタン無効

            titlebutton = GameObject.Find("ResultCanvas/TitleButton");
            tb = titlebutton.GetComponent<TitleButton>();
            tb.buttonEnabled = false;// タイトルボタン無効

            exitbutton2 = GameObject.Find("ResultCanvas/ExitButton");
            eb2 = exitbutton2.GetComponent<ExitButton2>();
            eb2.buttonEnabled = false;// EXITボタン無効

            Invoke("RetryQuiz", 2.4f);
        }
    }

    void RetryQuiz() {
        FadeManager.Instance.LoadScene("QuizScene", 0.5f);
    }
}
