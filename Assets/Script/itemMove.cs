using UnityEngine;
using System.Collections;

public class itemMove : MonoBehaviour {
    private Vector3 originPos;
    public float speedSlide = 500f;
	// Use this for initialization
	void Start () {
        //Debug.Log(originPos);
        originPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (BuyButton.onBuy == true)
        {
            gameObject.transform.position += new Vector3(speedSlide * Time.deltaTime, 0, 0);
        }

        if (gameObject.transform.position.x > originPos.x)
        {
            gameObject.transform.position = originPos;
        }

        if (BuyButton.onBuy == false)
        {
            gameObject.transform.position -= new Vector3(speedSlide * Time.deltaTime, 0, 0);
           
        }
        if (gameObject.transform.position.x < -150)
        {
            gameObject.transform.position = new Vector3(-150f, 0, 0);
        }
	}


}
