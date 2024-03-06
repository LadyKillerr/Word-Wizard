using UnityEngine;

public class StatusManager : MonoBehaviour
{
    int catAndBatStatus;
    [SerializeField] GameObject catAndBatDone;
    [SerializeField] GameObject catAndBatPending;

    private void Awake()
    {
        int catAndBatStatus = PlayerPrefs.GetInt("CatAndTheBat");

    }

    void Start()
    {
        checkCatAndBat();

    }


    void Update()
    {
        checkCatAndBat();

    }

    void checkCatAndBat()
    {
        catAndBatStatus = PlayerPrefs.GetInt("CatAndTheBat");
        if (catAndBatStatus == 1)
        {
            catAndBatDone.SetActive(true);
            catAndBatPending.SetActive(false);

            Debug.Log("Cat and bat is good");
        }
        else if (catAndBatStatus == 2)
        {
            catAndBatDone.SetActive(false);
            catAndBatPending.SetActive(true);
            Debug.Log("Cat and bat is pending");
        }
        else if (catAndBatStatus == 0)
        {
            catAndBatDone.SetActive(false);
            catAndBatPending.SetActive(false);
            Debug.Log("Cat and bat is fresh");
        }
    }
}
