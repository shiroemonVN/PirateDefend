using UnityEngine;
using System.Collections;

public class ItemGun8 : MonoBehaviour {

    public GameObject model;
    private GameObject[] foundClone;
    public Transform pos;
    public float x, y, z;
    public float a, b, c;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void isClickedItem()
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
        obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        obj.transform.position = new Vector3(-1.36f, -1.64f, -5.5f);
        DetailOfItem.NameOfItem = "Cannon #3";
        DetailOfItem.Damage = 7;
        DetailOfItem.Speed = 2;
        DetailOfItem.Range = 3;
        DetailOfItem.Shield = 1;
        DetailOfItem.Level = 2;
        DetailOfItem.RunDamageFinished = false;
        DetailOfItem.RunRangeFinished = false;
        DetailOfItem.RunShieldFinished = false;
        DetailOfItem.RunSpeedFinished = false;
        DetailOfItem.RunLevelFinished = false;
    }
}
