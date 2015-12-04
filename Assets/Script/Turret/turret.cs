using UnityEngine;
using System.Collections;

public class turret : MonoBehaviour {
    public bool antiAir;
	public bool antiGround;
	public int barels;
	public int cost;
	public GameObject appearEfect;
	public GameObject nextLv;
	public GameObject bullet;
	public float range;
	public float cooldown;
	public float lastShot;
	private bool lockOn =false;
	private GameObject enemy;
	private GameObject head;
	private GameObject[] barrel;
    public static bool isClicked;
    public static bool isUpraded;
    public bool fired = false;
   
	void Start(){
		GameObject temp=(GameObject)Instantiate (appearEfect,transform.position,Quaternion.identity);
		Destroy (temp, 5);
        isClicked = false;
        isUpraded = false;
		barrel = new GameObject[barels];
		head =gameObject.transform.Find("HeadControll").gameObject;
		GameObject headControll =head.transform.Find("Head").gameObject;
		for (int i=0; i<barels; i++) {
			barrel [i] = headControll.transform.Find ("Barrel" + i).gameObject;
		}
        //Debug.Log(this.nextLv);
	}
	
	void Update(){

        //if (ButtonUpgrade.isClicked == true)
        //{          
        //    upgrade();
        //    ButtonUpgrade.isClicked = false;
        //}


        if (lockOn == false)
        {
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, range);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (antiAir&&!antiGround)
                {
                    if (hitColliders[i].GetComponent<FlyingEnemy>())
                    {
                        enemy = hitColliders[i].gameObject;
                        lockOn = true;
                        break;
                    }
                    else
                        i++;
                    
                }
				if(antiGround&&!antiAir){
                if (hitColliders[i].GetComponent<Monster>() && !hitColliders[i].GetComponent<FlyingEnemy>())
                {
                    enemy = hitColliders[i].gameObject;
                    lockOn = true;
                    break;
                }
                else
                    i++;
				}
				if(antiGround&&antiAir){
					if (hitColliders[i].GetComponent<Monster>())
					{
						enemy = hitColliders[i].gameObject;
						lockOn = true;
						break;
					}
					else
						i++;
				}
			}
        }
		if (lockOn == true) {
			if(enemy==null){
				lockOn=false;
			}
			else{
				Vector3 lookPos=enemy.transform.position-head.transform.position;
				lookPos.y=0;
				Quaternion rotation=Quaternion.LookRotation(lookPos);
			    head.transform.rotation=Quaternion.Slerp(transform.rotation,rotation,1);
			    fire();
			    float distance =Vector3.Distance(enemy.transform.position,gameObject.transform.position);
			    if(distance>range){
				    lockOn=false;}
			}
		}
	}

	void fire(){
        fired = true;
		if (Time.time > cooldown + lastShot) {
			for(int i=0;i<barrel.Length;i++){
				GameObject instance=(GameObject)Instantiate(bullet,barrel[i].transform.position,barrel[i].transform.rotation);
				instance.GetComponent<bullet>().setTarget(enemy);
				instance.GetComponent<bullet>().setSource(gameObject);
			}
				lastShot = Time.time;
			}
	}

    void OnMouseDown()
    {
        isClicked = true;
        GameObject.Find("ButtonUpgrade").gameObject.GetComponent<ButtonUpgrade>().setChosenOnject(gameObject);
        GameObject.Find("ButtonSell").gameObject.GetComponent<ButtonSell>().setChosenOnject(gameObject);
        GameObject.Find("ButtonUndo").gameObject.GetComponent<ButtonUndo>().setChosenOnject(gameObject);
        
    }
	void OnMouseUpAsButton(){
		//GameObject.Find ("UIController").gameObject.GetComponent<GUIController1> ().setChosenTurret (gameObject);
	}

    public void setIsClicked(bool a)
    {
        isClicked = a;
    }

	public void upgrade(){
    //    if (nextLv != null) {
    //        GameObject placeHolder =(GameObject)Instantiate (nextLv, new Vector3(transform.position.x,5,transform.position.z), Quaternion.identity);
    //        if(GameObject.Find("Player").GetComponent<Player>().gold-placeHolder.GetComponent<turret>().cost<0){
    //            Destroy (placeHolder);
    //            Debug.Log("Not enough gold");
    //        }
    //        else{
    //            GameObject.Find("Player").GetComponent<Player>().addGold(-placeHolder.GetComponent<turret>().cost);
    //            Destroy(gameObject);
    //        }
    //}
        Debug.Log(nextLv);
        if (nextLv != null&& GameObject.Find("Player").GetComponent<Player>().gold-nextLv.GetComponent<turret>().cost>=0)
        {
            Instantiate(nextLv, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), transform.rotation);
            GameObject.Find("Player").GetComponent<Player>().addGold(-1 * nextLv.GetComponent<turret>().cost);
            GameObject.Find("SFX").GetComponent<SFXManager>().UpgradeComplete();
            Destroy(gameObject);
        }
        //else Debug.Log("Cant upgrade");
    }

    public void UnDo()
    {

    }
}
