using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour {
    public float damage;
    public GameObject explosion;
    public int cost;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -10f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
        }
	}
    void OnTriggerEnter(Collider orther)
    {
        if (orther.GetComponent<Monster>())
        {
            orther.gameObject.GetComponent<Monster>().decreaseHealth(damage);
            impacted();
        }
        if (orther.GetComponent<bullet>())
        {

        }
        if (orther.GetComponent<turret>())
        {

        }

        if (orther.GetComponent<Base>())
        {

        }
    }
    public void impacted()
    {        
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Destroy(this.gameObject);
    }
}
