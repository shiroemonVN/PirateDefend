using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour {
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
				for(int j=i+1;j<highScore.Length;j++){
					temp=highScore[j];
					highScore[j]=highScore[j-1];
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
		for (int i=0; i<5; i++) {
			highScore [i] = PlayerPrefs.GetFloat ("HighScore" + i + 1);
		}
		for(int i=0;i<highScore.Length;i++){
			Debug.Log (PlayerPrefs.GetFloat("HighScore"+i+1));
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.health == "0")
        {
			if(checkScore(GameObject.Find("Player").GetComponent<Player>().score,highScore)){
				for(int i=0;i<highScore.Length;i++){
					PlayerPrefs.SetFloat("HighScore"+i+1,highScore[i]);
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
