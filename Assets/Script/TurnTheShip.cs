using UnityEngine;
using System.Collections;

public class TurnTheShip : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public int turnDeg = 0;
    public float TurnSpeed = 50f;
    int CurrentState = 0;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        
        if (turnDeg<110)
        {
            transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
            turnDeg++;
            //anim.Play("PirateShipTurnRight");
            //this.transform.Rotate(0, 90.0f, 0, Space.Self);
            //anim.Play("OpenTrap",-1,0f);
            /*print(Time.deltaTime);
            if ( anim.GetCurrentAnimatorStateInfo(0).normalizedTime >1 && anim.IsInTransition(0))
            {
                print("2");
                
                
                
            }*/
        }
    }
}
