using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetailOfItem : MonoBehaviour {
    public static int Damage = 0;
    public static int Speed = 0;
    public static int Range = 0;
    public static int Shield = 0;
    public static string NameOfItem = null;
    public static int Level = 0;
	// Use this for initialization
    private GameObject nameblank;
    private GameObject damageblank;
    private GameObject speedblank;
    private GameObject rangeblank;
    private GameObject shieldblank;
    private GameObject levelblank;
    public static bool RunLevelFinished = false;
    public static bool RunShieldFinished = false;
    public static bool RunDamageFinished = false;
    public static bool RunSpeedFinished = false;
    public static bool RunRangeFinished = false;
	void Start () {
        nameblank = GameObject.Find("name");
       
	}
	
	// Update is called once per frame
	void Update () {
        if (NameOfItem != null)
        {
            setName(NameOfItem);
        } 
        if (Damage>0)
        {            
            setDamage(Damage);
        }
        if (Damage == 0)
        {

        }
        if (Speed > 0)
        {
            setSpeed(Speed);
        }
        if (Speed == 0)
        {

        }
        if (Range>0)
        {
            setRange(Range);
        }
        if (Range == 0)
        {

        }
        if (Shield > 0)
        {
            setShield(Shield);
        }
        if (Shield == 0)
        {

        } if (Level > 0)
        {
            setLevel(Level);
        }
        if (Level == 0)
        {

        }
	}
    void setName(string name){
        if (nameblank != null)
        {
            nameblank.GetComponent<Text>().text = name;
        }
    }

    void setShield(int shield)
    {
        if (shield > 0 && RunShieldFinished == false)
        {
            for (int i = 1; i <= shield; i++)
            {
                string nameOfDecal = "s" + i;
                shieldblank = GameObject.Find(nameOfDecal);
                print(nameOfDecal);
                //shieldblank.SetActive(true);
                shieldblank.GetComponent<RawImage>().color = new Color(0, 255f, 255f, 255f);
            }
        }
        if (shield < 8 && shield > 0 && RunShieldFinished == false)
        {
            for (int j = shield + 1; j <= 8; j++)
            {
                string nameOfDecal = "s" + j;
                shieldblank = GameObject.Find(nameOfDecal);
                //shieldblank.SetActive(false);
                shieldblank.GetComponent<RawImage>().color = new Color(0, 255f, 255f, 0);
            }
            RunShieldFinished = true;

        }
    }


    void setLevel(int level)
    {
        if (level > 0 && RunLevelFinished == false)
        {
            for (int i = 1; i <= level; i++)
            {
                string nameOfDecal = "Skull" + i;
                levelblank = GameObject.Find(nameOfDecal);
                //print(nameOfDecal);
                //shieldblank.SetActive(true);
                levelblank.GetComponent<RawImage>().color = new Color(0, 0, 255f, 255f);
            }
        }
        if (level < 3 && level > 0 && RunLevelFinished == false)
        {
            for (int j = level + 1; j <= 3; j++)
            {
                string nameOfDecal = "Skull" + j;
                levelblank = GameObject.Find(nameOfDecal);
                //shieldblank.SetActive(false);
                levelblank.GetComponent<RawImage>().color = new Color(0, 0, 255f, 0);
            }
            RunLevelFinished = true;
        }
    }


    void setRange(int range)
    {
        if (range > 0 && RunRangeFinished == false)
        {
            for (int i = 1; i <= range; i++)
            {
                string nameOfDecal = "r" + i;
                rangeblank = GameObject.Find(nameOfDecal);
                //print(nameOfDecal);
                //rangeblank.SetActive(true);
                rangeblank.GetComponent<RawImage>().color = new Color(255f, 255f, 255f, 255f);
            }
        }
        if (range < 8 && range > 0 && RunRangeFinished == false)
        {
            for (int j = range + 1; j <= 8; j++)
            {
                string nameOfDecal = "r" + j;
                rangeblank = GameObject.Find(nameOfDecal);
                //rangeblank.SetActive(false);
                rangeblank.GetComponent<RawImage>().color = new Color(255f, 255f, 255f, 0);
            }
            RunRangeFinished = true;

        }
    }
    void setSpeed(int speed)
    {
        if (speed > 0 && RunSpeedFinished == false)
        {
            for (int i = 1; i <= speed; i++)
            {
                string nameOfDecal = "l" + i;
                speedblank = GameObject.Find(nameOfDecal);
                //print(nameOfDecal);
                speedblank.GetComponent<RawImage>().color = new Color(0, 255f, 255f, 255f);
                //speedblank.SetActive(true);
            }
        }
        if (speed < 8 && speed > 0 && RunSpeedFinished == false)
        {
            for (int j = speed + 1; j <= 8; j++)
            {
                string nameOfDecal = "l" + j;
                speedblank = GameObject.Find(nameOfDecal);
                speedblank.GetComponent<RawImage>().color = new Color(0, 255f, 255f, 0);
                //speedblank.SetActive(false);
            }
            RunSpeedFinished = true;

        }
    }

    void setDamage(int damage){
        if (damage > 0 && RunDamageFinished == false)
        {
            for (int i = 1; i <= damage; i++)
            {
                string nameOfDecal = "d" + i;
                damageblank = GameObject.Find(nameOfDecal);
                //print(nameOfDecal);
                damageblank.GetComponent<RawImage>().color = new Color(0, 255f, 255f, 255f);
            }
        }
        if (damage < 8 && damage > 0 && RunDamageFinished==false)
        {
            for (int j = damage + 1; j <= 8; j++)
            {
                string nameOfDecal = "d" + j;
                damageblank = GameObject.Find(nameOfDecal);
                damageblank.GetComponent<RawImage>().color = new Color(0, 255f, 255f, 0);
                //damageblank.SetActive(false);
            }
            RunDamageFinished = true;

        }
    }
}
