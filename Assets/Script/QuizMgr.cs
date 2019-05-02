using UnityEngine;
using System.Collections;
using System.Collections.Generic;// 追記
using UnityEngine.UI;//UI利用時必須
using System.Linq;//配列に必要
using System;//これがないとGuidクラスは使えない

public class QuizMgr: MonoBehaviour {
    public TextAsset csvFile;        // GUIでcsvファイルを割当
    List<string[]> csvDatas = new List<string[]>(); //ここは参考ブログとは違う
    public static string AnswerStr;//問題の答え
    int[] Order1 = null; //出題数を管理するメンバ変数
    public int[] Order2;　//出題をランダムにするメンバ変数
    public static int Count = 1; //今何問目か
    public static int Score = 0; //得点 staticで他シーンに得点を渡す　http://www.project-unknown.jp/entry/2015/04/11/195351
    public float countTime = 19.9f;
    public bool timerStart = false;//タイマーを動かすか
    GameObject gauge;
    TimeScript timeSc;

    GameObject unitychan;
    UnityChanController unitychanCon;

    GameObject button1;
    Judge judge;

    GameObject stopButton;
    StopMgr stopMgr;

    private Text result1;
    private Text result2;
    private AudioSource endse;

    private AudioSource youivoice;
    private AudioSource donvoice;
    private AudioSource readyvoice;
    private AudioSource govoice;

    int voiceindex; //ランダム変数voiceindexを作成。

    void Start() {
        Count = 1;
        Score = 0;
        Judge judge = GetComponent<Judge>();
        iTween.Stop();//ゲージの動きをストップさせる
        button1 = GameObject.Find("Button1");
        judge = button1.GetComponent<Judge>();
        judge.ButtonStop();//ボタンの動きを止める

        AudioSource[] audioSources = GetComponents<AudioSource>();
        youivoice = audioSources[1];
        donvoice = audioSources[2];
        readyvoice = audioSources[3];
        govoice = audioSources[4];

        result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
        result1.text = "3";

        voiceindex = UnityEngine.Random.Range(0, 2);//ランダム変数voiceindexを作成。０から1がでる。
        if (voiceindex == 0) {
            youivoice.PlayOneShot(youivoice.clip);
        }else { readyvoice.PlayOneShot(readyvoice.clip); }
        Invoke("CountDownTwo", 1.0f);
    }

    void CountDownTwo() {
        result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
        result1.text = "2";
        Invoke("CountDownOne", 1.0f);
    }

    void CountDownOne() {
        result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
        result1.text = "1";
        Invoke("CountDownZero", 1.0f);
    }

    void CountDownZero() {
        if (voiceindex == 0) {
            donvoice.PlayOneShot(donvoice.clip);
        }
        else {govoice.PlayOneShot(govoice.clip); }
        result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
        result1.text = "START!";
        Invoke("SetUp", 1.0f);
    }

　　　　//スタート時、CSVファイルを読み込む
　　　　public void SetUp() {

        Judge judge = GetComponent<Judge>();
        button1 = GameObject.Find("Quiz/Button1");
        judge = button1.GetComponent<Judge>();
        judge.ButtonStart();

        StopMgr stopMgr = GetComponent<StopMgr>();
        stopButton = GameObject.Find("Quiz/StopButton");
        stopMgr = stopButton.GetComponent<StopMgr>();
        stopMgr.buttonEnabled = true;　//一時停止ボタン押下有効

        gauge = GameObject.Find("Timer/Gauge"); //TimeScriptをオブジェクトの名前から取得して変数に格納する
        timeSc = gauge.GetComponent<TimeScript>();//Scはスクリプト、gaugeはオブジェクト
        timeSc.time = 19.9f;//ゲージの減少時間を再設定
        timeSc.Start();//ゲージを最大値に戻すメソッド

        unitychan = GameObject.Find("unitychan");
        unitychanCon = unitychan.GetComponent<UnityChanController>();


        // 格納
        string[] lines = csvFile.text.Replace("\r\n", "\n").Split("\n"[0]);
        foreach (var line in lines) {
            if (line == "") { continue; }
            csvDatas.Add(line.Split(','));// string[]を追加している
　　　　　　　　}

        Order1 = new int[csvDatas.Count];　//配列の要素数をCSVの行数分にする
        //配列に順番に数字を入れる
        for(int i = 0; i < csvDatas.Count; i++) {
            Order1[i] = i;
        }
        //配列の数字をランダムに入れ替えた配列を作成
        Order2 = Order1.OrderBy(i => Guid.NewGuid()).ToArray();

        //問題をセットするメソッドを呼び出す
        QuizSet();
　　　　}

