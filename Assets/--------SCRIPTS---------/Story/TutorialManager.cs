using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject storyTutorial;
    [SerializeField] GameObject screenDarken;
    

    [SerializeField] float startValue =  -1260;
    [SerializeField] float endValue = 0;

    [SerializeField] float tweenTime = 0.5f;

    public bool isTutorial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTutorial()
    {
        if (!PlayerPrefs.HasKey("StoryTutorial"))
        {
            PlayerPrefs.SetInt("StoryTutorial", 1);

            screenDarken.SetActive(true);

            storyTutorial.transform.DOMoveY(endValue, tweenTime)
                .SetEase(Ease.InOutSine);


        }
    }

    public void HideTutorial()
    {
        if (PlayerPrefs.HasKey("StoryTutorial") && PlayerPrefs.GetInt("StoryTutorial") == 1)
        {
            storyTutorial.transform.DOMoveY(startValue, tweenTime)
                .SetEase(Ease.InOutSine);

            screenDarken.SetActive(false);
        }
    }

    public void SetIsTutorial(bool value)
    {
        isTutorial = value;
    }


}
