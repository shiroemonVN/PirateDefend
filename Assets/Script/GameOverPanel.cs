using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour {
    public bool gameover;
    public float speed;
	// Use this for initialization
	void Start () {
        gameover = false;
        speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.health == "0")
        {
            
           gameObject.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            if (gameObject.transform.localScale.x >=1 )
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            GameObject[] a = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in a)
            {
                Destroy(enemy);
            }
        }
        }
        
	}
}
