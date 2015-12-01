using UnityEngine;
using System.Collections;

public class square : MonoBehaviour {
    public float HeightOfRay = 100f;
    public Object ObjOnThisGround;
    public bool isFull = false;
    void OnMouseDown()
    {
        //Vector3 mouseWorldPos3D = Camera.main.wo(Input.mousePosition);
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.up);

        Debug.DrawRay(transform.position, Vector3.up * HeightOfRay);

        indicatorScript.pos =  new Vector3(transform.position.x, 10f, transform.position.z);

        //Debug.Log(gameObject.tag);
        if (gameObject.tag == "OnRock" && Player.ChosenItem != null && isFull == false)
        {
            if (GameObject.Find("Player").GetComponent<Player>().gold - Player.ChosenItem.GetComponent<turret>().cost >= 0)
            {
                ObjOnThisGround = Instantiate(Player.ChosenItem, new Vector3(transform.position.x, 5f, transform.position.z), transform.rotation);
                //GameObject.Find("Player").GetComponent<Player>().addScore(-1*Player.ChosenItem.GetComponent<turret>().cost);
                GameObject.Find("Player").GetComponent<Player>().addGold(-1 * Player.ChosenItem.GetComponent<turret>().cost);
                Player.ChosenItem = null;
            }
            else if (GameObject.Find("Player").GetComponent<Player>().gold - Player.ChosenItem.GetComponent<turret>().cost < 0)
            {
                GameObject.Find("SFX").GetComponent<SFXManager>().CannotPurchase();
                turret.isClicked = false;
            }
        }
        else
        {
            turret.isClicked = false;
        }
        if (ObjOnThisGround != null && isFull ==true)
        {            
            //Destroy(ObjOnThisGround);
        }
        

    }
	void OnMouseUpAsButton(){

		//GameObject.Find ("UIController").GetComponent<GUIController1> ().setSquare (gameObject);
		//GameObject buildMenu = GameObject.Find ("Build menu");
	}
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
        }
    }
}
