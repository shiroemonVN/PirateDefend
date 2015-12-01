using UnityEngine;
using System.Collections;

public class PanelUnSScript : MonoBehaviour {
    public Vector3 originPos;
	// Use this for initialization
	void Start () {
        originPos = transform.position;
        transform.position = new Vector3(-1000f, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (turret.isClicked == true)
        {
            transform.position = originPos;
        }else if (turret.isClicked == false) 
        {
            transform.position = new Vector3(-1000f, transform.position.y, transform.position.z);
        }
	}
    public void Hide()
    {
        transform.position = new Vector3(-1000f, transform.position.y, transform.position.z);
    }
}
