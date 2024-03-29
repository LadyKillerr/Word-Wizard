using System;
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
        checkCatAndTheBat();

        checkBennyTheBunny();

        checkCaseyTheCat();

        checkDannyTheDog();

        checkEllieTheElephant();

        checkFreddyTheFish();
    }

    private void checkFreddyTheFish()
    {
        freddyTheFishStatus = PlayerPrefs.GetInt(story5PrefName);
        if (freddyTheFishStatus == 1)
        {
            // 1 là đã hoàn thành
            ellieTheElephantDone.SetActive(true);
            ellieTheElephantPending.SetActive(false);


        }
        else if (freddyTheFishStatus == 2)
        {
            // 2 là đang pending
            ellieTheElephantDone.SetActive(false);
            ellieTheElephantPending.SetActive(true);

        }
        else if (freddyTheFishStatus == 0)
        {
            // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
            ellieTheElephantDone.SetActive(false);
            ellieTheElephantPending.SetActive(false);

        }
    }

    void checkEllieTheElephant()
    {
        ellieTheElephantStatus = PlayerPrefs.GetInt(story5PrefName);
        if (ellieTheElephantStatus == 1)
        {
            // 1 là đã hoàn thành
            ellieTheElephantDone.SetActive(true);
            ellieTheElephantPending.SetActive(false);


        }
        else if (ellieTheElephantStatus == 2)
        {
            // 2 là đang pending
            ellieTheElephantDone.SetActive(false);
            ellieTheElephantPending.SetActive(true);

        }
        else if (ellieTheElephantStatus == 0)
        {
            // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
            ellieTheElephantDone.SetActive(false);
            ellieTheElephantPending.SetActive(false);

        }
    }

    void checkCatAndTheBat()
    {
        catAndBatStatus = PlayerPrefs.GetInt(story1PrefName);
        if (catAndBatStatus == 1)
        {
            // 1 là đã hoàn thành
            catAndBatDone.SetActive(true);
            catAndBatPending.SetActive(false);


        }
        else if (catAndBatStatus == 2)
        {
            // 2 là đang pending
            catAndBatDone.SetActive(false);
            catAndBatPending.SetActive(true);

        }
        else if (catAndBatStatus == 0)
        {
            // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
            catAndBatDone.SetActive(false);
            catAndBatPending.SetActive(false);

        }
    }

    void checkBennyTheBunny()
    {
        bennyTheBunnyStatus = PlayerPrefs.GetInt(story1PrefName);
        if (bennyTheBunnyStatus == 1)
        {
            bennyBunnyDone.SetActive(true);
            bennyBunnyPending.SetActive(false);


        }
        else if (bennyTheBunnyStatus == 2)
        {
            bennyBunnyDone.SetActive(false);
            bennyBunnyPending.SetActive(true);

        }
        else if (bennyTheBunnyStatus == 0)
        {
            bennyBunnyDone.SetActive(false);
            bennyBunnyPending.SetActive(false);

        }
    }

    void checkCaseyTheCat()
    {
        caseyTheCatStatus = PlayerPrefs.GetInt(story3PrefName);
        if (caseyTheCatStatus == 1)
        {
            caseyTheCatDone.SetActive(true);
            caseyTheCatPending.SetActive(false);


        }
        else if (caseyTheCatStatus == 2)
        {
            caseyTheCatDone.SetActive(false);
            caseyTheCatPending.SetActive(true);

        }
        else if (caseyTheCatStatus == 0)
        {
            bennyBunnyDone.SetActive(false);
            bennyBunnyPending.SetActive(false);

        }
    }

    void checkDannyTheDog()
    {
        dannyTheDogStatus = PlayerPrefs.GetInt(story4PrefName);
        if (catAndBatStatus == 1)
        {
            // 1 là đã hoàn thành
            dannyTheDogDone.SetActive(true);
            dannyTheDogPending.SetActive(false);


        }
        else if (dannyTheDogStatus == 2)
        {
            // 2 là đang pending
            dannyTheDogDone.SetActive(false);
            dannyTheDogPending.SetActive(true);

        }
        else if (dannyTheDogStatus == 0)
        {
            // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
            dannyTheDogDone.SetActive(false);
            dannyTheDogPending.SetActive(false);

        }
    }
}
