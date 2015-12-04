using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public void SoundSetting()
    {
        GetComponent<AudioSource>().volume = 0.5f;
    }
}
