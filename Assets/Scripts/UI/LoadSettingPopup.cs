using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSettingPopup : MonoBehaviour
{
    [Header("Audio Button Sprites")]

    [SerializeField] Button sfxButton;
    [SerializeField] Button musicButton;

    [SerializeField] Sprite activatedSoundButtonSprite;
    [SerializeField] Sprite disabledSoundButtonSprite;

    [SerializeField] Sprite activatedMusicButtonSprite;
    [SerializeField] Sprite disabledMusicButtonSprite;

    [Header("Game Components")]
    // panel tối tối để cover màn hình 
    [SerializeField] GameObject settingPopup;

    // Screen Darken
    [SerializeField] GameObject screenDarken;

    [SerializeField] GameObject privacyPolicy;
    [SerializeField] GameObject aboutUs;

    [SerializeField] bool isPrivacy = false;
    [SerializeField] bool isAbout = false;

    [Header("Audio status")]


    [SerializeField] bool musicOn = true;
    [SerializeField] bool sfxOn = true;

    AudioManager audioManager;
    BackgroundMusicPlayer gameMusic;

    void Awake()
    {
        settingPopup.SetActive(false);

        audioManager = FindObjectOfType<AudioManager>();
        gameMusic = FindObjectOfType<BackgroundMusicPlayer>();

    }

    private void Start()
    {
        CheckAudioButtonStatus();
        

    }

    void Update()
    {
        // hàm update là không càn thiết trong trường hợp sử dụng chay void
        //HideDevingNoti();
        //ShowDevingNoti();

    }

    private void CheckAudioButtonStatus()
    {
        // kiểm tra nếu như gameMusic đang chạy âm thanh thì chỉnh biến bool và chuyển sprite của nút
        if (gameMusic.GetComponent<AudioSource>().isPlaying)
        {
            musicOn = true;
            musicButton.GetComponent<Image>().sprite = activatedMusicButtonSprite;

        }
        else if (!gameMusic.GetComponent<AudioSource>().isPlaying)
        {
            musicOn = false;
            musicButton.GetComponent<Image>().sprite = disabledMusicButtonSprite;

        }

        // kiểm tra nếu audioManager đang active thì set lại bool và chỉnh lại nút 
        if (audioManager.GetComponent<AudioSource>().enabled)
        {
            sfxOn = true;
            sfxButton.GetComponent<Image>().sprite = activatedSoundButtonSprite;

        }
        else if (!(audioManager.GetComponent<AudioSource>().enabled))
        {
            sfxOn = false;
            sfxButton.GetComponent<Image>().sprite = disabledSoundButtonSprite;

        }
    }

    // ẩn hộp thông báo đi 
    public void HideSettingPopup()
    {
        settingPopup.SetActive(false);
        screenDarken.SetActive(false);

    }

    // trượt hộp thông báo xuống
    public void ShowSettingPopup()
    {
        settingPopup.SetActive(true);

        screenDarken.SetActive(true);
    }

    public void TogglePrivacyWindow()
    {
        if (!isPrivacy)
        {
            privacyPolicy.SetActive(true);
            isPrivacy = true;
        }
        else if (isPrivacy)
        {
            privacyPolicy.SetActive(false);
            isPrivacy = false;
        }
    }

    public void ToggleAboutUsWindow()
    {
        if (!isAbout)
        {
            aboutUs.SetActive(true);
            isAbout = true;
        }
        else
        {
            aboutUs.SetActive(false);
            isAbout = false;
        }
    }

    public void ToggleMusic()
    {
        if (musicOn)
        {
            // dừng âm thanh nhạc nền
            gameMusic.GetComponent<AudioSource>().Pause();
            musicOn = false;

            // đổi màu nút 
            musicButton.GetComponent<Image>().sprite = disabledMusicButtonSprite;
            Debug.Log("Da tat am nhac di r");
        }
        else if (!musicOn)
        {
            gameMusic.GetComponent<AudioSource>().UnPause();
            musicOn = true;
            musicButton.GetComponent<Image>().sprite = activatedMusicButtonSprite;
            Debug.Log("Da bat am nhac di r");

        }
    }

    public void ToggleSFX()
    {
        if (sfxOn)
        {
            // tắt âm thanh của audio manager
            audioManager.GetComponent<AudioSource>().enabled = false;

            sfxOn = false;

            // đổi màu nút 
            sfxButton.GetComponent<Image>().sprite = disabledSoundButtonSprite;

            Debug.Log("Da tat sfx di r");

        }
        else if (!sfxOn)
        {
            audioManager.GetComponent<AudioSource>().enabled = true;

            sfxOn = true;

            sfxButton.GetComponent<Image>().sprite = activatedSoundButtonSprite;

            Debug.Log("Da bat am nhac di r");

        }
    }

    public void ToggleButtonAudio()
    {
        audioManager.PlayButtonClip();
    }


}
