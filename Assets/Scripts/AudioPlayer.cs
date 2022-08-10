using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        var players = FindObjectsOfType<AudioPlayer>();
        if (players.Length>1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }


}
