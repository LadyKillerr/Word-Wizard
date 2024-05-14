using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotiManagerGetter : MonoBehaviour
{
    NotiManager notiManager;
    AudioManager audioManager;
    StoryManager storyManager;

    // Start is called before the first frame update
    void Awake()
    {
        notiManager = FindAnyObjectByType<NotiManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
        storyManager = FindAnyObjectByType<StoryManager>();
    }


    public void PlayButtonAudio()
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonClip();

        }
    }

    public void HideIsLockedNoti()
    {
        notiManager.HideIsLockedNoti();

        notiManager.ReloadStory();
    }

    public void HideWrongAnswerNoti()
    {
        notiManager.HideWrongAnswerNoti();
    }
}
