using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Game SFX")]
    [SerializeField] AudioClip startAudio;
    [SerializeField][Range(0, 1)] float startVolume = 1f;

    [SerializeField] AudioClip buttonAudio;
    [SerializeField][Range(0, 1)] float buttonVolume = 1f;

    [SerializeField] AudioClip pageTurningAudio;
    [SerializeField][Range(0, 1)] float pageTurningVolume = 1f;

    [SerializeField] AudioClip bugAudio;
    [SerializeField][Range(0, 1)] float bugAudioVolume = 1f;

    [SerializeField] AudioClip congratsAudio;
    [SerializeField][Range(0, 1)] float congratsAudioVolume = 1f;

    [Header("Vocabulary")]
    [SerializeField] AudioClip aWord;
    [SerializeField][Range(0, 1)] float aWordAudioVolume = 1f;

    [SerializeField] AudioClip bWord;
    [SerializeField][Range(0, 1)] float bWordAudioVolume = 1f;

    [SerializeField] AudioClip cWord;
    [SerializeField][Range(0, 1)] float cWordAudioVolume = 1f;

    [SerializeField] AudioClip dWord;
    [SerializeField][Range(0, 1)] float dWordAudioVolume = 1f;

    [SerializeField] AudioClip eWord;
    [SerializeField][Range(0, 1)] float eWordAudioVolume = 1f;

    [SerializeField] AudioClip fWord;
    [SerializeField][Range(0, 1)] float fWordAudioVolume = 1f;

    [SerializeField] AudioClip gWord;
    [SerializeField][Range(0, 1)] float gWordAudioVolume = 1f;

    [SerializeField] AudioClip hWord;
    [SerializeField][Range(0, 1)] float hWordAudioVolume = 1f;

    [SerializeField] AudioClip iWord;
    [SerializeField][Range(0, 1)] float iWordAudioVolume = 1f;

    [SerializeField] AudioClip jWord;
    [SerializeField][Range(0, 1)] float jWordAudioVolume = 1f;

    [SerializeField] AudioClip kWord;
    [SerializeField][Range(0, 1)] float kWordAudioVolume = 1f;

    [SerializeField] AudioClip lWord;
    [SerializeField][Range(0, 1)] float lWordAudioVolume = 1f;

    [SerializeField] AudioClip mWord;
    [SerializeField][Range(0, 1)] float mWordAudioVolume = 1f;

    [SerializeField] AudioClip nWord;
    [SerializeField][Range(0, 1)] float nWordAudioVolume = 1f;

    [SerializeField] AudioClip oWord;
    [SerializeField][Range(0, 1)] float oWordAudioVolume = 1f;

    [SerializeField] AudioClip pWord;
    [SerializeField][Range(0, 1)] float pWordAudioVolume = 1f;

    [SerializeField] AudioClip qWord;
    [SerializeField][Range(0, 1)] float qWordAudioVolume = 1f;

    [SerializeField] AudioClip rWord;
    [SerializeField][Range(0, 1)] float rWordAudioVolume = 1f;

    [SerializeField] AudioClip sWord;
    [SerializeField][Range(0, 1)] float sWordAudioVolume = 1f;

    [SerializeField] AudioClip tWord;
    [SerializeField][Range(0, 1)] float tWordAudioVolume = 1f;

    [SerializeField] AudioClip uWord;
    [SerializeField][Range(0, 1)] float uWordAudioVolume = 1f;

    [SerializeField] AudioClip vWord;
    [SerializeField][Range(0, 1)] float vWordAudioVolume = 1f;

    [SerializeField] AudioClip wWord;
    [SerializeField][Range(0, 1)] float wWordAudioVolume = 1f;

    [SerializeField] AudioClip xWord;
    [SerializeField][Range(0, 1)] float xWordAudioVolume = 1f;

    [SerializeField] AudioClip yWord;
    [SerializeField][Range(0, 1)] float yWordAudioVolume = 1f;

    [SerializeField] AudioClip zWord;
    [SerializeField][Range(0, 1)] float zWordAudioVolume = 1f;


    AudioSource gameAudio;

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
        PlayAudio(startAudio, startVolume);
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

    public void PlayCongratsClip()
    {
        PlayAudio(congratsAudio, congratsAudioVolume);
    }
}
