using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;

public class Judge : MonoBehaviour {

    public static Text selectedBtn;

    GameObject quizmanager;
    QuizMgr quizMgr;

    GameObject unitychan;
    UnityChanController unitychanCon;

    //選択したボタンのテキストラベルと正解のテキストを比較して正誤を判定
    public void CapText() {

        quizmanager = GameObject.Find("QuizManager"); //QuizManagerをオブジェクトの名前から取得して変数に格納する
        quizMgr = quizmanager.GetComponent<QuizMgr>();//Mgrはスクリプト、managerはオブジェクト

        unitychan = GameObject.Find("unitychan");
        unitychanCon = unitychan.GetComponent<UnityChanController>();


        //選択したボタンのテキストラベルを取得する
        Text selectedBtn = this.GetComponentInChildren<Text>();
       
        //選択したボタンのテキストラベルと問題の答えを比較
        if (selectedBtn.text == QuizMgr.AnswerStr) {
            Debug.Log("正解");
            quizMgr.Score += 1;
            unitychanCon.Correct();
        } else {
            Debug.Log("不正解");
            unitychanCon.Wrong();
        }
        iTween.Stop();//ゲージの動きをストップさせる
        quizMgr.NextQuizSet();//上記で作成したオブジェクトを使用する
    }
}