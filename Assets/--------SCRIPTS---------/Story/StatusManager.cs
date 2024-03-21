﻿using UnityEngine;

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

    [Header("CalebTheCat Story")]
    int calebTheCatStatus;
    [SerializeField] string story3PrefName;
    [SerializeField] GameObject calebTheCatDone;
    [SerializeField] GameObject calebTheCatPending;

    private void Awake()
    {


    }

    void Start()
    {
        checkCatAndTheBat();

        checkBennyTheBunny();

        checkCalebTheCat();
    }


    void Update()
    {
        checkCatAndTheBat();
        checkBennyTheBunny();

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

    void checkCalebTheCat()
    {
        calebTheCatStatus = PlayerPrefs.GetInt(story3PrefName);
        if (calebTheCatStatus == 1)
        {
            calebTheCatDone.SetActive(true);
            calebTheCatPending.SetActive(false);


        }
        else if (calebTheCatStatus == 2)
        {
            calebTheCatDone.SetActive(false);
            calebTheCatPending.SetActive(true);

        }
        else if (calebTheCatStatus == 0)
        {
            bennyBunnyDone.SetActive(false);
            bennyBunnyPending.SetActive(false);

        }
    }
}
