using System.Collections;
using UnityEngine;

public class QuizOnlyManager : MonoBehaviour
{

    // hidden components
    GameObject spawnedObject;
    RectTransform rectTransform;
    AudioManager audioManager;

    [Header("Open Components")]
    [SerializeField] GameObject transitionsAnim;
    public Canvas quizCanvas;
    [SerializeField] GameObject quizList;
    [SerializeField] GameObject quizSpawnTarget;

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
        transitionsAnim.GetComponent<Animator>().SetTrigger("start");
        audioManager = FindAnyObjectByType<AudioManager>();

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void StartToggleQuizSection(int quizValue)
    {
        // bắt đầu đợi 2s để anim chạy
        StartCoroutine(ToggleQuizSection(quizValue));

        // anim chạy trong khoảng 2.5s (  1.5s start + 1s end)
        transitionsAnim.GetComponent<Animator>().SetTrigger("end");

        StartCoroutine(ResetTransitionGameObject());
    }

    IEnumerator ToggleQuizSection(int quizValue)
    {
        // ngưng load tầm 2s để anim chạy, sau 2.5s (1.5s cho start, 1s cho end) thì sẽ bdau hiện ra quiz 
        yield return new WaitForSeconds(1.5f);
        
        // sau khi đợi 1.5s để start anim chạy xong -> màn đen xì sẽ bdau load ra question
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
                spawnedObject = Instantiate(catAndTheBatPrefab, quizSpawnTarget.transform);

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

        // tiếp tục đợi 1s để load anim start
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator ResetTransitionGameObject()
    {
        yield return new WaitForSeconds(4);

        transitionsAnim.SetActive(false);
        transitionsAnim.GetComponent<Animator>().enabled = false;
    }

    public void ActivateQuizAnim()
    {
        transitionsAnim.SetActive(true);
        transitionsAnim.GetComponent<Animator>().enabled = true;
    }
}
