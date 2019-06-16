using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//参考ブログ　https://spphire9.wordpress.com/2013/11/17/unity%E3%81%A7%E3%82%A2%E3%82%AF%E3%83%86%E3%82%A3%E3%83%96%E3%81%A7%E3%81%AA%E3%81%84gameobject%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B/
//非アクティブのオブジェクトを表示するには、

public class StopMgr : MonoBehaviour {

    public bool buttonEnabled = false;//ボタン押下無効

    GameObject quizmanager;
    QuizMgr quizMgr;

    public GameObject StopPanel;//非アクティブのオブジェクトはFindでは見つからないので、パブリックにして、エディタで登録
    public GameObject Question;//非アクティブではないが、同上
    public GameObject Result1;
    public GameObject Result2;
    public GameObject Genre;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;

    private void Start() {
        quizmanager = GameObject.Find("QuizManager"); //QuizManagerをオブジェクトの名前から取得して変数に格納する
        quizMgr = quizmanager.GetComponent<QuizMgr>();//Mgrはスクリプト、managerはオブジェクト
    }

    // Update is called once per frame
    public void Click() {
        if (buttonEnabled == true) {
            StopPanel.SetActive(true);
            Question.SetActive(false);
            Result1.SetActive(false);
            Result2.SetActive(false);
            Genre.SetActive(false);
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Button4.SetActive(false);

            buttonEnabled = false;
            iTween.Stop();//ゲージの動きをストップさせる
            quizMgr.timerStart = false; //タイマーの動きをストップする
        }
    }
    public void Resume() {
        StopPanel.SetActive(false);
        Question.SetActive(true);
        Result1.SetActive(true);
        Result2.SetActive(true);
        Genre.SetActive(true);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        Button4.SetActive(true);

        buttonEnabled = true;
        //iTween.Stop();//ゲージの動きを再開させる
        quizMgr.timerStart = true; //タイマーの動きを再開する
    }
}
