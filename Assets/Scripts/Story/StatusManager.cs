using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [Header("CatAndTheBat Story")]
    int catAndBatStatus;
    [SerializeField] string levelPrefName;
    [SerializeField] GameObject catAndBatDone;
    [SerializeField] GameObject catAndBatPending;

    private void Awake()
    {


    }

    void Start()
    {
        checkCatAndTheBat();

    }


    void Update()
    {
        checkCatAndTheBat();

    }

    void checkCatAndTheBat()
    {
        catAndBatStatus = PlayerPrefs.GetInt(levelPrefName);
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
