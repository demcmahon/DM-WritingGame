﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;    //the texture that will overlay the screen
    public float fadeSpeed;      //the fading speed

    private int drawDepth = -1000;      //texture order in hierarchy
    private float alpha = 1.0f;         //texture alpha value between 0 and 1
    private int fadeDir = -1;           //the direction to fade in = -1 or out = 1

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture ( new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    private void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    
    }

}
