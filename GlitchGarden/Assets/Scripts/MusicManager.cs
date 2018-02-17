using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    static MusicManager instance = null;

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont Destroy on load: " + name);
    }
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    

    // Update is called once per frame
    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];

        Debug.Log("Playing Clip " + thisLevelMusic);

        if(thisLevelMusic) //if there is some music attached
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void changeVolume(float value)
    {
        audioSource.volume = value;
    }
}
