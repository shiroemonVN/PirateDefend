using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
    Animator anim;
	// Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    //void FixedUpdate()
    //{
    //    Animating();
    //}
    void Update()
    {
        Animating();
    }
    void OnTriggerEnter(Collider co)
    {
        if (co.name == "Target")
        {
            //co.GetComponentInChildren<HealthBar>().decrease();
            Destroy(gameObject);
        }
    }
    void Animating()
    {
        bool walking = true;
        anim.SetBool("IsWalking", walking);
    }
}
