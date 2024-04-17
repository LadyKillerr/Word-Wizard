using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterManager : MonoBehaviour
{
    [SerializeField] List<GameObject> filterButtons;

    // filter buttons
    [SerializeField] GameObject allButton;
    [SerializeField] GameObject newButton;
    [SerializeField] GameObject hourglassButton;
    [SerializeField] GameObject heartsButton;
    [SerializeField] GameObject checkButton;

    [SerializeField] float pullUpAnim = 1f;
    // all filter buttons menu


    // book count list
    //public List<GameObject> totalBooks;

    AudioManager audioManager;
    Animator allButtonAnimator;

    Image filterButtonsImage;
    Animator filterButtonsAnimator;



    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        allButtonAnimator = allButton.GetComponent<Animator>();
        
    }

    void Start()
    {

    }


    void Update()
    {

    }

    void FindActiveButton()
    {
        for (int i = 0; i < filterButtons.Count; i++)
        {
            if (filterButtons[i].activeSelf)
            {
                filterButtonsAnimator = filterButtons[i].GetComponent<Animator>();
                filterButtonsImage = filterButtons[i].GetComponent<Image>();


                Debug.Log("Đã tìm thấy animator hiện tại");
                break;
            }
            
        }
    }

    IEnumerator DisableAllButtons()
    {
        yield return new WaitForSeconds(pullUpAnim);
        for (int i = 0; i < filterButtons.Count; i++)
        {
            filterButtons[i].SetActive(false);
        }
    }

    public void FilterAllBooks()
    {

        FindActiveButton();


        filterButtonsAnimator.SetTrigger("Normal");
        filterButtonsImage.color = new Color(255, 255, 255, 0);

        // đợi 1s để anim chạy r sau đó mới tắt hết đi
        StartCoroutine(DisableAllButtons());


        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
        allButton.SetActive(true);

        // set active lại sau khi bị kill đi 
        StartCoroutine(ToggleAllButtons());
    }

    public void FilterNewBooks()
    {
        FindActiveButton();


        filterButtonsAnimator.SetTrigger("Normal");
        filterButtonsImage.color = new Color(255, 255, 255, 0);

        // đợi 1s để anim chạy r sau đó mới tắt hết đi
        StartCoroutine(DisableAllButtons()); ;


        // kích hoạt nút new lên thay thế nút All
        newButton.SetActive(true);

        StartCoroutine(ToggleNewButtons());



    }

    public void FilterHourglassBooks()
    {
        FindActiveButton();


        filterButtonsAnimator.SetTrigger("Normal");
        filterButtonsImage.color = new Color(255, 255, 255, 0);

        // đợi 1s để anim chạy r sau đó mới tắt hết đi
        StartCoroutine(DisableAllButtons());


        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
        hourglassButton.SetActive(true);

        // set active lại sau khi bị kill đi 
        StartCoroutine(ToggleHourglassButtons());

    }

    public void FilterHeartsBooks()
    {
        FindActiveButton();


        filterButtonsAnimator.SetTrigger("Normal");
        filterButtonsImage.color = new Color(255, 255, 255, 0);

        // đợi 1s để anim chạy r sau đó mới tắt hết đi
        StartCoroutine(DisableAllButtons());


        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
        heartsButton.SetActive(true);

        // set active lại sau khi bị kill đi 
        StartCoroutine(ToggleHeartsButtons());
    }

    public void FilterCheckBooks()
    {
        FindActiveButton();


        filterButtonsAnimator.SetTrigger("Normal");
        filterButtonsImage.color = new Color(1, 1, 1, 0);

        // đợi 1s để anim chạy r sau đó mới tắt hết đi
        StartCoroutine(DisableAllButtons());


        // kích hoạt nút new lên thay thế nút All - sau 1s sẽ bị kill đi
        checkButton.SetActive(true);

        // set active lại sau khi bị kill đi 
        StartCoroutine(ToggleCheckButtons());
    }

    IEnumerator ToggleAllButtons()
    {
        yield return new WaitForSeconds(pullUpAnim);

        allButton.SetActive(true);

    }

    IEnumerator ToggleNewButtons()
    {
        yield return new WaitForSeconds(pullUpAnim);

        newButton.SetActive(true);

    }

    IEnumerator ToggleHourglassButtons()
    {
        yield return new WaitForSeconds(pullUpAnim);

        hourglassButton.SetActive(true);

    }

    IEnumerator ToggleHeartsButtons()
    {
        yield return new WaitForSeconds(pullUpAnim);

        heartsButton.SetActive(true);

    }

    IEnumerator ToggleCheckButtons()
    {
        yield return new WaitForSeconds(pullUpAnim);

        checkButton.SetActive(true);

    }

}
