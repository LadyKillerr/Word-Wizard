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

    private void Awake()
    {


    }

    void Start()
    {
        checkCatAndTheBat();

        checkBennyTheBunny();
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
            catAndBatDone.SetActive(true);
            catAndBatPending.SetActive(false);


        }
        else if (catAndBatStatus == 2)
        {
            catAndBatDone.SetActive(false);
            catAndBatPending.SetActive(true);

        }
        else if (catAndBatStatus == 0)
        {
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
}
