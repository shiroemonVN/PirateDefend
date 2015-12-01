using UnityEngine;
using System.Collections;

public class ButtonQuit : MonoBehaviour {
	
    public void loadLevel()
    {
        GameObject.Find("PanelPause").GetComponent<PausePanelScript>().SetScale(0.5f, 0.5f, 0.5f);
        PausePanelScript.showUp = false;
    }
    
}
