using UnityEngine;
using System.Collections;
using System.Collections.Generic;// 追記
using UnityEngine.UI;//UI利用時必須
using System.Linq;//配列に必要
using System;//これがないとGuidクラスは使えない

public class QuizMgr: MonoBehaviour {
    public TextAsset csvFile;	　　　　　// GUIでcsvファイルを割当
　　　　List<string[]> csvDatas = new List<string[]>(); //ここは参考ブログとは違う
    public static string AnswerStr;//問題の答え
    int[] Order1 = null; //出題数を管理するメンバ変数
    public int[] Order2;　//出題をランダムにするメンバ変数
    public static int Count = 1; //今何問目か
    public int Score = 0; //得点
    public float countTime = 9.9f;
    GameObject gauge;
    TimeScript timeSc;

　　　　//スタート時、CSVファイルを読み込む
　　　　public void Start() {

        Judge judge = GetComponent<Judge>();


    // 格納
    string[] lines = csvFile.text.Replace("\r\n", "\n").Split("\n"[0]);
        foreach (var line in lines) {
            if (line == "") { continue; }
            csvDatas.Add(line.Split(','));　　　　// string[]を追加している
　　　　　　　　}

        Order1 = new int[csvDatas.Count];　//配列の要素数をCSVの行数分にする
        //配列に順番に数字を入れる
        for(int i = 0; i < csvDatas.Count-1; i++) {
            Order1[i] = i;
        }
        //配列の数字をランダムに入れ替えた配列を作成
        Order2 = Order1.OrderBy(i => Guid.NewGuid()).ToArray();
        
        //問題をセットするメソッドを呼び出す
        QuizSet();
　　　　}

    public void Update() {
        countTime -= Time.deltaTime; //スタートしてからの秒数を格納
        Text time = GameObject.Find("Timer/TimeText").GetComponentInChildren<Text>();//TimeText取得
        time.text = countTime.ToString("F1");//TimeTextに経過時間を入れる。F1＝小数第一位まで。
        

        if (countTime <= 0) {
            NextQuizSet();
        }
    }

    //問題をセットするメソッド
    void  QuizSet() {

        //1から4の配列(ary1)を作成
        int[] ary1 = new int[] {1, 2, 3, 4};//正解は１
        //ary1をランダムに並び替えたary2を作成
        int[] ary2 = ary1.OrderBy(i => Guid.NewGuid()).ToArray();

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
    public void NextQuizSet() {
        Count++;

        Text scorept = GameObject.Find("Quiz/ScorePoint").GetComponentInChildren<Text>();//スコア表示部分を取得
        Text questionno = GameObject.Find("Quiz/QuestionNumber").GetComponentInChildren<Text>();//何問目かの表示部分を取得

        gauge = GameObject.Find("Timer/Gauge"); //TimeScriptをオブジェクトの名前から取得して変数に格納する
        timeSc = gauge.GetComponent<TimeScript>();//Scはスクリプト、scriptはオブジェクト

        scorept.text = Score.ToString();//得点を更新
        questionno.text = Count.ToString();//今何問目かを更新
        countTime = 9.9f;
        timeSc.time = 9.9f;//ゲージの減少時間を再設定
        timeSc.Start();//ゲージを最大値に戻すメソッド

        //Debug.Log(Count);
        if(Count == 11) {
        } else {QuizSet();}
    }
}