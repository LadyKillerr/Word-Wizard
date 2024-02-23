using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettingPopup : MonoBehaviour
{



    // panel tối tối để cover màn hình 
    [SerializeField] GameObject settingPopup;

    // Screen Darken
    [SerializeField] GameObject screenDarken;

    [Header("AudioSource")]

    AudioSource backgroundMusic;

    [SerializeField] bool musicOn = true;
    [SerializeField] bool sfxOn = true;

    AudioManager audioManager;


    void Awake()
    {
        settingPopup.SetActive(false);

        audioManager = FindObjectOfType<AudioManager>();

        backgroundMusic = audioManager.GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        // hàm update là không càn thiết trong trường hợp sử dụng chay void
        //HideDevingNoti();
        //ShowDevingNoti();
    }

    // ẩn hộp thông báo đi 
    public void HideDevingNoti()
    {
        settingPopup.SetActive(false);
        screenDarken.SetActive(false);

    }

    // trượt hộp thông báo xuống
    public void ShowDevingNoti()
    {
        settingPopup.SetActive(true);

        screenDarken.SetActive(true);
    }

    public void ToggleMusic()
    {
        if (musicOn)
        {
            backgroundMusic.enabled = false;
            musicOn = false;
            Debug.Log("Da tat am nhac di r");
        }
        else if (!musicOn)
        {
            backgroundMusic.enabled = true;
            musicOn = true;
            Debug.Log("Da bat am nhac di r");

        }
    }

    public void ToggleSFX()
    {
        if (sfxOn)
        {
            audioManager.GetComponent<AudioSource>().enabled = false;
            sfxOn = false;
            Debug.Log("Da tat sfx di r");

        }
        else if (!sfxOn)
        {
            audioManager.GetComponent<AudioSource>().enabled = true;
            sfxOn = true;
            Debug.Log("Da bat am nhac di r");

        }
    }

    public void ToggleButtonAudio()
    {
        audioManager.PlayButtonClip();
    }
}
