using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [Header("CatAndTheBat Story")]
    int catAndBatStatus;
    [SerializeField] string story1PrefName;
    [SerializeField] GameObject catAndBatDone;
    [SerializeField] GameObject catAndBatPending;

    [Header("BennyTheBunny Story")]
    int bennyTheBunnyStatus;
    [SerializeField] string story2PrefName;
    [SerializeField] GameObject bennyBunnyDone;
    [SerializeField] GameObject bennyBunnyPending;

    [Header("CaseyTheCat Story")]
    int caseyTheCatStatus;
    [SerializeField] string story3PrefName;
    [SerializeField] GameObject caseyTheCatDone;
    [SerializeField] GameObject caseyTheCatPending;

    [Header("DannyTheDog Story")]
    int dannyTheDogStatus;
    [SerializeField] string story4PrefName;
    [SerializeField] GameObject dannyTheDogDone;
    [SerializeField] GameObject dannyTheDogPending;

    [Header("EllieTheElephant Story")]
    int ellieTheElephantStatus;
    [SerializeField] string story5PrefName;
    [SerializeField] GameObject ellieTheElephantDone;
    [SerializeField] GameObject ellieTheElephantPending;

    [Header("FreddyTheFish Story")]
    int freddyTheFishStatus;
    [SerializeField] string story6PrefName;
    [SerializeField] GameObject freddyTheFishDone;
    [SerializeField] GameObject freddyTheFishPending;

    private void Awake()
    {


    }

    void Start()
    {
        CheckCatAndTheBat();

        CheckBennyTheBunny();

        CheckCaseyTheCat();

        CheckDannyTheDog();

        CheckEllieTheElephant();

        CheckFreddyTheFish();
    }

    private void Update()
    {

    }

    private void CheckFreddyTheFish()
    {
        freddyTheFishStatus = PlayerPrefs.GetInt(story6PrefName);

        switch (freddyTheFishStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                freddyTheFishDone.SetActive(false);
                freddyTheFishPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                freddyTheFishDone.SetActive(true);
                freddyTheFishPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                freddyTheFishDone.SetActive(false);
                freddyTheFishPending.SetActive(true);
                break;
        }
    }

    void CheckEllieTheElephant()
    {
        ellieTheElephantStatus = PlayerPrefs.GetInt(story5PrefName);

        switch (ellieTheElephantStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                ellieTheElephantDone.SetActive(false);
                ellieTheElephantPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                ellieTheElephantDone.SetActive(true);
                ellieTheElephantPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                ellieTheElephantDone.SetActive(false);
                ellieTheElephantPending.SetActive(true);
                break;
        }
    }

    void CheckDannyTheDog()
    {
        dannyTheDogStatus = PlayerPrefs.GetInt(story4PrefName);

        switch (dannyTheDogStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                dannyTheDogDone.SetActive(false);
                dannyTheDogPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                dannyTheDogDone.SetActive(true);
                dannyTheDogPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                dannyTheDogDone.SetActive(false);
                dannyTheDogPending.SetActive(true);
                break;
        }

    }

    void CheckCaseyTheCat()
    {
        caseyTheCatStatus = PlayerPrefs.GetInt(story3PrefName);

        switch (caseyTheCatStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                caseyTheCatDone.SetActive(false);
                caseyTheCatPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                caseyTheCatDone.SetActive(true);
                caseyTheCatPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                caseyTheCatDone.SetActive(false);
                caseyTheCatPending.SetActive(true);
                break;
        }
    }

    void CheckBennyTheBunny()
    {
        bennyTheBunnyStatus = PlayerPrefs.GetInt(story2PrefName);

        switch (bennyTheBunnyStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                bennyBunnyDone.SetActive(false);
                bennyBunnyPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                bennyBunnyDone.SetActive(true);
                bennyBunnyPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                bennyBunnyDone.SetActive(false);
                bennyBunnyPending.SetActive(true);
                break;
        }
    }

    void CheckCatAndTheBat()
    {
        catAndBatStatus = PlayerPrefs.GetInt(story1PrefName);

        switch (catAndBatStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                catAndBatDone.SetActive(false);
                catAndBatPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                catAndBatDone.SetActive(true);
                catAndBatPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                catAndBatDone.SetActive(false);
                catAndBatPending.SetActive(true);
                break;
        }
    }

    

    
}
