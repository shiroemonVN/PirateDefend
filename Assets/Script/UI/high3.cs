using UnityEngine;
using System.Collections;

public class high3 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<UnityEngine.UI.Text> ().text = "3st Place " + PlayerPrefs.GetFloat ("HighScore2");
	
	}

}
