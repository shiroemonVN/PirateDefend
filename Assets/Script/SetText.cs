using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("Mode", "EASY");
        print("Easy init");
	}
    public void setText(string diff)
    {
        PlayerPrefs.SetString("Mode", diff);
        print(diff);
        gameObject.GetComponent<Text>().text = diff;
    }
}
