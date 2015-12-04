using UnityEngine;
using System.Collections;

public class high4 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<UnityEngine.UI.Text> ().text = "4st Place " + PlayerPrefs.GetFloat ("HighScore3");
	
	}

}
