using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLikedStory : MonoBehaviour
{
    [SerializeField] GameObject heartsImage;

    [SerializeField] string levelPrefLikedName;

    AudioManager gameAudio;


    void Awake()
    {
        gameAudio = FindAnyObjectByType<AudioManager>();    
    }

    public void ToggleHeartsImage()
    {
        // nếu đang ở chế độ thích (có hình trái tim)
        if (heartsImage.activeSelf)
        {
            heartsImage.SetActive(false);

            gameAudio.PlayButtonClip();

            // kích hoạt tín hiệu cho thấy đã bỏ like bộ truyện này
            PlayerPrefs.SetInt(levelPrefLikedName, 0);

        }

        // nếu đang ở chế độ không thích và không có hình trái tim thì toggle nó lên
        else
        {
            heartsImage.SetActive(true);

            gameAudio.PlayButtonClip();

            // kích hoạt tag cho thấy đã like bộ truyện này
            PlayerPrefs.SetInt(levelPrefLikedName, 1);
        
        }
    }

    private void Update()
    {
        // nếu PlayerPrefsLikedName đang là 0
        if (PlayerPrefs.GetInt(levelPrefLikedName) == 0)
        {
            heartsImage.SetActive(false);

        }
        else
        {
            heartsImage.SetActive(true);

        }
    }


}
