using UnityEngine;
using System.Collections;

public class PickDiff : MonoBehaviour {
    public float speed = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameControllerLevelScene.clickedLevel == false)
        {
            gameObject.transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, gameObject.transform.localScale.z);
        }
        if (gameObject.transform.localScale.x < 0.001f)
        {
            gameObject.transform.localScale = new Vector3(0.001f, 0.001f, gameObject.transform.localScale.z);
        }
        if (GameControllerLevelScene.clickedLevel == true)
        {
            gameObject.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, gameObject.transform.localScale.z);
        }
        if (gameObject.transform.localScale.x > 1f)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, gameObject.transform.localScale.z);
        }
	}
}
