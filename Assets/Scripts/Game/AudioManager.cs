using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Vocabulary")]
    [SerializeField] AudioClip StartAudio;
    [SerializeField][Range(0, 1)] float startVolume = 1f;

    [SerializeField] AudioClip buttonAudio;
    [SerializeField][Range(0, 1)] float buttonVolume = 1f;

    [SerializeField] AudioClip pageTurningAudio;
    [SerializeField][Range(0, 1)] float pageTurningVolume = 1f;

    [SerializeField] AudioClip bugAudio;
    [SerializeField][Range(0, 1)] float bugAudioVolume = 1f;

    
    
    

    AudioSource gameAudio;

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
    }

    void Start()
    {
        gameAudio = GetComponent<AudioSource>();

        // lấy ra vị trí của camera để làm điểm phát audio
        // cameraPosition = Camera.main.transform.position;

    }

    // hàm dùng chung để chạy tất cả các clip âm thanh được lưu ở đây
    void PlayAudio(AudioClip clip, float volume)
    {
        if (!gameAudio.isPlaying && gameAudio.enabled == true)
        {
            gameAudio.PlayOneShot(clip, volume);

        }
    }

    public void PlayStartAudio()
    {
        PlayAudio(StartAudio, startVolume);
    }

    public void PlayButtonClip()
    {
        PlayAudio(buttonAudio, buttonVolume);
    }

    public void PlayPageTurningClip()
    {
        PlayAudio(pageTurningAudio, pageTurningVolume);
    }

    public void PlayBugClip()
    {
        PlayAudio(bugAudio, bugAudioVolume);
    }

   
}
