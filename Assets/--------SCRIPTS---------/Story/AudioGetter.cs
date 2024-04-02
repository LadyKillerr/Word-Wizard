using UnityEngine;

public class AudioGetter : MonoBehaviour
{
    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void PlayButtonClip()
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonClip();

        }
    }

    public void PlayStartClip()
    {
        if (audioManager != null)
        {
            audioManager.PlayStartAudio();

        }
    }
}
