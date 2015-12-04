using UnityEngine;
using System.Collections;

public class high2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<UnityEngine.UI.Text> ().text = "2st Place " + PlayerPrefs.GetFloat ("HighScore1");
	
	}

}
