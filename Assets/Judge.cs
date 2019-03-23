using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;

public class Judge : MonoBehaviour {

    public static Text selectedBtn;

    //選択したボタンのテキストラベルと正解のテキストを比較して正誤を判定
    public void CapText() {
        //選択したボタンのテキストラベルを取得する
        Text selectedBtn = this.GetComponentInChildren<Text>();

        //選択したボタンのテキストラベルと問題の答えを比較
        if (selectedBtn.text == QuizMgr.AnswerStr) {
            Debug.Log("正解");
        } else {
            Debug.Log("不正解");
        }
    }
}
