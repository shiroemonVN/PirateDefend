using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int hitPoint;
	public int gold;
	public float score;
    public int wave;
    public  static GameObject ChosenItem;
    public static string coin;
    public static string health;
    public static string waveString;
    public static string scoreString;
    public SaveLoadManager SLManager;
	// Use this for initialization
	void Start () {
        //SLManager = GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>();
        //if (SLManager!=null)
        //{
        //    SLManager.LoadGame();
        //}
        ////SLManager.LoadGame();
        //if (SLManager.GetLoadedData()!= null)
        //{
        //    //gold = SLManager.GetLoadedData().Money;
        //    score = SLManager.GetLoadedData().Score;
        //}
        //else
        //{
        //    score = 0;
        //}
        //int storedGold = PlayerPrefs.GetInt("Money", 0);
        //Debug.Log(storedGold);
        //gold += storedGold;
        //Debug.Log(gold);

        score = 0;
        health = hitPoint.ToString();
        coin = gold.ToString();
        scoreString = score.ToString();
        //waveString = wave.ToString();
	}
	// Update is called once per frame
	void Update () {
		if (hitPoint <= 0) {
			GameObject.Find("Target").GetComponent<Rigidbody>().useGravity=true;
            //Debug.Log("Game Over");
		}
        coin = gold.ToString();
        health = hitPoint.ToString();
        scoreString = score.ToString();
	}
    public void SetChosenItem(GameObject obj)
    {
        ChosenItem = obj;
    }

	public void addScore(float score){
		this.score += score;
	}

	public void addGold(int gold){
		this.gold += gold;
	}
}
