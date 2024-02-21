using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLikedStory : MonoBehaviour
{
    [SerializeField] GameObject heartsImage;
    
    AudioManager gameAudio;


    void Awake()
    {
        gameAudio = FindObjectOfType<AudioManager>();    
    }

    public void ToggleHeartsImage()
    {
        if (heartsImage.activeSelf)
        {
            heartsImage.SetActive(false);

            gameAudio.PlayButtonClip();

            // kích hoạt tín hiệu cho thấy đã like bộ truyện này
        }
        else
        {
            heartsImage.SetActive(true);

            gameAudio.PlayButtonClip();

            // kích hoạt tag cho thấy đã bỏ like bộ truyện này
        }
    }



}
