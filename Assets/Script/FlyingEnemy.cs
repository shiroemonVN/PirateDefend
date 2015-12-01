using UnityEngine;
using System.Collections;

public class FlyingEnemy : MonoBehaviour {
	public GameObject target;
	private Vector3 source;
	public float speed ;
	public float turnSpeed;
	private float distance;
	private float current;
	private float arcCenter;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Target").gameObject;
		source = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 yOTarget = target.transform.position;
		yOTarget.y = 0;
		Vector3 yOGameObject = gameObject.transform.position;
		yOGameObject.y = 0;
		Vector3 yOsource = source;
		yOsource.y = 0;

		current = Vector3.Distance (yOsource, yOGameObject);
		distance = Vector3.Distance (yOTarget, yOsource);
		arcCenter = distance *3/ 5;
		if (current >= arcCenter) {
			var targetRotation = Quaternion.LookRotation (target.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
			gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		}else {
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
			gameObject.GetComponent<Rigidbody>().velocity=(yOTarget-yOsource)*0.04f;
		}
	}
}
