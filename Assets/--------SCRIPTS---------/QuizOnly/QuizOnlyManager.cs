using UnityEngine;

public class QuizOnlyManager : MonoBehaviour
{
    // hidden components
    GameObject spawnedObject;
    RectTransform rectTransform;
    AudioManager audioManager;

    public Canvas quizCanvas;

    [SerializeField] GameObject quizList;

    [Header("Quiz only Prefabs")]
    [SerializeField] GameObject catAndTheBatPrefab;
    [SerializeField] GameObject bennyTheBunnyPrefab;
    [SerializeField] GameObject caseyTheCatPrefab;
    [SerializeField] GameObject dannyTheDogPrefab;
    [SerializeField] GameObject ellieTheElephantPrefab;
    [SerializeField] GameObject freddyTheFishPrefab;
    [SerializeField] GameObject ginaTheGoosePrefab;
    [SerializeField] GameObject henryTheHedgehogPrefab;
    [SerializeField] GameObject ivyTheIguanaPrefab;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void ToggleQuizSection(int quizValue)
    {
        quizList.SetActive(false);
        if (audioManager != null)
        {
            audioManager.PlayStartAudio();

        }

        switch (quizValue)
        {
            case 0:
                // instantiate ra cái quiz section tương ứng ( CatAndTheBat section sẽ là 0 giống trong StoryID.txt)

                // Instantiate GameObject
                spawnedObject = Instantiate(catAndTheBatPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;

            case 1:
                // Instantiate GameObject
                spawnedObject = Instantiate(bennyTheBunnyPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;

            case 2:
                // Instantiate GameObject
                spawnedObject = Instantiate(caseyTheCatPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;

            case 3:
                // Instantiate GameObject
                spawnedObject = Instantiate(dannyTheDogPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;

            case 4:
                // Instantiate GameObject
                spawnedObject = Instantiate(ellieTheElephantPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;

            case 5:
                // Instantiate GameObject
                spawnedObject = Instantiate(freddyTheFishPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;


                break;

            case 6:
                // Instantiate GameObject
                spawnedObject = Instantiate(ginaTheGoosePrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;

            case 7:
                // Instantiate GameObject
                spawnedObject = Instantiate(henryTheHedgehogPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;

            case 8:
                // Instantiate GameObject
                spawnedObject = Instantiate(ivyTheIguanaPrefab, quizCanvas.transform);

                // Thiết lập RectTransform của GameObject
                rectTransform = spawnedObject.GetComponent<RectTransform>();

                // Set Anchor để gameObject neo full màn hình
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;

                break;




        }
    }
}
