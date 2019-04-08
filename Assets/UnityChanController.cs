using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    private AudioSource correctvoice;
    private AudioSource wrongvoice;
    private AudioSource timeupvoice;

    void Start() {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        correctvoice = audioSources[0];
        wrongvoice = audioSources[1];
        timeupvoice = audioSources[2];
    }


    public void Correct() {
        GetComponent<Animator>().SetTrigger("CorrectTrigger");
        correctvoice.PlayOneShot(correctvoice.clip);
    }
    public void Wrong() {
        GetComponent<Animator>().SetTrigger("WrongTrigger");
        wrongvoice.PlayOneShot(wrongvoice.clip);
    }

    public void TimeUp() {
        GetComponent<Animator>().SetTrigger("WrongTrigger");
        timeupvoice.PlayOneShot(timeupvoice.clip);
    }
}
