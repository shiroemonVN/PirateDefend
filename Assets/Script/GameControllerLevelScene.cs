using UnityEngine;
using System.Collections;

public class GameControllerLevelScene : MonoBehaviour {
    public static int chosenLevel;
    public static bool clickedLevel = false;
    //public int level;
	// Use this for initialization
	void Start () {
        clickedLevel = false;
	}

    public void setClickedLevel(int level)
    {
        chosenLevel = level;
        if (clickedLevel == false)
        {
            clickedLevel = true;
        }
        else if (clickedLevel == true)
        {
            chosenLevel = 0;
            clickedLevel = false;
        }
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("WelcomeMenu");
	}

    public void PlayGame()
    {
        clickedLevel = !clickedLevel;
        int level = chosenLevel;
        chosenLevel = 0;
        if (level!=0)
        {
            Application.LoadLevel("Level" + level);
        }
    }
}
