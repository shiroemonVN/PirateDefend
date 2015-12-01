using UnityEngine;
using System.Collections;

public class ButtonRetry : MonoBehaviour {


    public void Retry()
    {
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 1f);
        Application.LoadLevel(Application.loadedLevel);

    }
    
}
