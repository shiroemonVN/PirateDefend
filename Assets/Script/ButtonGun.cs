using UnityEngine;
using System.Collections;

public class ButtonGun : MonoBehaviour {
    public static bool isClicked = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //print(isClicked);
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    setIsClicked(true);
        //}
	}
    public static void setIsClicked(bool x)
    {
        isClicked =x;
        //print(isClicked);

    }
    
}
