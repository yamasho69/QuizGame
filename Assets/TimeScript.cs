﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public float time = 10.0f;

    public void Start() {
        transform.localScale = new Vector3(120, 120, 120);
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0f, "time", time, "delay", 0.01f,"easeType", iTween.EaseType.linear));
        //"easeType",iTween.EaseType.linearを後ろに入れると速度が一定になる。
    }
}
