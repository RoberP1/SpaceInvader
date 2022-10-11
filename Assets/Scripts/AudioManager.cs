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
    public void PlayClip(AudioClip clip) =>
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position,shootVolume);
}
