using UnityEngine;
using System.Collections;

public class shotMark2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //print(transform.position);
	}
    public void appear()
    {
        transform.position = new Vector3(0, -17f, 85.6f);

    }
}
