using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHealthScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = Player.health;
	}
}
