using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour {

    private PlayerSaveLoad loadedData;
    
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            FileStream file1 = File.Open(Application.persistentDataPath + "/save.txt", FileMode.Open);
            this.loadedData = (PlayerSaveLoad)bf.Deserialize(file1);
            file1.Close();
        }
        PlayerSaveLoad newData = new PlayerSaveLoad();
        if (loadedData !=null)
        {
            newData = loadedData;
        }
        if (!GameObject.Find("Player").GetComponent<Player>())
        {
            newData.Money = GameObject.Find("Player").GetComponent<Player>().gold;
            newData.Score = GameObject.Find("Player").GetComponent<Player>().score;
            int hitPoint = GameObject.Find("Player").GetComponent<Player>().hitPoint;

            PlayerPrefs.SetInt("Money", newData.Money);

            if (hitPoint == 10)
            {
                newData.StarNumber = 3;
            }
            else if (hitPoint < 10 && hitPoint > 5)
            {
                newData.StarNumber = 2;
            }
            else if (hitPoint <= 5 && hitPoint > 0)
            {
                newData.StarNumber = 1;
            }
        }
        FileStream file = File.Open(Application.persistentDataPath + "/save.txt", FileMode.Create);
        bf.Serialize(file, newData);
        file.Close();
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.txt", FileMode.Open);
            this.loadedData = (PlayerSaveLoad)bf.Deserialize(file);
            file.Close();
            //Money.SetMoney(newData.Money);
            PlayerPrefs.SetInt("Money", loadedData.Money);
            if (GameObject.Find("Player").GetComponent<Player>())
            {
                GameObject.Find("Player").GetComponent<Player>().gold = loadedData.Money;
            }
            //PlayerPrefs.SetFloat("Volume", loadedData.Volume);
        }
    }
    public void SetLoadedData(PlayerSaveLoad player)
    {
        this.loadedData = player;
    }
    public PlayerSaveLoad GetLoadedData()
    {
        return this.loadedData;
    }
}

[System.Serializable]
public class PlayerSaveLoad
{
    public float Score;
    public int Money;
    public int StarNumber;
    //public float Volume;
    public PlayerSaveLoad()
    {
        this.Score = 0;
        this.StarNumber = 0;
        this.Money = 100;
        //this.Volume = 1;
    }
}
