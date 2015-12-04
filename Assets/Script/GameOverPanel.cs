using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour {
    public bool gameover;
    public float speed;
	public float[] highScore=new float[5];
	// Use this for initialization

	public bool checkScore(float score,float[] highScore){
		bool highScored = false;
		for (int i=0; i<highScore.Length; i++) {
			if(score>=highScore[i]){
				highScored=true;
				float temp=highScore[i];
				float tempx;
				for(int j=i+1;j<highScore.Length;j++){
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
		highScore [0] = PlayerPrefs.GetFloat ("HighScore0");
		highScore [1] = PlayerPrefs.GetFloat ("HighScore1");
		highScore [2] = PlayerPrefs.GetFloat ("HighScore2");
		highScore [3] = PlayerPrefs.GetFloat ("HighScore3");
		highScore [4] = PlayerPrefs.GetFloat ("HighScore4");
		for (int i =0; i<5; i++) {
			Debug.Log(highScore[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.health == "0")
        {
			if(checkScore(GameObject.Find("Player").GetComponent<Player>().score,highScore)){
		
			PlayerPrefs.SetFloat("HighScore0",highScore[0]);
			PlayerPrefs.SetFloat("HighScore1",highScore[1]);
			PlayerPrefs.SetFloat("HighScore2",highScore[2]);
			PlayerPrefs.SetFloat("HighScore3",highScore[3]);
			PlayerPrefs.SetFloat("HighScore4",highScore[4]);
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
