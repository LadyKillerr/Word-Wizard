using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadSettingPopup : MonoBehaviour
{
    [Header("Tweening Properties")]
    [SerializeField] Vector3 startTweenScale;
    [SerializeField] Vector3 endTweenScale;
    [SerializeField] float tweenTime;

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
    [SerializeField] bool isSetting = false;

    [Header("Audio status")]


    [SerializeField] bool musicOn = true;
    [SerializeField] bool sfxOn = true;

    AudioManager audioManager;
    BackgroundMusicPlayer gameMusic;

    void Awake()
    {


        audioManager = FindAnyObjectByType<AudioManager>();
        gameMusic = FindAnyObjectByType<BackgroundMusicPlayer>();

    }

    private void Start()
    {
        if (gameMusic != null)
        {
            CheckAudioButtonStatus();

        }


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

    public void ToggleSettingPopup()
    {
        if (!isSetting)
        {
            settingPopup.transform.DOScale(endTweenScale, tweenTime)
                .SetEase(Ease.InSine);
            isSetting = true;
            screenDarken.SetActive(true);

        } else if (isSetting)
        {
            settingPopup.transform.DOScale(startTweenScale, tweenTime)
                .SetEase(Ease.OutSine);
            isSetting = false;
            screenDarken.SetActive(false);
        }
    }

    public void TogglePrivacyWindow()
    {
        if (!isPrivacy)
        {
            privacyPolicy.transform.DOScale(endTweenScale, tweenTime)
                .SetEase(Ease.InSine);

            isPrivacy = true;
        }
        else if (isPrivacy)
        {
            privacyPolicy.transform.DOScale(startTweenScale, tweenTime)
                .SetEase(Ease.OutSine);

            isPrivacy = false;
        }
    }

    public void ToggleAboutUsWindow()
    {
        if (!isAbout)
        {
            aboutUs.transform.DOScale(endTweenScale, tweenTime)
                .SetEase(Ease.InSine);
            isAbout = true;
        }
        else
        {
            aboutUs.transform.DOScale(startTweenScale, tweenTime)
                .SetEase(Ease.OutSine);
            
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
            Debug.Log("Da bat am nhac len r");

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
        if (audioManager != null)
        {
            audioManager.PlayButtonClip();

        }
    }


}
