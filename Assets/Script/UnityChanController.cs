using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    private AudioSource correctvoice;
    private AudioSource wrongvoice;
    private AudioSource timeupvoice;
    private AudioSource pinponvoice;
    private AudioSource damagevoice;
    private AudioSource timeovervoice;
    private AudioSource yattanevoice;
    private AudioSource bubuvoice;
    private AudioSource sonotyoushivoice;
    private AudioSource hazurevoice;
    private AudioSource oovoice;
    private AudioSource sonnaavoice;
    private AudioSource owarivoice;
    private AudioSource sokomadevoice;

    public int idleindex;

    void Start() {
        idleindex = Random.Range(0, 2);//どちらのアイドル状態にするか
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        correctvoice = audioSources[0];
        wrongvoice = audioSources[1];
        timeupvoice = audioSources[2];
        pinponvoice = audioSources[3];
        damagevoice = audioSources[4];
        timeovervoice = audioSources[5];
        yattanevoice = audioSources[6];
        bubuvoice = audioSources[7];
        sonotyoushivoice = audioSources[8];
        hazurevoice = audioSources[9];
        oovoice = audioSources[10];
        sonnaavoice = audioSources[11];
        owarivoice = audioSources[12];
        sokomadevoice = audioSources[13];

        if (idleindex == 1) {
            GetComponent<Animator>().SetTrigger("Idle01Trigger");
        }
        else {GetComponent<Animator>().SetTrigger("Idle02Trigger"); }
    }


    public void Correct() {

        int motionindex = Random.Range(0, 2);//ローカルランダム変数motionindexを作成。０か１がでる。
        int voiceindex = Random.Range(0, 5);//ローカルランダム変数voiceindexを作成。０から4がでる。
        if (motionindex == 0) {
            GetComponent<Animator>().SetTrigger("CorrectTrigger");
        }
        else { GetComponent<Animator>().SetTrigger("SmileTrigger"); }

        if (voiceindex == 0) {
            correctvoice.PlayOneShot(correctvoice.clip);}
        else if (voiceindex == 1) {pinponvoice.PlayOneShot(pinponvoice.clip);}
        else if (voiceindex == 2) {yattanevoice.PlayOneShot(yattanevoice.clip);}
        else if (voiceindex == 3) { oovoice.PlayOneShot(oovoice.clip); }
        else { sonotyoushivoice.PlayOneShot(sonotyoushivoice.clip); }
    }


    public void Wrong() {
        int motionindex = Random.Range(0, 2);//ローカルランダム変数motionindexを作成。０か１がでる。
        int voiceindex = Random.Range(0, 5);//ローカルランダム変数voiceindexを作成。０から4がでる。
        if (motionindex == 0) {
            GetComponent<Animator>().SetTrigger("WrongTrigger");
        }
        else { GetComponent<Animator>().SetTrigger("DamageTrigger"); }

        if (voiceindex == 0) {
            wrongvoice.PlayOneShot(wrongvoice.clip);
        }
        else if (voiceindex == 1) { damagevoice.PlayOneShot(damagevoice.clip); }
        else if (voiceindex == 2) { bubuvoice.PlayOneShot(bubuvoice.clip); }
        else if (voiceindex == 3) { sonnaavoice.PlayOneShot(sonnaavoice.clip); }
        else { hazurevoice.PlayOneShot(hazurevoice.clip); }
    }

    public void TimeUp() {
        int motionindex = Random.Range(0, 2);//ローカルランダム変数motionindexを作成。０か１がでる。
        int voiceindex = Random.Range(0, 2);//ローカルランダム変数voiceindexを作成。０から1がでる。
        if (motionindex == 0) {
            GetComponent<Animator>().SetTrigger("WrongTrigger");}
        else {GetComponent<Animator>().SetTrigger("DamageTrigger");}

        if (voiceindex == 0) {
            timeupvoice.PlayOneShot(timeupvoice.clip);
        }
        else { timeovervoice.PlayOneShot(timeovervoice.clip); }
    }

    public void UnityFinish() {
        int voiceindex = Random.Range(0, 2);//ローカルランダム変数voiceindexを作成。０から1がでる。
        GetComponent<Animator>().SetTrigger("EndTrigger");
        if (voiceindex == 0) {
            owarivoice.PlayOneShot(owarivoice.clip);
        }
        else {sokomadevoice.PlayOneShot(sokomadevoice.clip); }
    }
}
