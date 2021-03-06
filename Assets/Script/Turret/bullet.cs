﻿using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public bool antiShield;
	public GameObject explosion;
	private GameObject source;
	public GameObject target;
	public float arc;
	public float damage;
	public float speed ;
	public float turnSpeed;
	private float distance;
	private float current;
	private float arcCenter;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().velocity=transform.forward*speed;
        Destroy(gameObject, 7);
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider orther){
		if (orther.GetComponent<Monster> ()) {
			if(antiShield)
			    orther.gameObject.GetComponent<Monster> ().decreaseHealth (0);
			else
				orther.gameObject.GetComponent<Monster> ().decreaseHealth (damage);
			impacted();
		}
		if (orther.GetComponent<Shield> ()) {
			if(antiShield)
			    orther.gameObject.GetComponent<Shield> ().decreaseHp (damage);
			else
				orther.gameObject.GetComponent<Shield> ().decreaseHp (damage/4);
			impacted();
		}
		if(orther.GetComponent<bullet>()){

		}
		if (orther.GetComponent<turret> ()) {

		}

		if (orther.GetComponent<Base> ()) {
			
		}

        //else
        //    impacted();
	}
	void Update () {
		if (target != null && source != null) {
			Vector3 yOTarget = target.transform.position;
			yOTarget.y = 0;
			Vector3 yOGameObject = gameObject.transform.position;
			yOGameObject.y = 0;
			Vector3 yOsource = source.transform.position;
			yOsource.y = 0;
			current = Vector3.Distance (yOTarget, yOGameObject);
			distance = Vector3.Distance (yOTarget, yOsource);
			arcCenter = distance *arc;
			if (current > arcCenter) {
				gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * speed;
			} else {
				var targetRotation = Quaternion.LookRotation (target.transform.position - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
				gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * speed;
			}
		} else
			Invoke ("impacted", 3f);
	}

	public void setTarget(GameObject target){
		this.target = target;
	} 
	public void setSource(GameObject source){
		this.source = source;
	}

	public void impacted(){
		target = null;
		Instantiate (explosion, transform.position, Quaternion.identity);
		gameObject.GetComponent<Collider> ().enabled = false;
		gameObject.GetComponent<Rigidbody> ().detectCollisions = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		Destroy (this.gameObject, 0.5f);
	}
}
