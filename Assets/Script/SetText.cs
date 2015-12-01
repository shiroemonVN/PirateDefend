using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

	// Use this for initialization
	void Start () {       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setText(string diff)
    {
        gameObject.GetComponent<Text>().text = diff;
    }
}
