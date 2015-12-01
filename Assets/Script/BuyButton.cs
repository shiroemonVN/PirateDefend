using UnityEngine;
using System.Collections;

public class BuyButton : MonoBehaviour {
    public static bool onBuy = false;
	// Use this for initialization
	void Start () {
        //onBuy = false;
	}

    public void setclick(bool toFalse)
    {
        onBuy = toFalse;
        
    }

	// Update is called once per frame
	void Update () {
        //Debug.Log(onBuy);
	}
}
