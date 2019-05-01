using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;

public class Judge : MonoBehaviour {

    Image btnImage;

    // inspectorで直接画像のスプライトを張り付ける
    public Sprite Asprite;
    public Sprite Bsprite;

    public static Text selectedBtn;

    GameObject quizmanager;
    QuizMgr quizMgr;

    GameObject unitychan;
    UnityChanController unitychanCon;

    public bool buttonEnabled = true;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;


    GameObject stopButton;
    StopMgr stopMgr;

    Judge judge1;//Button1のjudgeクラス
    Judge judge2;//Button2のjudgeクラス
    Judge judge3;//Button3のjudgeクラス
    Judge judge4;//Button4のjudgeクラス

    private Text result1;
    private Text result2;

    private AudioSource selectse;

    //選択したボタンのテキストラベルと正解のテキストを比較して正誤を判定
    public void CapText() {
        if (this.buttonEnabled == true) {
            iTween.Stop();//ゲージの動きをストップさせる

            stopButton = GameObject.Find("Quiz/StopButton");
            stopMgr = stopButton.GetComponent<StopMgr>();
            stopMgr.buttonEnabled = false;　//ジャッジ中に一時停止されると、次の問題を読み込まなくなるため、無効にする。

            AudioSource[] audioSources = GetComponents<AudioSource>();
            selectse = audioSources[0];
            selectse.PlayOneShot(selectse.clip);
            this.gameObject.GetComponent<Image>().sprite = Bsprite;//選んだ選択肢のボタンを切り替える
            ButtonStop();

            quizmanager = GameObject.Find("QuizManager"); //QuizManagerをオブジェクトの名前から取得して変数に格納する
            quizMgr = quizmanager.GetComponent<QuizMgr>();//Mgrはスクリプト、managerはオブジェクト

            unitychan = GameObject.Find("unitychan");
            unitychanCon = unitychan.GetComponent<UnityChanController>();

            quizMgr.timerStart = false;//タイマーを停止する

            result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
            result2 = GameObject.Find("Question/Result2").GetComponentInChildren<Text>();//Text取得


            //選択したボタンのテキストラベルを取得する
            Text selectedBtn = GetComponentInChildren<Text>();

            //選択したボタンのテキストラベルと問題の答えを比較
            if (selectedBtn.text == QuizMgr.AnswerStr) {
                Debug.Log("正解");
                QuizMgr.Score += 1;
                unitychanCon.Correct();
                result1.color = Color.red;
                result2.color = Color.red;
                result1.text = "正解!";
                result2.text = "C o r r e c t !";
            } else {
                Debug.Log("不正解");
                result1.color = new Color(0f / 255f, 122f / 255f, 255f / 255f);
                result2.color = new Color(0f / 255f, 122f / 255f, 255f / 255f);
                result1.text = "不正解";
                result2.text = "W r o n g";
                unitychanCon.Wrong();
            }
            
            Invoke("Qset", 3.0f);//3.0秒後にクイズを読み込む
        }
    }
        public void Qset() {
            this.gameObject.GetComponent<Image>().sprite = Asprite;//前の問題で選んだ選択肢のボタンを元に戻す
            quizmanager = GameObject.Find("QuizManager"); //1問目でタイムオーバーしたときはCapTextメソッドを行っていないため必要
            quizMgr = quizmanager.GetComponent<QuizMgr>();//同上

            result1 = GameObject.Find("Question/Result1").GetComponentInChildren<Text>();//Text取得
            result2 = GameObject.Find("Question/Result2").GetComponentInChildren<Text>();//Text取得

            result1.text = "";
            result2.text = "";

            ButtonStart();

            quizMgr.NextQuizSet();
        }//上記で作成したオブジェクトを使用する

        public void ButtonStop() {
        button1 = GameObject.Find("Button1");
        judge1 = button1.GetComponent<Judge>();
        judge1.buttonEnabled = false;// button1を押せなくする

        button2 = GameObject.Find("Button2");
        judge2 = button2.GetComponent<Judge>();
        judge2.buttonEnabled = false;// button2を押せなくする

        button3 = GameObject.Find("Button3");
        judge3 = button3.GetComponent<Judge>();
        judge3.buttonEnabled = false;// button3を押せなくする

        button4 = GameObject.Find("Button4");
        judge4 = button4.GetComponent<Judge>();
        judge4.buttonEnabled = false;// button4を押せなくする
    }

    public void ButtonStart() {
        judge1.buttonEnabled = true;// button1を有効にする
        judge2.buttonEnabled = true;// button2を有効にする
        judge3.buttonEnabled = true;// button3を有効にする
        judge4.buttonEnabled = true;// button4を有効にする
    }
}