using UnityEngine;

public class AudioGetter : MonoBehaviour
{
    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    
    public void PlayButtonClip()
    {
        audioManager.PlayButtonClip();
    }

    public void PlayStartClip()
    {
        audioManager.PlayStartAudio();
    }
}
