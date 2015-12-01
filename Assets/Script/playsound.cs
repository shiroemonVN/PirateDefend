using UnityEngine;
using System.Collections;

public class playsound : MonoBehaviour {
    public AudioClip shootSound;
    private AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySound()
    {
        source.PlayOneShot(shootSound, 1f);
    }
}
