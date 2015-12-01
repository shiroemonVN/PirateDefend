using UnityEngine;
using System.Collections;

public class indicatorScript : MonoBehaviour {
    public static Vector3 pos;
	// Use this for initialization
	void Start () {
        pos = new Vector3(100f, 100f, 100f);
        //transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = pos;
	}
}
