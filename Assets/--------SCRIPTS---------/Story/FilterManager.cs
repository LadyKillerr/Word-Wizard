
#region AnimFilterButtons
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FilterManager : MonoBehaviour
//{
//    [SerializeField] List<GameObject> filterButtons;

//    // filter buttons
//    [SerializeField] GameObject allButton;
//    [SerializeField] GameObject newButton;
//    [SerializeField] GameObject hourglassButton;
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

//        allButtonAnimator = allButton.GetComponent<Animator>();

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
//        allButton.SetActive(true);

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
//        newButton.SetActive(true);

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
//        hourglassButton.SetActive(true);

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

//        allButton.SetActive(true);

//    }

//    IEnumerator ToggleNewButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);

//        newButton.SetActive(true);

//    }

//    IEnumerator ToggleHourglassButtons()
//    {
//        yield return new WaitForSeconds(pullUpAnim);

//        hourglassButton.SetActive(true);

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
    [SerializeField] GameObject allButton;
    [SerializeField] GameObject newButton;
    [SerializeField] GameObject hourglassButton;
    [SerializeField] GameObject heartsButton;
    [SerializeField] GameObject checkButton;

    // all filter buttons menu
    [SerializeField] GameObject filterButtonsMenu;

    // book count list
    public List<GameObject> totalBooks;

    AudioManager audioManager;

    bool isShow;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

    }

    void Start()
    {

        isShow = false;

        filterButtonsMenu.SetActive(false);

        // ẩn các nút khác đi chỉ để lại nút all
        allButton.SetActive(true);
        newButton.SetActive(false);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(false);
        checkButton.SetActive(false);
    }


    void Update()
    {

    }

    public void ShowFilterButtons()
    {
        if (!isShow)
        {
            isShow = true;
            filterButtonsMenu.SetActive(true);

            if (audioManager != null)
            {
                audioManager.PlayButtonClip();

            }

        }
        else
        {
            isShow = false;
            filterButtonsMenu.SetActive(false);

            if (audioManager != null)
            {
                audioManager.PlayButtonClip();

            }

        }
    }

    public void ShowAllBooks()
    {
        // ẩn các nút khác đi chỉ để lại nút all
        allButton.SetActive(true);
        newButton.SetActive(false);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(false);
        checkButton.SetActive(false);

        // ấn vào r thì tắt menu filter buttons đi và chỉnh lại biến bool, bật âm thanh
        TurnOffFilterMenu();
    }

    public void FilterNewBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(true);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(false);
        checkButton.SetActive(false);

        TurnOffFilterMenu();
    }

    public void FilterHourglassBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(false);
        hourglassButton.SetActive(true);
        heartsButton.SetActive(false);
        checkButton.SetActive(false);

        TurnOffFilterMenu();
    }

    public void FilterHeartsBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(false);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(true);
        checkButton.SetActive(false);

        TurnOffFilterMenu();
    }

    public void FilterCheckBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(false);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(false);
        checkButton.SetActive(true);

        TurnOffFilterMenu();
    }

    void TurnOffFilterMenu()
    {
        isShow = false;
        filterButtonsMenu.SetActive(false);
        audioManager.PlayButtonClip();
    }
}

#endregion
