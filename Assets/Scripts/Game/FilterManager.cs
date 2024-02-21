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


    AudioManager audioManager;

    bool isShow;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

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

            audioManager.PlayButtonClip();

        }
        else
        {
            isShow = false;
            filterButtonsMenu.SetActive(false);
            audioManager.PlayButtonClip();

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
        isShow = false;
        filterButtonsMenu.SetActive(false);
        audioManager.PlayButtonClip();
    }

    public void FilterNewBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(true);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(false);
        checkButton.SetActive(false);

        isShow = false;
        filterButtonsMenu.SetActive(false);
        audioManager.PlayButtonClip();
    }

    public void FilterHourglassBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(false);
        hourglassButton.SetActive(true);
        heartsButton.SetActive(false);
        checkButton.SetActive(false);

        isShow = false;
        filterButtonsMenu.SetActive(false);
        audioManager.PlayButtonClip();
    }

    public void FilterHeartsBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(false);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(true);
        checkButton.SetActive(false);

        isShow = false;
        filterButtonsMenu.SetActive(false);
        audioManager.PlayButtonClip();
    }

    public void FilterCheckBooks()
    {
        allButton.SetActive(false);
        newButton.SetActive(false);
        hourglassButton.SetActive(false);
        heartsButton.SetActive(false);
        checkButton.SetActive(true);

        isShow = false;
        filterButtonsMenu.SetActive(false);
        audioManager.PlayButtonClip();
    }
}
