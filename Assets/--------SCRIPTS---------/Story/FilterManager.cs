﻿
#region AnimFilterButtons
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FilterManager : MonoBehaviour
//{
//    [SerializeField] List<GameObject> filterButtons;

//    // filter buttons
//    [SerializeField] GameObject pendingBtn;
//    [SerializeField] GameObject likedBtn;
//    [SerializeField] GameObject newBtn;
//    [SerializeField] GameObject heartsButton;
//    [SerializeField] GameObject checkButton;

//    [SerializeField] float pullUpAnim = 1f;
//    // all filter buttons menu


//    // book count list
//    //public List<GameObject> totalBooks;

//    AudioManager audioManager;
//    Animator allButtonAnimator;

//    Image filterButtonsImage;
//    Animator filterButtonsAnimator;



//    void Awake()
//    {
//        audioManager = FindAnyObjectByType<AudioManager>();

//        allButtonAnimator = pendingBtn.GetComponent<Animator>();

//    }


//    void FindActiveButton()
//    {
//        for (int i = 0; i < filterButtons.Count; i++)
//        {
//            if (filterButtons[i].activeSelf)
//            {
//                filterButtonsAnimator = filterButtons[i].GetComponent<Animator>();
//                filterButtonsImage = filterButtons[i].GetComponent<Image>();
//                break;
//            }

//        }
//    }

//    IEnumerator DisableAllButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);
//        for (int i = 0; i < filterButtons.Count; i++)
//        {
//            filterButtons[i].SetActive(false);
//            filterButtons[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
//        }
//    }

//    public void FilterAllBooks()
//    {

//        FindActiveButton();


//        filterButtonsAnimator.SetTrigger("Normal");
//        filterButtonsImage.color = new Color(255, 255, 255, 0);


//        Debug.Log("đã đổi màu nút hiện tại");

//        // đợi 1s để anim chạy r sau đó mới tắt hết đi
//        StartCoroutine(DisableAllButtons());


//        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
//        pendingBtn.SetActive(true);

//        // set active lại sau khi bị kill đi 
//        StartCoroutine(ToggleAllButtons());
//        ToggleButtonClip();

//    }

//    public void FilterNewBooks()
//    {
//        FindActiveButton();


//        filterButtonsAnimator.SetTrigger("Normal");
//        filterButtonsImage.color = new Color(1, 1, 1, 0);


//        // đợi 1s để anim chạy r sau đó mới tắt hết đi
//        StartCoroutine(DisableAllButtons()); ;


//        // kích hoạt nút new lên thay thế nút All
//        likedBtn.SetActive(true);

//        StartCoroutine(ToggleNewButtons());


//        ToggleButtonClip();

//    }

//    public void FilterHourglassBooks()
//    {
//        FindActiveButton();


//        filterButtonsAnimator.SetTrigger("Normal");
//        filterButtonsImage.color = new Color(1, 1, 1, 0);


//        // đợi 1s để anim chạy r sau đó mới tắt hết đi
//        StartCoroutine(DisableAllButtons());


//        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
//        newBtn.SetActive(true);

//        // set active lại sau khi bị kill đi 
//        StartCoroutine(ToggleHourglassButtons());
//        ToggleButtonClip();

//    }

//    public void FilterHeartsBooks()
//    {
//        FindActiveButton();


//        filterButtonsAnimator.SetTrigger("Normal");
//        filterButtonsImage.color = new Color(1, 1, 1, 0);


//        // đợi 1s để anim chạy r sau đó mới tắt hết đi
//        StartCoroutine(DisableAllButtons());


//        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
//        heartsButton.SetActive(true);

//        // set active lại sau khi bị kill đi 
//        StartCoroutine(ToggleHeartsButtons());
//        ToggleButtonClip();

//    }

//    public void FilterCheckBooks()
//    {
//        FindActiveButton();

//        // trigger anim và tắt opacity di để nút mờ đi -> hiện ra đc nút ở dưới
//        filterButtonsAnimator.SetTrigger("Normal");
//        filterButtonsImage.color = new Color(1, 1, 1, 0);

//        // đợi 1s để anim chạy r sau đó mới tắt hết đi - và bật lại opacity để lần sau bật vẫn lên
//        StartCoroutine(DisableAllButtons());


//        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
//        checkButton.SetActive(true);

//        // set active lại sau khi bị kill đi 
//        StartCoroutine(ToggleCheckButtons());

//        ToggleButtonClip();
//    }

//    IEnumerator ToggleAllButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);

//        pendingBtn.SetActive(true);

//    }

//    IEnumerator ToggleNewButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);

//        likedBtn.SetActive(true);

//    }

//    IEnumerator ToggleHourglassButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);

//        newBtn.SetActive(true);

//    }

//    IEnumerator ToggleHeartsButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);

//        heartsButton.SetActive(true);

//    }

//    IEnumerator ToggleCheckButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);

//        checkButton.SetActive(true);

//    }

//    void ToggleButtonClip()
//    {

//        if (audioManager != null)
//        {

//            audioManager.PlayButtonClip();
//        }
//    }
//}
#endregion


#region FilterButtonsNoAnim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterManager : MonoBehaviour
{
    // filter buttons
    [SerializeField] GameObject pendingBtn;
    [SerializeField] GameObject likedBtn;
    [SerializeField] GameObject newBtn;
    [SerializeField] GameObject doneBtn;


    // book count list
    public List<GameObject> totalBooks;

    AudioManager audioManager;


    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

    }

    void Start()
    {

    }


    void Update()
    {

    }

    public void FilterNewBooks()
    {
        
    }

    public void FilterHourglassBooks()
    {
        
    }

    public void FilterHeartsBooks()
    {
        
    }

    public void FilterCheckBooks()
    {
       
    }

    void TurnOffFilterMenu()
    {
        
    }
}

#endregion
