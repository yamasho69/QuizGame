using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public float time = 19.9f;

    public void Start() {
        transform.localScale = new Vector3(110, 120, 120);//ゲージの大きさを最大にする。
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0f, "time", time, "delay", 0.01f,"easeType", iTween.EaseType.linear));
        //"easeType",iTween.EaseType.linearを後ろに入れると速度が一定になる。
        //"delay", 0.01fを入れないとiTweenをStopさせた後、上手く動かない。
    }

    public void Resume() {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0f, "time", time, "delay", 0.01f, "easeType", iTween.EaseType.linear));
        //"easeType",iTween.EaseType.linearを後ろに入れると速度が一定になる。
        //"delay", 0.01fを入れないとiTweenをStopさせた後、上手く動かない。
    }
}
