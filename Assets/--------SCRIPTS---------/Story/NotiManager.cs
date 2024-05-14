using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NotiManager : MonoBehaviour
{


    [Header("Noti")]
    [SerializeField] GameObject wrongAnswerNoti;
    [SerializeField] GameObject lockedNoti;

    [Header("Scale Tween")]
    [SerializeField] Vector2 startValue = new Vector2(0, 0);
    [SerializeField] Vector2 endValue = new Vector2(1, 1);

    [SerializeField] float tweenTime = 0.5f;


    [SerializeField] GameObject spawnLocation;

    StoryManager storyManager;
    QuestionManager questionManager;
    AudioManager audioManager;

    //Header("Load Hint Parts")]
    [SerializeField] int question1Part = 0;
    //[SerializeField] int question2Part = 0;
    //[SerializeField] int question3Part = 0;
    //[SerializeField] int question4Part = 0;
    //[SerializeField] int question5Part = 0;
    //[SerializeField] int question6Part = 0;


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

            if (spawnLocation.transform.childCount <= 1)
            {
                Instantiate(lockedNoti, spawnLocation.transform);

            }


            spawnLocation.transform.GetChild(1).transform.localScale = new Vector2(0, 0);

            spawnLocation.transform.GetChild(1).transform.DOScale(endValue, tweenTime)
                .SetEase(Ease.InOutSine);
        }





    }

    public void HideIsLockedNoti()
    {
        if (lockedNoti != null)
        {
            spawnLocation.transform.GetChild(1).transform.DOScale(startValue, tweenTime)
               .SetEase(Ease.InBack);


        }



    }

    #endregion


    #region WrongAnswerNoti

    public void ShowWrongAnswerNoti()
    {



        if (wrongAnswerNoti != null)
        {
            if (spawnLocation.transform.childCount <= 1 )
            {

                Instantiate(wrongAnswerNoti, spawnLocation.transform);

            }

            spawnLocation.transform.GetChild(1).transform.localScale = new Vector2(0, 0);

            spawnLocation.transform.GetChild(1).transform.DOScale(endValue, tweenTime)
                .SetEase(Ease.OutBack);

        }
    }

    public void HideWrongAnswerNoti()
    {
        if (wrongAnswerNoti != null)
        {

            wrongAnswerNoti.transform.DOScale(startValue, tweenTime)
                .SetEase(Ease.InOutSine);

            spawnLocation.transform.GetChild(1).transform.DOScale(startValue, tweenTime)
                .SetEase(Ease.InBack);

            StartCoroutine(KillNoti(tweenTime));
        }
    }

    IEnumerator KillNoti(float delay)
    {
        yield return new WaitForSeconds(delay);

        //hildDestroy(spawnLocation.gameObject.GetC(1);
    }

    #endregion

    public void ReloadStory()
    {
        if (storyManager != null)
        {
            Debug.Log("Đã reset lại story part về part đầu tiên của truyện");

            storyManager.LoadSpecificStoryPart(question1Part);

            //switch (questionManager.GetCurrentIndex())
            //{
            //	case 0:



            //		storyManager.LoadSpecificStoryPart(question1Part);

            //		break;
            //	case 1:



            //		storyManager.LoadSpecificStoryPart(question1Part);

            //		break;
            //	case 2:



            //		storyManager.LoadSpecificStoryPart(question1Part);

            //		break;
            //	case 3:



            //		storyManager.LoadSpecificStoryPart(question1Part);

            //		break;
            //	case 4:



            //		storyManager.LoadSpecificStoryPart(question1Part);

            //		break;
            //	case 5:



            //		storyManager.LoadSpecificStoryPart(question1Part);

            //		break;

            //}
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
