using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour
{
    public GameObject explosion;
    // Use this for initialization
    public float speed;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = -transform.right * speed;

    }
    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
