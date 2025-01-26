using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip MainMusic;
    public AudioSource speaker;
    public AudioSource effect;
    // Start is called before the first frame update
    void Start()
    {
        speaker.clip = MainMusic;
        speaker.loop = true;
        speaker.Play();
    }

    public void Effect(AudioClip clip)
    {
        if (!(effect.isPlaying))
        {
            effect.clip = clip;
            effect.Play();
        }
    }
}
