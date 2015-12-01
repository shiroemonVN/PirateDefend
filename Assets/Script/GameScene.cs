using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void loadlevel()
    {
        Application.LoadLevel("LevelMenu");
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuScript.clicked = true;
            StartCoroutine(WaitAndDo(1, loadlevel)); 
        }
            //Application.LoadLevel("LevelMenu");

	}
    delegate void DelayedMethod();
    IEnumerator WaitAndDo(float time, DelayedMethod method)
    {
        yield return new WaitForSeconds(time);
        method();
    }
}
