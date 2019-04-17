using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee.UIExtensions;//追加

//参考URL　コガネブログ　http://baba-s.hatenablog.com/entry/2018/05/21/090000

public class Shine : MonoBehaviour {

    public ShinyEffectForUGUI m_shiny;

    private void Start() {
        ShinePlay();
    }
    void ShinePlay() {
        m_shiny.Play(1);
        Invoke("ShinePlay", 2.0f);
    }

}
