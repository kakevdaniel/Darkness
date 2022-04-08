using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static AudioClip handgunSound, riffleSound, shotgunSound;
    static AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        handgunSound = Resources.Load<AudioClip>("handgun");
        riffleSound = Resources.Load<AudioClip>("riffle");
        shotgunSound = Resources.Load<AudioClip>("shotgun");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "handgun":
                audioSource.PlayOneShot(handgunSound);
                break;
            case "riffle":
                audioSource.PlayOneShot(riffleSound);
                break;
            case "shotgun":
                audioSource.PlayOneShot(shotgunSound);
                break;
        }
    }
}
