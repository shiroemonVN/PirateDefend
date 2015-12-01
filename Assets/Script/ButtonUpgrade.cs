using UnityEngine;
using System.Collections;

public class ButtonUpgrade : MonoBehaviour {
    public static bool isClicked;
    private float timer = 0;
    public float delay = 0.2f;
    public GameObject TheChosen;
	// Use this for initialization
	void Start () {
        isClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        //if (isClicked == true)
        //{
        //    timer += Time.deltaTime;
        //}
        //if (timer >= delay)
        //{
        //    isClicked = false;
        //    timer = 0;
        //}       
	}
    public void setChosenOnject(GameObject gObj)
    {
        TheChosen = gObj;
    }

    public void UpgradeObject()
    {
        if (TheChosen != null)
        {
            if (TheChosen.GetComponent<turret>().nextLv != null)
            {
                TheChosen.GetComponent<turret>().upgrade();
            }
        }
    }
    

    public void setClicked()
    {
        isClicked = true;
        
        //StartCoroutine(WaitAndDo(1,setFalse));
    }
    public void setFalse()
    {
        isClicked = false;
    }
    
}
