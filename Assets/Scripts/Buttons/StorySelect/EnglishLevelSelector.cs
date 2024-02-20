using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnglishLevelSelector : MonoBehaviour
{

    [SerializeField] GameObject levelSelector;

    AudioManager audioManager;

    bool isShow;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        isShow = false;
    }


    void Update()
    {

    }

    public void ToggleLevelSelector()
    {
        if (!isShow)
        {
            isShow = true;
            levelSelector.SetActive(true);

            audioManager.PlayButtonClip();

        }
        else
        {
            isShow = false;
            levelSelector.SetActive(false);
            audioManager.PlayButtonClip();

        }
    }
}
