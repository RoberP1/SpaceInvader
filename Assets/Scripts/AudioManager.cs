using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip shootClip;
    public AudioClip invaderKilledClip;
    public AudioClip loseLifeClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayShootClip()
    {
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position);
    }

    public void PlayInvaderKilledClip()
    {
        AudioSource.PlayClipAtPoint(invaderKilledClip, Camera.main.transform.position);
    }

    public void PlayLoseLifeClip()
    {
        AudioSource.PlayClipAtPoint(loseLifeClip, Camera.main.transform.position);
    }

}
