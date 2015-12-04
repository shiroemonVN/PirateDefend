using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    public GameObject[] spawnPoints;
    public static int waveCount = 0;
    public int currentEnemyNumber;
    private static int deadEnemy;
    public int[] waveEnemyEasy;
    public int[] waveEnemyNormal;
    public int[] waveEnemyHard;
    public static bool endWave = false;
    public float timer = 0;
    public bool coolDown = false;
    private int currentActiveSpawnPoint;
    public int version;
    private int difficulty;
    //private string GameMode;
    private int[] waveEnemy;

	// Use this for initialization
    void Start()
    {
        //GameMode = PlayerPrefs.GetString("Mode", "EASY");
        //Debug.Log(GameMode);
        currentActiveSpawnPoint = 0;
        waveEnemy = new int[5];
        //Debug.Log(Camera.main.GetComponent<GameMode>().GetGameMode());
        switch (Camera.main.GetComponent<GameMode>().GetGameMode())
        {
            case "":
                break;
            case "EASY":
                waveEnemy = waveEnemyEasy;
                difficulty = 1;
                break;
            case "NORMAL":
                waveEnemy = waveEnemyNormal;
                difficulty = 2;
                break;
            case "HARD":
                waveEnemy = waveEnemyHard;
                difficulty = 3;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (version == 1)
        {
            int currentWave = GetWave();
            if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
            {
                spawnPoints[currentActiveSpawnPoint].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
                //int nextWave = currentWave + 1;
                if (GetDeadEnemy() >= waveEnemy[currentWave])
                {
                    timer += Time.deltaTime;
                    if (timer >= 15)
                    {
                        timer = 0;
                        SetEnemyNumber(0);
                        SetDeadEnemy(0);
                        if (currentWave + 1 < waveEnemy.Length)
                        {
                            SetWave(currentWave + 1);
                            int i = Random.Range(0, spawnPoints.Length);
                            currentActiveSpawnPoint = i;
                            spawnPoints[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, spawnPoints[i].GetComponent<Spawn>().GetInterval());
                        }
                    }
                }
            }
            else if (GetEndWave())
            {
                spawnPoints[0].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
                //this.GetComponents<Spawn>().
            }
        }
        else if (version ==2)
        {
            int currentWave = GetWave();
            if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    spawnPoints[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
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
                            for (int i = 0; i < spawnPoints.Length; i++)
                            {
                                spawnPoints[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, spawnPoints[i].GetComponent<Spawn>().GetInterval());
                            }
                        }
                    }
                }
            }
            else if (GetEndWave())
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    spawnPoints[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
                }
            }
        }
	}

    public void Version1()
    {
        int currentWave = GetWave();
        if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
        {
            spawnPoints[currentActiveSpawnPoint].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
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
                        int i = Random.Range(0, spawnPoints.Length);
                        currentActiveSpawnPoint = i;
                        spawnPoints[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, spawnPoints[i].GetComponent<Spawn>().GetInterval());
                    }
                }
            }
        }
        else if (GetEndWave())
        {
            spawnPoints[0].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
            //this.GetComponents<Spawn>().
        }
    }
    public void Version2()
    {
        int currentWave = GetWave();
        if (GetEnemyNumber() >= waveEnemy[currentWave] && !GetEndWave())
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                spawnPoints[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
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
                        for (int i = 0; i < spawnPoints.Length; i++)
                        {
                            spawnPoints[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, spawnPoints[i].GetComponent<Spawn>().GetInterval());
                        }
                    }
                }
            }
        }
        else if (GetEndWave())
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                spawnPoints[i].GetComponent<Spawn>().CancelInvoke("SpawnDebug");
            }
            //this.GetComponents<Spawn>().
        }
    }
    public static void SetWave(int i)
    {
        waveCount = i;
    }
    public static int GetWaveStatic()
    {
        return waveCount;
    }
    public int GetWave()
    {
        return waveCount;
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
    
    public int GetCurrentEnemyWave(int current)
    {
        return waveEnemy[current];
    }
    public int GetWaveLength()
    {
        return waveEnemy.Length;
    }
}
