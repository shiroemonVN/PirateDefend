using UnityEngine;
using System.Collections;

public class WinnerPanelScript : MonoBehaviour {
    public static bool showUp;
    public float speed = 5f;
    public float b = 0.6f;
    public WaveManager wave;
    public int nextScene;
	// Use this for initialization
	void Start () {
        showUp = false;
        wave = GameObject.Find("WaveManager").GetComponent<WaveManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (wave.GetEndWave() && Player.health !="0")
        {
            showUp = !showUp;
        }
        if (showUp == true)
        {
            gameObject.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        }
        if (gameObject.transform.localScale.x >= 1f)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (showUp == false)
        {
            gameObject.transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        }
        if (gameObject.transform.localScale.x < 0.001f)
        {
            gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        }
	}

    public void LoadNextLevel(int x)
    {
        string level;
        if (x == 0)
        {
            level = "LevelMenu";
        }
        else
        {
            level = "Level" + x;
        }
        Application.LoadLevel(level);
    }
}
