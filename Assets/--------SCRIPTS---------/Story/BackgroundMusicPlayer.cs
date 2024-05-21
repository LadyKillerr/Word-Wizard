
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

    public void PlayGameMusicDelay(float value)
    {
        StartCoroutine(ContinueGameMusic(value));
    }

    IEnumerator ContinueGameMusic(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameMusic.Play();
    }
}
