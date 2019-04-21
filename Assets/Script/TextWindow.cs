using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindow : MonoBehaviour {
	public GUIStyleState styleState;
    private GUIStyle style;

    void Start() {
        style = new GUIStyle();
        style.fontSize = 30;
    }

    void OnGUI() {
        Rect rect = new Rect(10, 10, 400, 300);
        style.normal = styleState;
        GUI.Label(rect, "Stand by Ready!", style);
    }
}