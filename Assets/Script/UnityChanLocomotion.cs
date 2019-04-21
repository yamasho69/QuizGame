using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanLocomotion : MonoBehaviour {

    private AudioSource hazimaruyovoice;
    private AudioSource junbivoice;
    private AudioSource furefurevoice;
    private AudioSource otsukarevoice;
    private AudioSource byebyevoice;
    private AudioSource sorejyanevoice;

    GameObject Bg1;
    BackGroundController Bgc1;

    GameObject Bg2;
    BackGroundController Bgc2;

    void Start() {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        hazimaruyovoice = audioSources[0];
        junbivoice = audioSources[1];
        furefurevoice = audioSources[2];
        otsukarevoice = audioSources[3];
        byebyevoice = audioSources[4];
        sorejyanevoice = audioSources[5];
    }
    public void StartGame() {
        ScrollStop();
        int voiceindex = Random.Range(0, 3);//ローカルランダム変数voiceindexを作成。０から2がでる。
            GetComponent<Animator>().SetTrigger("JumpTrigger");

        if (voiceindex == 0) {
            hazimaruyovoice.PlayOneShot(hazimaruyovoice.clip);
        }
        else if (voiceindex == 1) { junbivoice.PlayOneShot(junbivoice.clip); }
        else { furefurevoice.PlayOneShot(furefurevoice.clip); }
    }

    public void ExitGame() {
        ScrollStop();
        int voiceindex = Random.Range(0, 3);//ローカルランダム変数voiceindexを作成。０から2がでる。
        GetComponent<Animator>().SetTrigger("ByebyeTrigger"); 

        if (voiceindex == 0) {
            byebyevoice.PlayOneShot(byebyevoice.clip);
        }
        else if (voiceindex == 1) { sorejyanevoice.PlayOneShot(sorejyanevoice.clip); }
        else { otsukarevoice.PlayOneShot(otsukarevoice.clip); }
    }

    void ScrollStop() {
        transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 1, 0));//180度の方向に向かせる
        Bg1 = GameObject.Find("BG01");
        Bgc1 = Bg1.GetComponent<BackGroundController>();
        Bgc1.scrollSpeed = 0; ;//スクロールを止める

        Bg2 = GameObject.Find("BG02");
        Bgc2 = Bg2.GetComponent<BackGroundController>();
        Bgc2.scrollSpeed = 0; ;//スクロールを止める
    }
}

