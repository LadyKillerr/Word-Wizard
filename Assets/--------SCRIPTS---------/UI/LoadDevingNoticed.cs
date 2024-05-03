using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadDevingNoticed : MonoBehaviour
{
    // panel tối tối để cover màn hình 
    [SerializeField] float tweenTime = .5f;

    // hộp thông báo "under development" 
    [SerializeField] GameObject notiBoard;

    // Screen Darken
    [SerializeField] GameObject screenDarken;

    [SerializeField] float startValue = -800f ;
    [SerializeField] float endValue = 0;


    public bool isAvatar;




    public void ToggleDevinNoti()
    {


        if (!isAvatar)
        {

            notiBoard.transform.DOMoveY(endValue, tweenTime)
                .SetEase(Ease.InOutSine);

            isAvatar = true;

            screenDarken.SetActive(true);
        }
        else
        {
            notiBoard.transform.DOMoveY(startValue, tweenTime)
                .SetEase(Ease.InOutSine);

            isAvatar = false;

            screenDarken.SetActive(false);
        }
    }



}
