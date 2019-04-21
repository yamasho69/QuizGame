using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//参考URL　https://materializer.co/lab/blog/139　 
//FadeManagerのDebugModeのチェックは外すこと

public class AwakeUnity : MonoBehaviour {
    private AudioSource Licensevoice;

    // Use this for initialization
    void Start () {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        Licensevoice = audioSources[0];
        Licensevoice.PlayOneShot(Licensevoice.clip);
        Invoke("GoToTitle", 3.5f);
    }
	
	// Update is called once per frame
	void GoToTitle() {
        FadeManager.Instance.LoadScene("TitleScene", 0.5f);
        Destroy(this.gameObject);
    }
}
