
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    AudioSource gameMusic;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        gameMusic = GetComponent<AudioSource>();
    }

    public void StopGameMusic()
    {
        gameMusic.Pause();
    }

    public void PlayGameMusic()
    {
        gameMusic.Play();
    }
}
