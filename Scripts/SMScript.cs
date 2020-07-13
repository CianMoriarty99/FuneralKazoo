using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMScript : MonoBehaviour
{
    public static AudioClip pickupCoinSound, explodeSound, happySound, song, changeColor, kaz1, kaz2, kaz3, kaz4;
    static AudioSource audioSrc;

    public static bool kazoo;
    // Start is called before the first frame update
    void Start()
    {
        
        pickupCoinSound = Resources.Load<AudioClip>("Pickup_Coin");
        explodeSound = Resources.Load<AudioClip>("Randomize12");
        happySound = Resources.Load<AudioClip>("Happy");
        song = Resources.Load<AudioClip>("Song");
        changeColor = Resources.Load<AudioClip>("Powerup3");

        kaz1 = Resources.Load<AudioClip>("kaz1");

        kaz2 = Resources.Load<AudioClip>("kaz2");

        kaz3 = Resources.Load<AudioClip>("kaz3");

        kaz4 = Resources.Load<AudioClip>("kaz4");


        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(kazoo){
            StartCoroutine("PlayKazoo");
        }
        
    }

    public static void PlaySound(string clip){

        switch(clip){
            case "coin":
                audioSrc.PlayOneShot(pickupCoinSound);
                break;
            case "explode":
                audioSrc.PlayOneShot(explodeSound);
                break;
            case "happy":
                audioSrc.PlayOneShot(happySound);
                break;
            case "song":
                audioSrc.PlayOneShot(song);
                break;
            case "color":
                audioSrc.PlayOneShot(changeColor);
                break;
            case "1":
                audioSrc.PlayOneShot(kaz1);
                break;
            case "2":
                audioSrc.PlayOneShot(kaz2);
                break;
            case "3":
                audioSrc.PlayOneShot(kaz3);
                break;
            case "4":
                audioSrc.PlayOneShot(kaz4);
                break;

        }
    }


}
