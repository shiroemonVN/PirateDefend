using UnityEngine;
using System.Collections;

public class IsCalled : MonoBehaviour {
    public AudioClip shootSound;
    private AudioSource source;
    public static float speed = 25f;
    public static bool isNotCalled = false;
    public static bool ClickedGun = false;
    public static bool ClickedEnemy = false;
    public static bool ClickedShip = false;
    public static bool onTop = false;
    public static bool isStandStill = true;
    public static bool onGun = true;
    public static bool onEnemy = false;
    public static bool onShip = false;
    public GameObject ButtonItem1;
    public GameObject ButtonItem2;
    public GameObject ButtonItem3;
    public GameObject ButtonItem4;
    public GameObject ButtonItem5;
    public GameObject ButtonItem6;
    public GameObject ButtonItem7;
    public GameObject ButtonItem8;
    public GameObject ButtonItem9;
    public GameObject ButtonItem10;
    public GameObject ButtonItem11;
    public GameObject ButtonItem12;
    public GameObject ButtonItem13;
    public GameObject ButtonItem14;
    public GameObject ButtonItem15;
    public GameObject ButtonItem16;
    private GameObject[] foundClone;
    private GameObject[] foundButtonGun;
    private GameObject[] foundButtonEnemy;
    private GameObject[] foundButtonShip;
    private Vector3[] originPos;
    private float[] HidenPosY;
    //private RectTransform rect;
	// Use this for initialization
    

	// Update is called once per frame
    void Start()
    {
        source = GetComponent<AudioSource>();
        originPos = new Vector3[16];
        HidenPosY = new float[16];
        foundButtonGun = GameObject.FindGameObjectsWithTag("GunButton");
        if (foundButtonGun.Length > 0)
        {
            int x = 0;
            foreach (GameObject button in foundButtonGun)
            {
                
                originPos[x] = button.transform.position;
                HidenPosY[x] = button.transform.position.y-300f;
                //print("origin" + originPos[x]);
                x++;
            }
            
        }
    }
    void showButtonGun() {
        foundButtonGun = GameObject.FindGameObjectsWithTag("GunButton");
        if (foundButtonGun.Length > 0)
        {
            int x = 0;
            //print(foundButtonGun.Length.ToString());
            foreach (GameObject button in foundButtonGun)
            {               
                //button.SetActive(true);
                
                button.transform.position = originPos[x];
                x++;
            }
        }
    }
    void hideButtonGun()
    {
        foundButtonGun = GameObject.FindGameObjectsWithTag("GunButton");
        if (foundButtonGun.Length > 0)
        {
            int x = 0;
            foreach (GameObject button in foundButtonGun)
            {
                //button.SetActive(false);
                
                button.transform.position = new Vector3(button.transform.position.x, HidenPosY[x], transform.position.z);
                x++;
            }
        }
    }
    void showButtonEnemy()
    {
        
            foundButtonEnemy = GameObject.FindGameObjectsWithTag("EnemyButton");
            if (foundButtonEnemy.Length > 0)
            {
                int x = 0;
                foreach (GameObject button in foundButtonEnemy)
                {
                    //button.SetActive(true);
                    
                    button.transform.position = originPos[x];
                    x++;
                }
            }
        
    }
    void hideButtonEnemy()
    {

        foundButtonEnemy = GameObject.FindGameObjectsWithTag("EnemyButton");
        if (foundButtonEnemy.Length > 0)
        {
            int x = 0;
            foreach (GameObject button in foundButtonEnemy)
            {
                //button.SetActive(false);
                
                button.transform.position = new Vector3(button.transform.position.x, HidenPosY[x], transform.position.z);
                x++;
            }
        }

    }
    void showButtonShip()
    {
        foundButtonShip = GameObject.FindGameObjectsWithTag("ShipButton");
        if (foundButtonShip.Length > 0)
        {
            int x = 0;
            foreach (GameObject button in foundButtonShip)
            {
                //button.SetActive(true);
                
                button.transform.position = originPos[x];
                x++;
            }
        }
    }
    void hideButtonShip()
    {
        foundButtonShip = GameObject.FindGameObjectsWithTag("ShipButton");
        if (foundButtonShip.Length > 0)
        {
            int x = 0;
            foreach (GameObject button in foundButtonShip)
            {
                //button.SetActive(false);
                
                button.transform.position = new Vector3(button.transform.position.x, HidenPosY[x], transform.position.z);
                x++;
            }
        }
    }

