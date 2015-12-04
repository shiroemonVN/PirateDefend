using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour {
	private bool setScore=true;
    public bool gameover;
    public float speed;
	private float[] highScore=new float[5];
	// Use this for initialization

	public bool checkScore(float score,float[] highScore){
		bool highScored = false;
		for (int i=0; i<highScore.Length; i++) {
			if(score>=highScore[i]){
				highScored=true;
				float temp;
				float tempx;
				for(int j=i+1;j<highScore.Length;j++){
					temp=highScore[j-1];
					tempx=highScore[j];
					highScore[j]=temp;
					temp=tempx;
				}
				highScore[i]=score;
				break;
			}
		}
		return highScored;
	}

	void Start () {
        gameover = false;
        speed = 5f;
		for (int i =0; i<5; i++) {
			highScore [i] = PlayerPrefs.GetFloat ("HighScore"+i);
			//Debug.Log(highScore[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.health == "0")
        {
			if(setScore){
				setScore=false;
			if(checkScore(GameObject.Find("Player").GetComponent<Player>().score,highScore)){
					for(int i =0;i<highScore.Length;i++){
						PlayerPrefs.SetFloat("HighScore"+i,highScore[i]);
					}
				}
			}

           gameObject.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            if (gameObject.transform.localScale.x >=1 )
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            GameObject[] a = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in a)
            {
                Destroy(enemy);
            }
        }
        }
        
	}
}
