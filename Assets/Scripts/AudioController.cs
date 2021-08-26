using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip sfx;
    public AudioClip anotherSfx;
    public AudioClip bgm;

    public static AudioController current;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        current = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
