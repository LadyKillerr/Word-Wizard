using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [Header("CatAndTheBat Story")]
    [SerializeField] string story1PrefName;
    [SerializeField] GameObject catAndBatDone;
    [SerializeField] GameObject catAndBatPending;
    int catAndBatStatus;

    [Header("BennyTheBunny Story")]
    [SerializeField] string story2PrefName;
    [SerializeField] GameObject bennyBunnyDone;
    [SerializeField] GameObject bennyBunnyPending;
    int bennyTheBunnyStatus;

    [Header("CaseyTheCat Story")]
    [SerializeField] string story3PrefName;
    [SerializeField] GameObject caseyTheCatDone;
    [SerializeField] GameObject caseyTheCatPending;
    int caseyTheCatStatus;

    [Header("DannyTheDog Story")]
    [SerializeField] string story4PrefName;
    [SerializeField] GameObject dannyTheDogDone;
    [SerializeField] GameObject dannyTheDogPending;
    int dannyTheDogStatus;

    [Header("EllieTheElephant Story")]
    [SerializeField] string story5PrefName;
    [SerializeField] GameObject ellieTheElephantDone;
    [SerializeField] GameObject ellieTheElephantPending;
    int ellieTheElephantStatus;

    [Header("FreddyTheFish Story")]
    [SerializeField] string story6PrefName;
    [SerializeField] GameObject freddyTheFishDone;
    [SerializeField] GameObject freddyTheFishPending;
    int freddyTheFishStatus;

    [Header("GinaTheGoose Story")]
    [SerializeField] string story7PrefName;
    [SerializeField] GameObject ginaTheGooseDone;
    [SerializeField] GameObject ginaTheGoosePending;
    int ginaTheGooseStatus;

    [Header("HenryTheHedgehog")]
    [SerializeField] string story8PrefName;
    [SerializeField] GameObject henryTheHedgehogDone;
    [SerializeField] GameObject henryTheHedgehogPending;
    int henryTheHedgehogStatus;

    [Header("GinaTheGoose Story")]
    [SerializeField] string story9PrefName;
    [SerializeField] GameObject ivyTheIguanaDone;
    [SerializeField] GameObject ivyTheIguanaPending;
    int ivyTheIguanaStatus;

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

        CheckGinaTheGoose();

        CheckHenryTheHedgehog();

        CheckIvyTheIguana();
    }

    private void CheckIvyTheIguana()
    {
        ivyTheIguanaStatus = PlayerPrefs.GetInt(story9PrefName);

        switch (ivyTheIguanaStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                ivyTheIguanaDone.SetActive(false);
                ivyTheIguanaPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                ivyTheIguanaDone.SetActive(true);
                ivyTheIguanaPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                ivyTheIguanaDone.SetActive(false);
                ivyTheIguanaPending.SetActive(true);
                break;
        }
    }

    private void CheckHenryTheHedgehog()
    {
        henryTheHedgehogStatus = PlayerPrefs.GetInt(story8PrefName);

        switch (henryTheHedgehogStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                henryTheHedgehogDone.SetActive(false);
                henryTheHedgehogPending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                henryTheHedgehogDone.SetActive(true);
                henryTheHedgehogPending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                henryTheHedgehogDone.SetActive(false);
                henryTheHedgehogPending.SetActive(true);
                break;
        }
    }

    private void CheckGinaTheGoose()
    {
        ginaTheGooseStatus = PlayerPrefs.GetInt(story7PrefName);

        switch (ginaTheGooseStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                ginaTheGooseDone.SetActive(false);
                ginaTheGoosePending.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                ginaTheGooseDone.SetActive(true);
                ginaTheGoosePending.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                ginaTheGooseDone.SetActive(false);
                ginaTheGoosePending.SetActive(true);
                break;
        }
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
