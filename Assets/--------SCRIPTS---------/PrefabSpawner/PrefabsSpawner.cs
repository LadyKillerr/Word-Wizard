using System.Collections;
using UnityEngine;

public class PrefabsSpawner : MonoBehaviour
{

    // hidden components
    GameObject spawnedObject;
    AudioManager audioManager;

    [Header("Open Components")]
    [SerializeField] GameObject transitionsAnim;
    [SerializeField] GameObject storyListPanel;


    [SerializeField] GameObject storySpawnTarget;

    [Header("Prefabs to Spawn")]
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

    public void StartTogglePrefabsSpawning(int prefabsIndex)
    {
        if (audioManager != null)
        {
            audioManager.PlayStartAudio();

        }

        // bắt đầu đợi 2s để anim chạy
        StartCoroutine(TooglePrefabsSpawning(prefabsIndex));

        // anim chạy trong khoảng 1.5s 
        transitionsAnim.GetComponent<Animator>().SetTrigger("end");

        StartCoroutine(ResetTransitionGameObject());
    }

    IEnumerator TooglePrefabsSpawning(int quizValue)
    {
        // ngưng load tầm 1.5s để anim chạy, xong thì sẽ bdau hiện ra quiz 
        yield return new WaitForSeconds(1.5f);

        // sau khi đợi 1.5s để start anim chạy xong -> màn đen xì sẽ bdau load ra question
        storyListPanel.SetActive(false);

        



        switch (quizValue)
        {
            case 0:
                // instantiate ra cái quiz section tương ứng ( CatAndTheBat section sẽ là 0 giống trong StoryID.txt)

                // Instantiate GameObject
                spawnedObject = Instantiate(catAndTheBatPrefab, storySpawnTarget.transform);
                break;

            case 1:
                // Instantiate GameObject
                spawnedObject = Instantiate(bennyTheBunnyPrefab, storySpawnTarget.transform);
                break;

            case 2:
                // Instantiate GameObject
                spawnedObject = Instantiate(caseyTheCatPrefab, storySpawnTarget.transform);
                break;

            case 3:
                // Instantiate GameObject
                spawnedObject = Instantiate(dannyTheDogPrefab, storySpawnTarget.transform);
                break;

            case 4:
                // Instantiate GameObject
                spawnedObject = Instantiate(ellieTheElephantPrefab, storySpawnTarget.transform);
                break;

            case 5:
                // Instantiate GameObject
                spawnedObject = Instantiate(freddyTheFishPrefab, storySpawnTarget.transform);
                break;

            case 6:
                // Instantiate GameObject
                spawnedObject = Instantiate(ginaTheGoosePrefab, storySpawnTarget.transform);
                break;

            case 7:
                // Instantiate GameObject
                spawnedObject = Instantiate(henryTheHedgehogPrefab, storySpawnTarget.transform);
                break;

            case 8:
                // Instantiate GameObject
                spawnedObject = Instantiate(ivyTheIguanaPrefab, storySpawnTarget.transform);
                break;
        }

        // Set Anchor để gameObject neo full màn hình
        //rectTransform.anchorMin = Vector2.zero;
        //rectTransform.anchorMax = Vector2.one;
        //rectTransform.anchoredPosition = Vector2.zero;
        //rectTransform.sizeDelta = Vector2.zero;
    }

    // sau khi chạy lần đầu vào thì phải tắt anim đi không thì các câu hỏi sau cũng phải chờ
    IEnumerator ResetTransitionGameObject()
    {
        yield return new WaitForSeconds(2.5f);

        transitionsAnim.SetActive(false);
        transitionsAnim.GetComponent<Animator>().enabled = false;
    }

    public void ActivateQuizAnim()
    {
        transitionsAnim.SetActive(true);
        transitionsAnim.GetComponent<Animator>().enabled = true;
    }

}
