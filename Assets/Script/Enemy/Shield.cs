using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	public float hp;
	// Use this for initialization
	public void decreaseHp(float damage){
		hp -=damage;
	}
	public void update(){
		if (hp <= 0)
			Destroy (gameObject);
	}
}
