using UnityEngine;
using System.Collections;

public class ShipSink1 : MonoBehaviour {
    public float down = 5f;
    public float turnSpeed = 50f;
    public static bool isSink = false;
    public GameObject explosion;
    public Quaternion qua;
    public bool a = false;
    public int x, y, z, t = 0;
    // Use this for initialization
    void Start()
    {
        qua = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            doExplosion(explosion);
            isSink = true;
        }
        if (Input.GetKey("up"))
        {
            //explosion.transform.localScale = new Vector3(30, 30, 30);
            print(explosion.transform.localScale);
        }
        if (isSink == true)
        {

            sink();
        }
    }
    void doExplosion(GameObject obj)
    {
        float yPos = transform.position.y+5f;
        Vector3 explosionPos = new Vector3(transform.position.x, yPos, transform.position.z);
        Instantiate(obj, explosionPos, qua);
        obj.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        a = true;

    }
    void sink()
    {
        transform.position -= new Vector3(0, down * Time.deltaTime, 0);
        transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
    }
    delegate void DelayedMethod();
    IEnumerator WaitAndDo(float time, DelayedMethod method)
    {
        yield return new WaitForSeconds(time);
        method();
    }
}
