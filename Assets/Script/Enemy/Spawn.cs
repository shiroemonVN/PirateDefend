using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	private GameObject[] enemy;
    public GameObject[] enemyEasy;
    public GameObject[] enemyNormal;
    public GameObject[] enemyHard;
	public float interval=6f;
    private float modifyableInterval = 0f;
    public WaveManager waveManager;
    public bool first;
    private string difficult;
	// Use this for initialization
	void Start () {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        difficult = Camera.main.GetComponent<GameMode>().GetGameMode();
        //Debug.Log(difficult);
        enemy = new GameObject[] { };
        modifyableInterval = interval;
        switch(difficult)
        {
            case "EASY":
                enemy = enemyEasy;
                //Debug.Log(enemy.Length);
                //Debug.Log(enemyEasy.Length);
                break;
            case "NORMAL":
                enemy = enemyNormal;
                modifyableInterval = interval - 1;
                break;
            case "HARD":
                enemy = enemyHard;
                modifyableInterval = interval - 2;
                break;
        }
        if (first)
        {
            InvokeRepeating("SpawnDebug", 3f, modifyableInterval);
        }
	}

	void spawnCon(){
		int i=Random.Range (0, enemy.Length);
        if (enemy[i].GetComponent<FlyingEnemy>())
            Instantiate(enemy[i], new Vector3(transform.position.x, 20, transform.position.z), new Quaternion(0,180,0,0));
        else
            Instantiate(enemy[i], new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f),new  Quaternion(0,180,0,0));
	}

    public void SpawnDebug()
    {
        int currentWave = waveManager.GetWave();
        if (waveManager.GetEnemyNumber() < waveManager.GetCurrentEnemyWave(currentWave))
        {
            //Debug.Log(enemy.Length);
            int i = Random.Range(0, enemy.Length);
            if (enemy[i].GetComponent<FlyingEnemy>())
                Instantiate(enemy[i], new Vector3(transform.position.x, 20, transform.position.z), new Quaternion(0, 180, 0, 0));
            else
                Instantiate(enemy[i], new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f), new Quaternion(0, 180, 0, 0));
            waveManager.SetEnemyNumber(waveManager.GetEnemyNumber() + 1);
        }
        else if (waveManager.GetEnemyNumber() >= waveManager.GetCurrentEnemyWave(currentWave) && currentWave == waveManager.GetWaveLength() - 1)
        {
            waveManager.SetEndWave(true);
        }
    }
	// Update is called once per fram
    public float GetInterval()
    {
        return this.modifyableInterval;
    }
    public void CancelSpawn()
    {
        CancelInvoke("spawnCon");
    }
    public void ReSpawn(float param)
    {
        InvokeRepeating("spawnCon", param, param);
    }
}