    void Update()
    {        
        //print(transform.position.y);
        if (onGun == true && isStandStill == true)
        {
            showButtonGun();
            print("ShowGun");
        }
        if (onGun != true || isStandStill != true)
        {
            hideButtonGun();
            print("hideGun");
        }
        if (onEnemy == true && isStandStill == true)
        {
            showButtonEnemy();
            print("show Enemy");
        }
        if (onEnemy != true || isStandStill != true)
        {
            hideButtonEnemy();
            print("hide Enemy");
        }
        if (onShip == true && isStandStill == true)
        {
            showButtonShip();
            print("Show ship");
        }
        if (onShip != true || isStandStill != true)
        {
            hideButtonShip();
            print("hide ship");
        }
        if (ClickedGun == false && ClickedEnemy == false && ClickedShip == true)
        {
            isStandStill = false;
            onGun = false;
            onShip = true;
            onEnemy = false;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            
            //print(transform.position.y);          
        }
        if (ClickedGun == false && ClickedEnemy == true && ClickedShip == false)
        {
            isStandStill = false;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            onGun = false;
            onShip = false;
            onEnemy = true;
            
            //print(transform.position.y);          
        }
        if (ClickedGun == true && ClickedEnemy == false && ClickedShip == false)
        {
            isStandStill = false;
            onGun = true;
            onShip = false;
            onEnemy = false;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            
            //print(transform.position.y);          
        }
        if (transform.position.y >8.5f)
        {
            onTop = true;
            ClickedGun = false;
            ClickedEnemy = false;
            ClickedShip = false;
            //transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (ClickedGun == false && ClickedEnemy == false && ClickedShip == false && onTop == false)
        {
           
        }
        if (ClickedGun == false && ClickedEnemy == false && ClickedShip == false && onTop == true)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            if (transform.position.y < -3.123059)
            {
                onTop = false;
                transform.position = new Vector3(transform.position.x, -3.123059f, transform.position.z);
                isStandStill = true;              
                
                //ButtonItem1.SetActive(true);
                //ButtonItem2.SetActive(true);
                //ButtonItem3.SetActive(true);
                //ButtonItem4.SetActive(true);
                //ButtonItem5.SetActive(true);
                //ButtonItem6.SetActive(true);
                //ButtonItem7.SetActive(true);
                //ButtonItem8.SetActive(true);
                //ButtonItem9.SetActive(true);
                //ButtonItem10.SetActive(true);
                //ButtonItem11.SetActive(true);
                //ButtonItem12.SetActive(true);
                //ButtonItem13.SetActive(true);
                //ButtonItem14.SetActive(true);
                //ButtonItem15.SetActive(true);
                //ButtonItem16.SetActive(true);
            }
        }
    }
    public static void setIsClicked(bool x)
    {
        isNotCalled = x;
    }    
    public  void ClickedOnGun()
    {
        ClickedGun = true;
        ClickedEnemy = false;
        ClickedShip = false;
        foundClone = GameObject.FindGameObjectsWithTag("Clone");
        if (foundClone.Length > 0)
        {
            foreach (GameObject clone in foundClone)
            {
                Destroy(clone);
            }
        }
        print("Gun");
    }
    public  void ClickedOnEnemy()
    {
        ClickedGun = false;
        ClickedEnemy = true;
        ClickedShip = false;
        foundClone = GameObject.FindGameObjectsWithTag("Clone");
        if (foundClone.Length > 0)
        {
            foreach (GameObject clone in foundClone)
            {
                Destroy(clone);
            }
        }
        print("Enemy");
    }
    public  void ClickedOnShip()
    {
        ClickedGun = false;
        ClickedEnemy = false;
        ClickedShip = true;
        foundClone = GameObject.FindGameObjectsWithTag("Clone");
        if (foundClone.Length > 0)
        {
            foreach (GameObject clone in foundClone)
            {
                Destroy(clone);
            }
        }
        print("Ship");
    }
    public void PlaySound()
    {
        source.PlayOneShot(shootSound, 1f);
    }
}
