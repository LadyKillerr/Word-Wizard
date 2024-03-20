using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveImages : MonoBehaviour
{
    [Header("DotTween")]
    [SerializeField] float showTime = 0.3f;
    [SerializeField] float hideTime = 0.2f;
    Vector3 startTweenScale;
    [SerializeField] Vector3 endTweenScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] Ease showEase = Ease.OutBack, hideEase = Ease.InBack;
    [SerializeField] Transform tweenGo;

    [Header("Image Components")]
    RectTransform imageRectTransform;
    //AudioSource interactiveImageAudioSource;
    //[SerializeField] AudioClip imageAudioClip;

    [SerializeField] bool isScaling;

    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        //interactiveImageAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {

        startTweenScale = imageRectTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (isScaling == false)
        {

            //if (!interactiveImageAudioSource.isPlaying)
            //{
            //    interactiveImageAudioSource.PlayOneShot(imageAudioClip);

            //}

            tweenGo.localScale = startTweenScale;
            tweenGo.DOScale(endTweenScale, showTime).SetEase(showEase);


            StartCoroutine(ResetLocalScale());
              
        } else { return; }

    }

    IEnumerator ResetLocalScale()
    {
        yield return new WaitForSeconds(showTime);

        tweenGo.DOScale(startTweenScale, hideTime).SetEase(hideEase);
    }
}
