using UnityEngine;
using System.Collections;

public class ItemOfButton : MonoBehaviour {

    public GameObject model;
    private GameObject[] foundClone;
    public Transform pos;
    public float x, y, z;
    public float a, b, c;
    public float i, j, k;
    private GameObject obj1;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj1 = GameObject.Find("Preview Pirate Ship2(Clone)");
        if (obj1 != null)
        {

            obj1.transform.Rotate(Vector3.forward, 30*Time.deltaTime);
            //obj.transform.rotation = new Vector3(270f, 172f, 30 * Time.deltaTime);
        }

    }
    public void isClickedButton()
    {
        foundClone = GameObject.FindGameObjectsWithTag("Clone");
        if (foundClone.Length > 0)
        {
            foreach (GameObject clone in foundClone)
            {
                Destroy(clone);
            }
        }
        //a.transform.position = new Vector3(-1.36f, -2.05f, -5.5f);
        GameObject obj = Instantiate(model, pos.position, pos.rotation) as GameObject;
        obj.transform.localScale = new Vector3(a, b, c);
        obj.transform.position = new Vector3(x, y, z);
        obj1 = GameObject.Find("Preview Pirate Ship2(Clone)");
        if (obj1 != null   )
        {
            
                obj1.transform.Rotate(Vector3.right, 270f);
                //obj.transform.rotation = new Vector3(270f, 172f, 30 * Time.deltaTime);
            
        }
        DetailOfItem.NameOfItem = obj.GetComponent<property>().NameOfIt;
        DetailOfItem.Damage = obj.GetComponent<property>().DamageOfItem;
        DetailOfItem.Speed = obj.GetComponent<property>().SpeedOfItem;
        DetailOfItem.Range = obj.GetComponent<property>().RangeOfItem;
        DetailOfItem.Shield = obj.GetComponent<property>().ShieldOfItem;
        DetailOfItem.Level = obj.GetComponent<property>().LevelOfItem;
        DetailOfItem.RunDamageFinished = false;
        DetailOfItem.RunRangeFinished = false;
        DetailOfItem.RunShieldFinished = false;
        DetailOfItem.RunSpeedFinished = false;
        DetailOfItem.RunLevelFinished = false;
    }
}
