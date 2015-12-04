using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {
    private string gameDiff;
	// Use this for initialization
    void Awake()
    {
        gameDiff = PlayerPrefs.GetString("Mode", "EASY");
        //Debug.Log(gameDiff);
    }
    //void Start () {
    //    gameDiff = PlayerPrefs.GetString("Mode", "EASY");
    //    Debug.Log(gameDiff);
    //}
    public string GetGameMode()
    {
        //Debug.Log(gameDiff);
        return this.gameDiff;
    }
}
