using UnityEngine;
using System.Collections;
using System.Collections.Generic;// 追記
using UnityEngine.UI;//UI利用時必須
using System.Linq;//配列に必要
using System;//これがないとGuidクラスは使えない

//http://ikedih.blog69.fc2.com/blog-entry-241.html

public class QuizMgr: MonoBehaviour {
    public TextAsset csvFile;	　　　　　// GUIでcsvファイルを割当
　　　　List<string[]> csvDatas = new List<string[]>(); //ここは参考ブログとは違う
    public static string AnswerStr;//問題の答え
    int[] Order1 = null; //出題数を管理するメンバ変数
    int[] Order2;　//出題をランダムにするメンバ変数
    public int Count = 1; //今何問目か


　　　　//スタート時、CSVファイルを読み込む
　　　　public void Start() {

　　　　　　　　// 格納
　　　　　　　　string[] lines = csvFile.text.Replace("\r\n", "\n").Split("\n"[0]);
        foreach (var line in lines) {
            if (line == "") { continue; }
            csvDatas.Add(line.Split(','));　　　　// string[]を追加している
　　　　　　　　}

　　　　　　　　// 書き出し
　　　　　　　　//Debug.Log(csvDatas.Count);　　　　　　　　　// 行数
　　　　　　　　//Debug.Log(csvDatas[0].Length);　　　　　　　// 項目数
　　　　　　　　//Debug.Log(csvDatas[1][2]);        // 2行目3列目

        this.Order1 = new int[csvDatas.Count];　//配列の要素数をCSVの行数分にする
        //配列に順番に数字を入れる
        for(int i = 0; i < csvDatas.Count-1; i++) {
            Order1[i] = i;
        }
        //配列の数字をランダムに入れ替えた配列を作成
        this.Order2 = Order1.OrderBy(i => Guid.NewGuid()).ToArray();
        //Debug.Log(Order1[33]); 
        //Debug.Log(Order2[33]);


        //問題をセットするメソッドを呼び出す
        QuizSet();

　　　　}
    //問題をセットするメソッド
    void QuizSet() {

        //1から4の配列(ary1)を作成
        int[] ary1 = new int[] {1, 2, 3, 4};
        //ary1をランダムに並び替えたary2を作成
        int[] ary2 = ary1.OrderBy(i => Guid.NewGuid()).ToArray();

        for (int i =0; i < csvDatas.Count; i++) {

            //答えをセット
            AnswerStr = csvDatas[Order2[Count]][1];
            //特定の名前のオブジェクトを検索してアクセス
            Text question = GameObject.Find("Quiz/Question").GetComponentInChildren<Text>();
            Text button1 = GameObject.Find("Quiz/Button1").GetComponentInChildren<Text>();
            Text button2 = GameObject.Find("Quiz/Button2").GetComponentInChildren<Text>();
            Text button3 = GameObject.Find("Quiz/Button3").GetComponentInChildren<Text>();
            Text button4 = GameObject.Find("Quiz/Button4").GetComponentInChildren<Text>();
            //データをセットすることで、既存情報を上書きできる
            question.text = csvDatas[Order2[Count]][0];//問題文セット
            button1.text = csvDatas[Order2[Count]][ary2[0]];//ary2の１番目に入っている数字の項目をボタン１にセット
            button2.text = csvDatas[Order2[Count]][ary2[1]];//ary2の２番目に入っている数字の項目をボタン２にセット
            button3.text = csvDatas[Order2[Count]][ary2[2]];//ary2の３番目に入っている数字の項目をボタン３にセット
            button4.text = csvDatas[Order2[Count]][ary2[3]];//ary2の４番目に入っている数字の項目をボタン４にセット
        }
    }
}

