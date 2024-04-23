
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    AudioSource gameMusic;

    private void Awake()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        int instanceCount = FindObjectsOfType(GetType()).Length;
#pragma warning restore CS0618 // Type or member is obsolete

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
