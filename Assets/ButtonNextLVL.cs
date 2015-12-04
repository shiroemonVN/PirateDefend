using UnityEngine;
using System.Collections;

public class ButtonNextLVL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadNextLevel(int level)
    {
        if (level == 0 || level == null)
        {
            Application.LoadLevel("HighScore");
        }
        else   Application.LoadLevel("Level"+level);
    }

}
