using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour
{
    public float force = 200f;
    public float reforce = 10f;
    public Animator anim;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //anim.Play("Fire!");
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            transform.Translate(Vector3.right * force *Time.deltaTime);

        }
        else if (Time.time <= nextFire)
        {
            float reforceOnLoop = reforce;

            if (Vector3.right * force * Time.deltaTime == Vector3.right * reforceOnLoop * Time.deltaTime)
            {
                reforceOnLoop = 0f;              
            }
            else { transform.Translate(-Vector3.right * reforceOnLoop * Time.deltaTime);}

        }
    }
}
