using UnityEngine;
using System.Collections;

public class ButtonNextLVL : MonoBehaviour {


    public void LoadNextLevel(int level)
    {
        if (level == 0 || level == null)
        {
            Application.LoadLevel("HighScore");
        }
        else   Application.LoadLevel("Level"+level);
    }

}
