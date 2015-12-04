using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerSettingScene : MonoBehaviour {

    
	// Use this for initialization
	void Start()
    {
        float s = PlayerPrefs.GetFloat("SoundVolume", 0f);
        GameObject sound = GameObject.Find("SliderSound");
        sound.GetComponent<Slider>().value = s;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("WelcomeMenu");
	}

    public void ChangeSound()
    {
        float a = 0.0f;
        GameObject sound = GameObject.Find("SliderSound");
        a = sound.GetComponent<Slider>().value;
        //print(a);
        PlayerPrefs.SetFloat("SoundVolume", a);
    }
}
