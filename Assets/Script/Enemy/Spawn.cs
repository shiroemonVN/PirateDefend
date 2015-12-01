using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject[] enemy;
	public float interval=6f;
    public WaveManager waveManager;
    public bool first;
	// Use this for initialization
	void Start () {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        if (first)
        {
            InvokeRepeating("SpawnDebug", 3f, interval);
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
        if (waveManager.GetEnemyNumber() < waveManager.waveEnemy[currentWave])
        {
            int i = Random.Range(0, enemy.Length);
            if (enemy[i].GetComponent<FlyingEnemy>())
                Instantiate(enemy[i], new Vector3(transform.position.x, 20, transform.position.z), new Quaternion(0, 180, 0, 0));
            else
                Instantiate(enemy[i], new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f), new Quaternion(0, 180, 0, 0));
            waveManager.SetEnemyNumber(waveManager.GetEnemyNumber() + 1);
        }
        else if (waveManager.GetEnemyNumber() >= waveManager.waveEnemy[currentWave] && currentWave == waveManager.waveEnemy.Length - 1)
        {
            waveManager.SetEndWave(true);
        }
    }
	// Update is called once per fram
    public float GetInterval()
    {
        return this.interval;
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
