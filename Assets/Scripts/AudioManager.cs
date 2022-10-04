using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip shootClip;
    public AudioClip invaderKilledClip;
    public AudioClip loseLifeClip;

    [Range(0, 1)]
    public float shootVolume = 0.5f;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    public void PlayShootClip() =>
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position,shootVolume);

    public void PlayInvaderKilledClip() =>
        AudioSource.PlayClipAtPoint(invaderKilledClip, Camera.main.transform.position,shootVolume);
    
    public void PlayLoseLifeClip()=>
        AudioSource.PlayClipAtPoint(loseLifeClip, Camera.main.transform.position,shootVolume);
}
