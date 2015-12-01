using UnityEngine;
using System.Collections;

public class Hinden : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {        
        if (IsCalled.isStandStill == false)
        {
            gameObject.SetActive(false);
        }
	}
}
