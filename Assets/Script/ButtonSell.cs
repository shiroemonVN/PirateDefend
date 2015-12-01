using UnityEngine;
using System.Collections;

public class ButtonSell : MonoBehaviour {
    public GameObject TheChosen;
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
    public void SellItem()
    {
        Debug.Log("sell");
        if (TheChosen != null)
        {
            print("sell");
            
                GameObject.Find("Player").GetComponent<Player>().addGold(TheChosen.GetComponent<turret>().cost*3/4);               
                TheChosen.GetComponent<turret>().setIsClicked(false);                
                Destroy(TheChosen);
            
        }
    }
}
