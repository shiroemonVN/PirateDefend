using UnityEngine;
using System.Collections;

public class high1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<UnityEngine.UI.Text> ().text = "1st Place " + PlayerPrefs.GetFloat ("HighScore0");
	}
}
