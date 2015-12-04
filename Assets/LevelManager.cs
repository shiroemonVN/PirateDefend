//file nay chua can dung den

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

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
    private string GameMode;
    private int[] waveEnemy;
	// Use this for initialization
	void Start () {
        GameMode = PlayerPrefs.GetString("Mode", "EASY");
        currentActiveSpawnPoint = 0;
        waveEnemy = new int [5];
        switch(GameMode)
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
	
	}

    public void EasyGame()
    {
        int currentWave = GetWave();
        int waveNumber = 4;
        //EasyConfig easy = new EasyConfig();
    }
    public void NormalGame()
    {
        int currentWave = GetWave();
        int waveNumber = 4;

        //NormalConfig normal = new NormalConfig();
    }
    public void HardGame()
    {
        int currentWave = GetWave();
        int waveNumber = 5;
        //HardConfig hard = new HardConfig();
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
                        spawnPoints[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, 6f);
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
                            spawnPoints[i].GetComponent<Spawn>().InvokeRepeating("SpawnDebug", 3f, 6f);
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
}

//public class EasyConfig
//{
//    public int waveNumber;
//    public GameObject[][] enemy;
//    public EasyConfig()
//    {
//        waveNumber = 4;
//        enemy = new GameObject[waveNumber][];
//    }
//}

//public class NormalConfig
//{
//    public int waveNumber;
//    public GameObject[][] enemy;
//    public NormalConfig()
//    {
//        waveNumber = 4;
//        enemy = new GameObject[waveNumber][];
//    }
//}
//public class HardConfig
//{
//    public int waveNumber;
//    public GameObject[][] enemy;
//    public HardConfig()
//    {
//        waveNumber = 5;
//        enemy = new GameObject[waveNumber][];
//    }
//}