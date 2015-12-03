using UnityEngine;
using System.Collections;

public class NoiceScript : MonoBehaviour {
    public Vector3 originPos;
    public Vector3 leftPos;
    public float slideSpeed = 100f;
    public static bool tellPlayer = false;
    public float a = 0;
	// Use this for initialization
	void Start () {        
        gameObject.transform.localPosition= originPos;
        gameObject.transform.localPosition = new Vector3(-420f, 610f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (tellPlayer == true)
        {
            gameObject.transform.localPosition = originPos;
            a += a+Time.deltaTime;
            print(a);
        }
        if (a >= 100000)
        {
            tellPlayer = false;
            gameObject.transform.localPosition = new Vector3(-420f, 610f, 0);
            a = 0;
        }
      
	}
    private void SetFalse()
    {
        tellPlayer = false;
    }
    public void test()
    {
        print("here");
    }
    public void RunIt()
    {
        tellPlayer = true;
        WaitAndDo(1, test);

    }
    delegate void DelayedMethod();
    IEnumerator WaitAndDo(float time, DelayedMethod method)
    {
        yield return new WaitForSeconds(time);
        method();
    }
}
