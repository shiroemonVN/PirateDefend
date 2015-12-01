using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {
	void Start () {
		GameObject target = GameObject.Find("Target");
		if(target)
		GetComponent<NavMeshAgent> ().destination= new Vector3 (target.transform.position.x, 3.5f, target.transform.position.z);
	}

}
