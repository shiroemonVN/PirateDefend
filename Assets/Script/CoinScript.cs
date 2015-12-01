using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
    public float speedRotate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right, speedRotate * Time.deltaTime);
	}
}
