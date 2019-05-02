using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//参考ブログ　https://spphire9.wordpress.com/2013/11/17/unity%E3%81%A7%E3%82%A2%E3%82%AF%E3%83%86%E3%82%A3%E3%83%96%E3%81%A7%E3%81%AA%E3%81%84gameobject%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B/
//非アクティブのオブジェクトを表示するには、

public class ResultMgr : MonoBehaviour {

    public int resultScore;

    private AudioSource hakushuse;
    private AudioSource tinse;
    private AudioSource excellentvoice;
    private AudioSource atochottovoice;
    private AudioSource shockvoice;
    private AudioSource byebyevoice;
    private AudioSource sorejyanevoice;

    GameObject verygoodimage;
    GameObject goodimage;
    GameObject badimage;

    public GameObject buttoncanvas;//非アクティブのオブジェクトはFindでは見つからないので、パブリックにして、エディタで登録
    public GameObject exitbutton;

    ExitButton2 eb2;


    private Text scoreText;

    // Use this for initialization
    void Start () {
        resultScore = QuizMgr.GetScore();

        verygoodimage = GameObject.Find("ResultCanvas/Panel/VeryGoodImage");
        goodimage = GameObject.Find("ResultCanvas/Panel/GoodImage");
        badimage = GameObject.Find("ResultCanvas/Panel/BadImage");

        AudioSource[] audioSources = GetComponents<AudioSource>();
        hakushuse = audioSources[0];
        tinse = audioSources[1];
        excellentvoice = audioSources[2];
        atochottovoice = audioSources[3];
        shockvoice = audioSources[4];
        byebyevoice = audioSources[5];
        sorejyanevoice = audioSources[6];

        scoreText = GameObject.Find("ResultCanvas/Panel/ScoreText").GetComponentInChildren<Text>();//Text取得

        Invoke("ResultAction", 1.7f);
    }
	
	// Update is called once per frame
	void ResultAction() {
        buttoncanvas.SetActive(true);//ボタンを表示に

        if (resultScore >= 9) {
            scoreText.color = Color.blue;
            scoreText.text = resultScore　+ "問正解!!";
            GetComponent<Animator>().SetTrigger("VeryGoodTrigger");
            verygoodimage.SetActive(true);//オブジェクトを表示に
            hakushuse.PlayOneShot(hakushuse.clip);
            excellentvoice.PlayOneShot(excellentvoice.clip);
        }
        else if(resultScore >= 6) {
            scoreText.color = Color.green;
            scoreText.text = resultScore + "問正解!";
            GetComponent<Animator>().SetTrigger("GoodTrigger");
            goodimage.SetActive(true);//オブジェクトを表示に
            atochottovoice.PlayOneShot(atochottovoice.clip);
        }
        else{
            GetComponent<Animator>().SetTrigger("BadTrigger");
            scoreText.color = Color.red;
            scoreText.text = resultScore + "問正解…";
            badimage.SetActive(true);//オブジェクトを表示に
            tinse.PlayOneShot(tinse.clip);
            shockvoice.PlayOneShot(shockvoice.clip);
        }
        Invoke("ExitOk", 0.5f);
	}

    void ExitOk() {
        eb2 = exitbutton.GetComponent<ExitButton2>();
        eb2.exitOk = true;
    }

    public void Exit() {
        GetComponent<Animator>().SetTrigger("ByeByeTrigger");
        int voiceindex = Random.Range(0, 2);//ローカルランダム変数voiceindexを作成。０から1がでる。
        if (voiceindex == 0) {
            byebyevoice.PlayOneShot(byebyevoice.clip);
        }
        else { sorejyanevoice.PlayOneShot(sorejyanevoice.clip); }
    }
}
