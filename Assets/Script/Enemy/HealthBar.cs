using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public int Health;
    TextMesh tm;
	// Use this for initialization
	void Start () {
        tm = GetComponent<TextMesh>();
        tm.text = "-";
        for(int i=1; i<Health/10;i++)
        {
            tm.text.Insert(tm.text.Length,"-");
            tm.text += "-";
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = Camera.main.transform.forward;
	}
    
    public int current()
    {
        return tm.text.Length;
    }
    public int currentHealth()
    {
        return Health;
    }
    // Decrease the current Health by removing one '-'
    public void decrease()
    {
        Health = Health - 1;
        if (current() > 1 && Health % 10 == 0)
        {
            tm.text = tm.text.Remove(tm.text.Length - 1);
            if (current() == 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }    
    }
}
