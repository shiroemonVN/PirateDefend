using UnityEngine;
using System.Collections;

public class ButtonMove : MonoBehaviour {
    public GameObject TheChosen;
    public float upSpeed = 50f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setChosenOnject(GameObject gObj)
    {
        TheChosen = gObj;
    }
    public void MoveItem()
    {
        if (TheChosen != null)
        {
            TheChosen.transform.position = new Vector3(TheChosen.transform.position.x, TheChosen.transform.position.y + upSpeed * Time.deltaTime, TheChosen.transform.position.z);
        }
    }
}
