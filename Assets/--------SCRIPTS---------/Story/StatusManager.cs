using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [Header("CatAndTheBat Story")]
    [SerializeField] string story1PrefName;
    [SerializeField] GameObject catAndBatDone;
    [SerializeField] GameObject catAndBatPending;
    [SerializeField] GameObject catAndBatNew;
    int catAndBatStatus;

    [Header("BennyTheBunny Story")]
    [SerializeField] string story2PrefName;
    [SerializeField] GameObject bennyBunnyDone;
    [SerializeField] GameObject bennyBunnyPending;
    [SerializeField] GameObject bennyTheBunnyNew;

    int bennyTheBunnyStatus;

    [Header("CaseyTheCat Story")]
    [SerializeField] string story3PrefName;
    [SerializeField] GameObject caseyTheCatDone;
    [SerializeField] GameObject caseyTheCatPending;
    [SerializeField] GameObject caseyTheCatNew;

    int caseyTheCatStatus;

    [Header("DannyTheDog Story")]
    [SerializeField] string story4PrefName;
    [SerializeField] GameObject dannyTheDogDone;
    [SerializeField] GameObject dannyTheDogPending;
    [SerializeField] GameObject dannyTheDogNew;

    int dannyTheDogStatus;

    [Header("EllieTheElephant Story")]
    [SerializeField] string story5PrefName;
    [SerializeField] GameObject ellieTheElephantDone;
    [SerializeField] GameObject ellieTheElephantPending;
    [SerializeField] GameObject ellieTheElephantNew;

    int ellieTheElephantStatus;

    [Header("FreddyTheFish Story")]
    [SerializeField] string story6PrefName;
    [SerializeField] GameObject freddyTheFishDone;
    [SerializeField] GameObject freddyTheFishPending;
    [SerializeField] GameObject freddyTheFishNew;

    int freddyTheFishStatus;

    [Header("GinaTheGoose Story")]
    [SerializeField] string story7PrefName;
    [SerializeField] GameObject ginaTheGooseDone;
    [SerializeField] GameObject ginaTheGoosePending;


    int ginaTheGooseStatus;

    [Header("HenryTheHedgehog Story")]
    [SerializeField] string story8PrefName;
    [SerializeField] GameObject henryTheHedgehogDone;
    [SerializeField] GameObject henryTheHedgehogPending;
    [SerializeField] GameObject henryTheHedgehogNew;

    int henryTheHedgehogStatus;

    [Header("IvyTheIguana Story")]
    [SerializeField] string story9PrefName;
    [SerializeField] GameObject ivyTheIguanaDone;
    [SerializeField] GameObject ivyTheIguanaPending;
    [SerializeField] GameObject ivyTheIguanaNew;


    int ivyTheIguanaStatus;

    [Header("JaxTheJaguar Story")]
    [SerializeField] string story10PrefName;
    [SerializeField] GameObject jaxTheJaguarDone;
    [SerializeField] GameObject jaxTheJaguarPending;
    [SerializeField] GameObject jaxTheJaguarNew;


    int jaxTheJaguarStatus;

    private void Awake()
    {


    }

    void Start()
    {
        CheckAllStatus();
    }

    public void CheckAllStatus()
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

        CheckJaxTheJaguar();



    }

    private void CheckJaxTheJaguar()
    {
        jaxTheJaguarStatus = PlayerPrefs.GetInt(story10PrefName);

        switch (jaxTheJaguarStatus)
        {

            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                jaxTheJaguarDone.SetActive(false);
                jaxTheJaguarPending.SetActive(false);
                break;
            case 1:
                jaxTheJaguarNew.SetActive(false);
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                jaxTheJaguarDone.SetActive(true);
                jaxTheJaguarPending.SetActive(false);
                break;
            case 2:
                jaxTheJaguarNew.SetActive(false);

                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                jaxTheJaguarDone.SetActive(false);
                jaxTheJaguarPending.SetActive(true);
                break;
        }
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
                ivyTheIguanaNew.SetActive(false);
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                ivyTheIguanaDone.SetActive(true);
                ivyTheIguanaPending.SetActive(false);
                break;
            case 2:
                ivyTheIguanaNew.SetActive(false);

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
                henryTheHedgehogNew.SetActive(false);
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                henryTheHedgehogDone.SetActive(true);
                henryTheHedgehogPending.SetActive(false);
                break;
            case 2:
                henryTheHedgehogNew.SetActive(false);
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
