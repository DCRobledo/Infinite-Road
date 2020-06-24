using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip backgroundAudio;
    public AudioClip[] UIButtonAudios;

    [Range(0,1)]
    public float volume = 1f;


    void Start()
    {
        PlayAudio(backgroundAudio, true);
        GameObject.FindGameObjectWithTag("Car").GetComponent<AudioSource>().volume = volume+.5f;
    }
    
    public void PlayAudio(AudioClip clip, bool loops = false, bool persist = false)
    {
        GameObject go = new GameObject();

        InstantiateAudio(clip, loops, go);

        if (persist)
            DontDestroyOnLoad(go);
    }

    private void InstantiateAudio(AudioClip clip, bool loops, GameObject go)
    {
        go.AddComponent<AudioSource>();
        go.GetComponent<AudioSource>().clip = clip;
        go.GetComponent<AudioSource>().loop = loops;
        go.GetComponent<AudioSource>().volume = this.volume;
        go.GetComponent<AudioSource>().Play();
    }

    public void PlayUIAudioButtonPressed() {
        AudioClip clip = UIButtonAudios[Random.Range(0,UIButtonAudios.Length)];
        PlayAudio(clip, false, true);
    }
}
