using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip MainMusic;
    private AudioSource speaker;
    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<AudioSource>();
        speaker.clip = MainMusic;
        speaker.loop = true;
        speaker.Play();
    }
}
