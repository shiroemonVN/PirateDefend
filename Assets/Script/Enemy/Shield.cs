using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	public float hp;
	// Use this for initialization
	public void decreaseHp(float damage){
		hp -=damage;
	}
	void Update(){
		if (hp <= 0) {
			Debug.Log(hp);
			Destroy (gameObject);
		}
	}
}
