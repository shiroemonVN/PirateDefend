using UnityEngine;
using System.Collections;

public class BuildUpdate : MonoBehaviour {
	public GameObject turret;
	// Use this for initialization
	void OnMouseUpAsButton(){
		GameObject square = GameObject.Find ("Build menu");
		Vector3 position = square.transform.position;
		Instantiate (turret, new Vector3 (position.x, 2, position.z),Quaternion.identity);
		square.transform.position = new Vector3 (0,200,0);
	}
}
