using UnityEngine;
using System.Collections;

public class high5 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<UnityEngine.UI.Text> ().text = "5st Place " + PlayerPrefs.GetFloat ("HighScore4");
	
	}

}
