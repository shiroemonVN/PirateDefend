using UnityEngine;
using System.Collections;

public class CannonBallMover : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.up * speed; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
