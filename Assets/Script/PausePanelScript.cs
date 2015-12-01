using UnityEngine;
using System.Collections;

public class PausePanelScript : MonoBehaviour {
    public static bool showUp;
    public float speed = 5f;
    public float b = 0.6f;
	// Use this for initialization
	void Start () {
        showUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showUp =!showUp;
        }

        if (showUp == false)
        {
            gameObject.transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, gameObject.transform.localScale.z);        
        }
        if (gameObject.transform.localScale.x < 0.001f)
        {
            gameObject.transform.localScale = new Vector3(0.001f, 0.001f, gameObject.transform.localScale.z);
        }
        if (showUp == true)
        {
            gameObject.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed*Time.deltaTime);
        }
        if (gameObject.transform.localScale.x >= 0.6f)
        {
            gameObject.transform.localScale = new Vector3(0.6f, 0.6f, gameObject.transform.localScale.z);            
        }
        if (gameObject.transform.localScale.x == 0.6f)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
	}
    public void Hide()
    {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, gameObject.transform.localScale.z);        
        showUp = false;
        Time.timeScale = 1;
    }

    public void setTimeScale(int a)
    {
        Time.timeScale = a;
    }
    public void SetScale(float x,float y, float z)
    {
        gameObject.transform.localScale = new Vector3(x, y, z); 
    }
}
