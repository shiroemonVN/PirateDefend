using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    Image img;
	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = Camera.main.transform.forward;
	}
}
