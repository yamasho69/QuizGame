using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    public bool buttonEnabled = true;

    public GameObject stopbutton;
    StopMgr sm;

    GameObject quizmanager;
    QuizMgr quizMgr;

    public float time;

    // Use this for initialization
    public void Click () {

        quizmanager = GameObject.Find("QuizManager"); //QuizManagerをオブジェクトの名前から取得して変数に格納する
        quizMgr = quizmanager.GetComponent<QuizMgr>();//Mgrはスクリプト、managerはオブジェクト
        quizMgr.Resume();


        stopbutton = GameObject.Find("Quiz/StopButton");
        sm = stopbutton.GetComponent<StopMgr>();
        sm.Resume();
    }
}
