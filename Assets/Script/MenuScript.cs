using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	// Use this for initialization
    public static bool clicked = false;
	void Start () {
        clicked = false;
	}

    void Awake()
    {

    }

	// Update is called once per frame
	void Update () {
        //Debug.Log(clicked);
	}
    public void setClick()
    {
        clicked = false;
    }
    void loadlevel()
    {
        Application.LoadLevel("LevelMenu");        
    }
    public void openSceneLevel()
    {
        //ChangeLevel();
        clicked = true;
        StartCoroutine(WaitAndDo(1, loadlevel));
        
        //Fading.StartScene();
                    
        
    }
    void loadsetting()
    {
        Application.LoadLevel("SettingSene");
    }
    public void openSetting()
    {
        clicked = true;
        StartCoroutine(WaitAndDo(1, loadsetting));      
    }
    void loadwelcome()
    {

        Application.LoadLevel("WelcomeMenu");
    }
    public void openWelcome()
    {
        clicked = true;
        StartCoroutine(WaitAndDo(1, loadwelcome));
    }
    void loadwiki()
    {
        //clicked = true;
        Application.LoadLevel("wiki2");
    }
    public void openWiki()
    {
        clicked = true;
        StartCoroutine(WaitAndDo(1, loadwiki));
    }
    void loadHigh()
    {

        Application.LoadLevel("HighScore");
    }
    public void openHighScore()
    {
        clicked = true;
        StartCoroutine(WaitAndDo(1, loadHigh));
    }
    delegate void DelayedMethod();
    IEnumerator WaitAndDo(float time, DelayedMethod method)
    {
        yield return new WaitForSeconds(time);
        method();
    }
    

}
