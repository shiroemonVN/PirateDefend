using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fading : MonoBehaviour {
    public Texture fadeOutTexture;
    public float fadeSpeed = 0.8f;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void Update()
    {
        
    }

    void OnGUI()
    {
        if (MenuScript.clicked == true)
        {
            fadeDir = 1;
        }
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        //Debug.Log(alpha);
        
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),fadeOutTexture);
    }
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
}
