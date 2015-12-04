using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = "Wave " + (WaveManager.GetWaveStatic() + 1);
	}
}
