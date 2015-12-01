using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    public bool pause;
	// Use this for initialization
	void Start () {
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if (pause)
        //{
        //    Time.timeScale = 0;
        //}
        //else if (!pause)
        //{
        //    Time.timeScale = 1;
        //}
        

	}
    public void PauseTheGame()
    {
        PausePanelScript.showUp = true;
        pause = !pause;
    }
    
}
