using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	public float health;
	public float score;
	public int gold;
    public float shield;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			sink ();
	}

	void OnTriggerEnter(Collider orther){
		if(orther.GetComponent<Base>()){
			GameObject.Find ("Player").GetComponent<Player> ().hitPoint--;
            WaveManager.SetDeadEnemy(WaveManager.GetDeadEnemy() + 1);
			Destroy(gameObject);
		}
	}

	public void decreaseHealth(float damage){
		health -= damage;
	}

	public void sink(){
		GameObject.Find ("Player").GetComponent<Player> ().addScore (score);
		GameObject.Find ("Player").GetComponent<Player> ().addGold (gold);
        WaveManager.SetDeadEnemy(WaveManager.GetDeadEnemy() + 1);
		Destroy (gameObject);
	}
}
