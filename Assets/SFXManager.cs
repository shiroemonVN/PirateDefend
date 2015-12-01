using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {

    public AudioClip errorClip;
    public AudioClip successClip;
    public AudioClip upgradeClip;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void PurchaseSuccess()
    {
        audio.PlayOneShot(successClip);
    }
    public void CannotPurchase()
    {
        audio.PlayOneShot(errorClip);
    }
    public void UpgradeComplete()
    {
        audio.PlayOneShot(upgradeClip);
    }
}
