using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    public GameObject[] spawnPoint;
    public static int waveNumber = 0;
    public int currentEnemyNumber;
    private static int deadEnemy;
    public int[] waveEnemy = new int[] { 2, 3 };
    public static bool endWave = false;
    public float timer = 0;
    public bool coolDown = false;
    private int currentActiveSpawnPoint;
    public int version;

	// Use this for initialization
    void Start()
    {
        currentActiveSpawnPoint = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (version == 1)
        {
            int currentWave = GetWave();
            if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
            {
                spawnPoint[currentActiveSpawnPoint].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
                //int nextWave = currentWave + 1;
                if (GetDeadEnemy() >= waveEnemy[currentWave])
                {
                    timer += Time.deltaTime;
                    if (timer >= 10)
                    {
                        timer = 0;
                        SetEnemyNumber(0);
                        SetDeadEnemy(0);
                        if (currentWave + 1 < waveEnemy.Length)
                        {
                            SetWave(currentWave + 1);
                            int i = Random.Range(0, spawnPoint.Length);
                            currentActiveSpawnPoint = i;
                            spawnPoint[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, 6f);
                        }
                    }
                }
            }
            else if (GetEndWave())
            {
                spawnPoint[0].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
                //this.GetComponents<Spawn>().
            }
        }
        else if (version ==2)
        {
            int currentWave = GetWave();
            if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
            {
                for (int i = 0; i < spawnPoint.Length; i++)
                {
                    spawnPoint[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
                }
                int nextWave = currentWave + 1;
                if (GetDeadEnemy() >= waveEnemy[currentWave])
                {
                    timer += Time.deltaTime;
                    if (timer >= 10)
                    {
                        timer = 0;
                        SetEnemyNumber(0);
                        SetDeadEnemy(0);
                        if (currentWave + 1 < waveEnemy.Length)
                        {
                            SetWave(currentWave + 1);
                            //int i = Random.Range(0, spawnPoint.Length);
                            for (int i = 0; i < spawnPoint.Length; i++)
                            {
                                spawnPoint[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, 6f);
                            }
                        }
                    }
                }
            }
            else if (GetEndWave())
            {
                for (int i = 0; i < spawnPoint.Length; i++)
                {
                    spawnPoint[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
                }
                //this.GetComponents<Spawn>().
            }
        }
	}

    public void Version1()
    {
        int currentWave = GetWave();
        if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
        {
            spawnPoint[currentActiveSpawnPoint].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
            //int nextWave = currentWave + 1;
            if (GetDeadEnemy() >= waveEnemy[currentWave])
            {
                timer += Time.deltaTime;
                if (timer >= 10)
                {
                    timer = 0;
                    SetEnemyNumber(0);
                    SetDeadEnemy(0);
                    if (currentWave + 1 < waveEnemy.Length)
                    {
                        SetWave(currentWave + 1);
                        int i = Random.Range(0, spawnPoint.Length);
                        currentActiveSpawnPoint = i;
                        spawnPoint[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, 6f);
                    }
                }
            }
        }
        else if (GetEndWave())
        {
            spawnPoint[0].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
            //this.GetComponents<Spawn>().
        }
    }
    public void Version2()
    {
        int currentWave = GetWave();
        if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                spawnPoint[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
            }
            int nextWave = currentWave + 1;
            if (GetDeadEnemy() >= waveEnemy[currentWave])
            {
                timer += Time.deltaTime;
                if (timer >= 10)
                {
                    timer = 0;
                    SetEnemyNumber(0);
                    SetDeadEnemy(0);
                    if (currentWave + 1 < waveEnemy.Length)
                    {
                        SetWave(currentWave + 1);
                        //int i = Random.Range(0, spawnPoint.Length);
                        for (int i = 0; i < spawnPoint.Length; i++)
                        {
                            spawnPoint[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, 6f);
                        }
                    }
                }
            }
        }
        else if (GetEndWave())
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                spawnPoint[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
            }
            //this.GetComponents<Spawn>().
        }
    }
    public static void SetWave(int i)
    {
        waveNumber = i;
    }
    public static int GetWaveStatic()
    {
        return waveNumber;
    }
    public int GetWave()
    {
        return waveNumber;
    }
    public int GetEnemyNumber()
    {
        return this.currentEnemyNumber;
    }
    public void SetEnemyNumber(int i)
    {
        this.currentEnemyNumber = i;
    }
    public void SetEndWave(bool end)
    {
        endWave = end;
    }
    public bool GetEndWave()
    {
        return endWave;
    }
    public static int GetDeadEnemy()
    {
        return deadEnemy;
    }
    public static void SetDeadEnemy(int dead)
    {
        deadEnemy = dead;
    }
}
