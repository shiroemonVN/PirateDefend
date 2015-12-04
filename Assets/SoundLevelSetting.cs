using UnityEngine;
using System.Collections;

public class SoundLevelSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float s = PlayerPrefs.GetFloat("SoundVolume");
        GetComponent<AudioSource>().volume = s;
	}
}
