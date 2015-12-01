using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
    public GameObject panel;
	// Use this for initialization
    public void onButtonClicked()
    {
        ButtonGun.setIsClicked(!ButtonGun.isClicked);
    }
}
