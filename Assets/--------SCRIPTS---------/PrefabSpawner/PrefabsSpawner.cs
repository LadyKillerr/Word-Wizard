using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PrefabsSpawner : MonoBehaviour
{

    // hidden components
    GameObject spawnedObject;
    AudioManager audioManager;

    [Header("Open Components")]
    [SerializeField] GameObject transitionsAnim;
    [SerializeField] GameObject storyListPanel;
    [SerializeField] GameObject SelectionPanel;
    
    

    [Header("Scaling Cordinates")]
    [SerializeField] Vector3 originalScale;
    [SerializeField] Vector3 endTweenScale;
    [SerializeField] float tweenTime = 0.75f;



    [Header("Story prefabs to Spawn")]
    [SerializeField] GameObject objectSpawnTarget;
    [SerializeField] int prefabsIndex;
    [SerializeField] GameObject catAndTheBatStoryPrefab;
    [SerializeField] GameObject bennyTheBunnyStoryPrefab;
    [SerializeField] GameObject caseyTheCatStoryPrefab;
    [SerializeField] GameObject dannyTheDogStoryPrefab;
    [SerializeField] GameObject ellieTheElephantStoryPrefab;
    [SerializeField] GameObject freddyTheFishStoryPrefab;
    [SerializeField] GameObject ginaTheGooseStoryPrefab;
    [SerializeField] GameObject henryTheHedgehogStoryPrefab;
    [SerializeField] GameObject ivyTheIguanaStoryPrefab;

    [Header("Quiz prefabs to Spawn")]
    [SerializeField] GameObject catAndTheBatQuizPrefab;
    [SerializeField] GameObject bennyTheBunnyQuizPrefab;
    [SerializeField] GameObject caseyTheCatQuizPrefab;
    [SerializeField] GameObject dannyTheDogQuizPrefab;
    [SerializeField] GameObject ellieTheElephantQuizPrefab;
    [SerializeField] GameObject freddyTheFishQuizPrefab;
    [SerializeField] GameObject ginaTheGooseQuizPrefab;
    [SerializeField] GameObject henryTheHedgehogQuizPrefab;
    [SerializeField] GameObject ivyTheIguanaQuizPrefab;


    private void Awake()
    {
        transitionsAnim.GetComponent<Animator>().SetTrigger("start");
        audioManager = FindAnyObjectByType<AudioManager>();

    }

    public void ShowSelectionPanel(int index)
    {
        // anim chạy trong khoảng tweenTime 
        SelectionPanel.transform.DOScale(endTweenScale, tweenTime)
            .SetEase(Ease.InOutSine);

        // biến truyền vào sẽ được lưu vào prefabsIndex
        prefabsIndex = index;
    }

    public void HideSelectionPanel()
    {
        SelectionPanel.transform.DOScale(originalScale, tweenTime)
            .SetEase(Ease.InSine);
    }



    public void SpawnStoryPrefabs()
    {
        if (audioManager != null)
        {
            audioManager.PlayStartAudio();

        }
        
        // chạy anim chuyển màn
        transitionsAnim.GetComponent<Animator>().SetTrigger("end");
        StartCoroutine(ResetTransitionGameObject());

        // scale khung lựa chọn nhỏ lại
        HideSelectionPanel();

        StartCoroutine(ToogleStoryPrefabs(prefabsIndex));
        
    }

    public void SpawnQuizPrefabs()
    {
        if (audioManager != null)
        {
            audioManager.PlayStartAudio();

        }

        // chạy anim chuyển màn
        transitionsAnim.GetComponent<Animator>().SetTrigger("end");
        StartCoroutine(ResetTransitionGameObject());

        // scale khung lựa chọn nhỏ lại
        HideSelectionPanel();

        StartCoroutine(ToogleQuizPrefabs(prefabsIndex));

    }

    IEnumerator ToogleStoryPrefabs(int storyPrefabsValue)
    {
        // ngưng load tầm 1s để anim chạy, xong thì sẽ bdau hiện ra quiz 
        yield return new WaitForSeconds(1f);

        // sau khi đợi 1s để start anim chạy xong -> màn đen xì sẽ bdau load ra question
        storyListPanel.SetActive(false);

        switch (storyPrefabsValue)
        {
            case 0:
                // instantiate ra cái quiz section tương ứng ( CatAndTheBat section sẽ là 0 giống trong StoryID.txt)

                // Instantiate GameObject
                spawnedObject = Instantiate(catAndTheBatStoryPrefab, objectSpawnTarget.transform);
                break;

            case 1:
                // Instantiate GameObject
                spawnedObject = Instantiate(bennyTheBunnyStoryPrefab, objectSpawnTarget.transform);
                break;

            case 2:
                // Instantiate GameObject
                spawnedObject = Instantiate(caseyTheCatStoryPrefab, objectSpawnTarget.transform);
                break;

            case 3:
                // Instantiate GameObject
                spawnedObject = Instantiate(dannyTheDogStoryPrefab, objectSpawnTarget.transform);
                break;

            case 4:
                // Instantiate GameObject
                spawnedObject = Instantiate(ellieTheElephantStoryPrefab, objectSpawnTarget.transform);
                break;

            case 5:
                // Instantiate GameObject
                spawnedObject = Instantiate(freddyTheFishStoryPrefab, objectSpawnTarget.transform);
                break;

            case 6:
                // Instantiate GameObject
                spawnedObject = Instantiate(ginaTheGooseStoryPrefab, objectSpawnTarget.transform);
                break;

            case 7:
                // Instantiate GameObject
                spawnedObject = Instantiate(henryTheHedgehogStoryPrefab, objectSpawnTarget.transform);
                break;

            case 8:
                // Instantiate GameObject
                spawnedObject = Instantiate(ivyTheIguanaStoryPrefab, objectSpawnTarget.transform);
                break;
        }
    }

    IEnumerator ToogleQuizPrefabs(int quizPrefabsValue)
    {
        // ngưng load tầm 1s để anim chạy, xong thì sẽ bdau hiện ra quiz 
        yield return new WaitForSeconds(1f);

        // sau khi đợi 1s để start anim chạy xong -> màn đen xì sẽ bdau load ra question
        storyListPanel.SetActive(false);

        switch (quizPrefabsValue)
        {
            case 0:
                // instantiate ra cái quiz section tương ứng ( CatAndTheBat section sẽ là 0 giống trong StoryID.txt)

                // Instantiate GameObject
                spawnedObject = Instantiate(catAndTheBatQuizPrefab, objectSpawnTarget.transform);
                break;

            case 1:
                // Instantiate GameObject
                spawnedObject = Instantiate(bennyTheBunnyQuizPrefab, objectSpawnTarget.transform);
                break;

            case 2:
                // Instantiate GameObject
                spawnedObject = Instantiate(caseyTheCatQuizPrefab, objectSpawnTarget.transform);
                break;

            case 3:
                // Instantiate GameObject
                spawnedObject = Instantiate(dannyTheDogQuizPrefab, objectSpawnTarget.transform);
                break;

            case 4:
                // Instantiate GameObject
                spawnedObject = Instantiate(ellieTheElephantQuizPrefab, objectSpawnTarget.transform);
                break;

            case 5:
                // Instantiate GameObject
                spawnedObject = Instantiate(freddyTheFishQuizPrefab, objectSpawnTarget.transform);
                break;

            case 6:
                // Instantiate GameObject
                spawnedObject = Instantiate(ginaTheGooseQuizPrefab, objectSpawnTarget.transform);
                break;

            case 7:
                // Instantiate GameObject
                spawnedObject = Instantiate(henryTheHedgehogQuizPrefab, objectSpawnTarget.transform);
                break;

            case 8:
                // Instantiate GameObject
                spawnedObject = Instantiate(ivyTheIguanaQuizPrefab, objectSpawnTarget.transform);
                break;
        }
    }

    // sau khi chạy lần đầu vào thì phải tắt anim đi không thì các câu hỏi sau cũng phải chờ
    IEnumerator ResetTransitionGameObject()
    {
        yield return new WaitForSeconds(3f);

        transitionsAnim.SetActive(false);
        transitionsAnim.GetComponent<Animator>().enabled = false;
    }

    public void ActivateQuizAnim()
    {
        transitionsAnim.SetActive(true);
        transitionsAnim.GetComponent<Animator>().enabled = true;
    }

}