    public void Update() {
        if (timerStart == true) {//タイマーの動きがあるとき
        countTime -= Time.deltaTime; //スタートしてからの秒数を格納
        Text time = GameObject.Find("Timer/TimeText").GetComponentInChildren<Text>();//TimeText取得
        time.text = countTime.ToString("F1");//TimeTextに経過時間を入れる。F1＝小数第一位まで。
    }

        if (countTime <= 0) {

            stopMgr = stopButton.GetComponent<StopMgr>();
            stopMgr.buttonEnabled = false;　//タイムオーバー中に一時停止されると、次の問題を読み込まなくなるため、無効にする。

            result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
            result2 = GameObject.Find("Question/Result2").GetComponentInChildren<Text>();//Text取得
            result1.color = new Color(0f / 255f, 122f / 255f, 255f / 255f);
            result2.color = new Color(0f / 255f, 122f / 255f, 255f / 255f);
            result1.text = "時間切れ";
            result2.text = "T i m e O v e r";

            unitychanCon.TimeUp();
            iTween.Stop();//ゲージの動きをストップさせる
            timerStart = false; //タイマーの動きをストップする
            button1 = GameObject.Find("Button1");
            judge = button1.GetComponent<Judge>();
            judge.ButtonStop();
            countTime = 0.01f;//カウントが0のままだとNextQuizメソッドが何回も呼び出されてしまう
            Invoke("TimeOver", 3.0f);//3.0f後にTimeOverメソッドを実行
        }
    }

    void TimeOver() {
        judge.Qset();
    }

    //問題をセットするメソッド
    void  QuizSet() {
        timerStart = true;
        result1.text = "";

        //1から4の配列(ary1)を作成
        int[] ary1 = new int[] {1, 2, 3, 4};//正解は１
        //ary1をランダムに並び替えたary2を作成
        int[] ary2 = ary1.OrderBy(i => Guid.NewGuid()).ToArray();

        //答えをセット
        AnswerStr = csvDatas[Order2[Count]][1];
            //特定の名前のオブジェクトを検索してアクセス
            Text question = GameObject.Find("Question/Question").GetComponentInChildren<Text>();
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
        Text qnumberinscore = GameObject.Find("Quiz/QNumberInScore").GetComponentInChildren<Text>();//スコア表示部の何問目かの表示部分を取得

        gauge = GameObject.Find("Timer/Gauge"); //TimeScriptをオブジェクトの名前から取得して変数に格納する
        timeSc = gauge.GetComponent<TimeScript>();//Scはスクリプト、gaugeはオブジェクト

        scorept.text = Score.ToString();//得点を更新
        if (Count <= 10) {

            stopMgr = stopButton.GetComponent<StopMgr>();
            stopMgr.buttonEnabled = true;　//一時停止ボタン押下有効

            questionno.text = Count.ToString();//今10問目まで今何問かを更新
            qnumberinscore.text = Count.ToString();//今10問目まで今何問かを更新
            countTime = 19.9f;
            timeSc.time = 19.9f;//ゲージの減少時間を再設定
            timeSc.Start();//ゲージを最大値に戻すメソッド
            timerStart = true;//タイマーを動かす
            QuizSet();
        }else{
            result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
            result2 = GameObject.Find("Question/Result2").GetComponentInChildren<Text>();//Text取得
            result1.color = Color.green;
            result2.color = Color.green;
            result1.text = "終了";
            result2.text = "E n d";
            AudioSource[] audioSources = GetComponents<AudioSource>();
            endse = audioSources[0];
            endse.PlayOneShot(endse.clip);
            unitychanCon.UnityFinish();
            iTween.Stop();//ゲージの動きをストップさせる
            timerStart = false; //タイマーの動きをストップする
            button1 = GameObject.Find("Button1");
            judge = button1.GetComponent<Judge>();
            judge.ButtonStop();
            FadeManager.Instance.LoadScene("ResultScene", 4.0f); ;//4.0f後に結果発表シーンに遷移
        } 
    }

    //得点を結果シーンに渡すメソッド
    public static int GetScore() {
        return Score;
    }
    
    //ポーズメニューで再開ボタンを押したときのメソッド
    public void Resume() {
        gauge = GameObject.Find("Timer/Gauge"); //TimeScriptをオブジェクトの名前から取得して変数に格納する
        timeSc = gauge.GetComponent<TimeScript>();//Scはスクリプト、gaugeはオブジェクト
        timeSc.time = countTime;//タイムゲージがなくなるのに必要な時間＝現在の残り時間に書き換える
        timeSc.Resume();//ゲージを最大値に戻さず再開させるメソッド
    }
}