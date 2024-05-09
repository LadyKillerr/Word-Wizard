using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NotiManager : MonoBehaviour
{
    [SerializeField] GameObject screenDarken;

    [Header("Noti")]
    [SerializeField] GameObject wrongAnswerNoti;
    [SerializeField] GameObject lockedNoti;

    [Header("Scale Tween")]
    [SerializeField] Vector2 startValue = new Vector2(0, 0);
    [SerializeField] Vector2 endValue = new Vector2(1, 1);

    [SerializeField] float tweenTime = 0.5f;


    StoryManager storyManager;
    QuestionManager questionManager;
    AudioManager audioManager;

    [Header("Load Hint Parts")]
    [SerializeField] int question1Part = 0;
    [SerializeField] int question2Part = 0;
    [SerializeField] int question3Part = 0;
    [SerializeField] int question4Part = 0;
    [SerializeField] int question5Part = 0;
    [SerializeField] int question6Part = 0;


    void Awake()
    {
        questionManager = FindAnyObjectByType<QuestionManager>();
        storyManager = FindAnyObjectByType<StoryManager>();
        audioManager = FindAnyObjectByType<AudioManager>();

    }


    #region isLockedNoti

    public void ShowIsLockedNoti()
    {
        if (lockedNoti != null)
        {

            lockedNoti.transform.DOScale(endValue, tweenTime)
                .SetEase(Ease.InOutSine);
        }



        screenDarken.SetActive(true);

    }

    public void HideIsLockedNoti()
    {
        if (lockedNoti != null)
        {
            lockedNoti.transform.DOScale(startValue, tweenTime)
               .SetEase(Ease.InOutSine);


        }
        screenDarken.SetActive(value: false);


    }

    #endregion


    #region WrongAnswerNoti

    public void ShowWrongAnswerNoti()
    {

        screenDarken.SetActive(true);

        if (wrongAnswerNoti != null)
        {
            wrongAnswerNoti.transform.DOScale(endValue, tweenTime)
                .SetEase(Ease.InOutSine);

        }
    }

    public void HideWrongAnswerNoti()
    {
        if (wrongAnswerNoti != null)
        {

            wrongAnswerNoti.transform.DOScale(startValue, tweenTime)
                .SetEase(Ease.InOutSine);


        }

        screenDarken.SetActive(false);


    }

    #endregion

    public void ReloadStory()
    {
        if (questionManager != null && storyManager != null)
        {

            switch (questionManager.GetCurrentIndex())
            {
                case 0:



                    storyManager.LoadSpecificStoryPart(question1Part);

                    break;
                case 1:



                    storyManager.LoadSpecificStoryPart(question2Part);

                    break;
                case 2:



                    storyManager.LoadSpecificStoryPart(question3Part);

                    break;
                case 3:



                    storyManager.LoadSpecificStoryPart(question4Part);

                    break;
                case 4:



                    storyManager.LoadSpecificStoryPart(question5Part);

                    break;
                case 5:



                    storyManager.LoadSpecificStoryPart(question6Part);

                    break;

            }
        }
    }

    public void PlayButtonAudio()
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonClip();

        }
    }

}
