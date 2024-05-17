using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PrefabsSpawner : MonoBehaviour
{

    // hidden components

    AudioManager audioManager;
     
    [SerializeField] bool isSelected = false;

    [Header("Open Components")]
    [SerializeField] GameObject transitionsAnim;
    [SerializeField] GameObject storyListPanel;

    [SerializeField] GameObject objectSpawnTarget;

    [SerializeField] float delayBeforeSpawnPrefabs = .5f;


    [Header("Scaling Cordinates")]
    [SerializeField] Vector3 originalScale;
    [SerializeField] Vector3 endTweenScale;
    [SerializeField] float tweenTime = 0.75f;



    [Header("Selection screen prefabs to Spawn")]
    [SerializeField] GameObject catAndTheBatThumbnail;
    [SerializeField] GameObject BennyTheBunnyThumbnail;
    [SerializeField] GameObject CaseyTheCatThumbnail;
    [SerializeField] GameObject DannyTheDogThumbnail;
    [SerializeField] GameObject EllieTheElephantThumbnail;
    [SerializeField] GameObject FreddyTheFishThumbnail;
    [SerializeField] GameObject GinaTheGooseThumbnail;
    [SerializeField] GameObject HenryTheHedgehogThumbnail;
    [SerializeField] GameObject IvyTheIguanaThumbnail;
    [SerializeField] GameObject JaxTheJaguarThumbnail;



    [Header("Story prefabs to Spawn")]
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
    [SerializeField] GameObject jaxTheJaguarStoryPrefab;

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
    [SerializeField] GameObject jaxTheJaguarQuizPrefab;

    StatusManager statusManager;

    private void Awake()
    {
        statusManager = FindAnyObjectByType<StatusManager>();

        isSelected = false;

        transitionsAnim.GetComponent<Animator>().SetTrigger("start");
        audioManager = FindAnyObjectByType<AudioManager>();

    }


    #region SelectionPanel Section

    public void ShowSelectionPanel(int index)
    {

        if (!isSelected)
        {
            switch (index)
            {
                case 0:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(catAndTheBatThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 1:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(BennyTheBunnyThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;
                case 2:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(CaseyTheCatThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 3:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(DannyTheDogThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 4:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(EllieTheElephantThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 5:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(FreddyTheFishThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 6:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(GinaTheGooseThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 7:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(HenryTheHedgehogThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 8:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(IvyTheIguanaThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;

                case 9:
                    // spawn ra prefabs cần thiết là phần tử con của ObjectSpawnTarget
                    Instantiate(JaxTheJaguarThumbnail, objectSpawnTarget.transform);


                    objectSpawnTarget.transform.GetChild(0).transform.localScale = new Vector2(0, 0);

                    // anim chạy trong khoảng tweenTime 
                    objectSpawnTarget.transform.GetChild(0).transform.DOScale(endTweenScale, tweenTime)
                        .SetEase(Ease.InOutSine);

                    break;
            }
        }

        // biến truyền vào sẽ được lưu vào prefabsIndex 
        prefabsIndex = index;

        isSelected = true;
        StartCoroutine(ResetIsSelected(tweenTime));
    }



    public void HideSelectionPanel()
    {
        statusManager.CheckAllStatus();

        if (!isSelected)
        {
            // track ra child của object vừa spawn vào và thu nhỏ nó lại
            objectSpawnTarget.transform.GetChild(0).transform.DOScale(originalScale, tweenTime)
        .SetEase(Ease.InSine);

            isSelected = true;
            StartCoroutine(ResetIsSelected(tweenTime));
        }
    }

    public void KillSelectionPanel()
    {
        if (!isSelected)
        {
            // track ra child của object vừa spawn vào và thu nhỏ nó lại
            objectSpawnTarget.transform.GetChild(0).transform.DOScale(originalScale, tweenTime)
        .SetEase(Ease.InSine);


            isSelected = true;
            StartCoroutine(ResetIsSelected(tweenTime));

            StartCoroutine(DestroySelectionPanel(tweenTime));
        }
    }

    IEnumerator DestroySelectionPanel(float delay)
    {
        yield return new WaitForSeconds(delay);

        // lặp qua các phần tử selectionPanel được spawn ra và kill hết đi 
        foreach (Transform child in objectSpawnTarget.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    #endregion

    #region SpawnedPrefabs

    public void DestroyStoryPrefabs()
    {
        ActivateStoryList();

        // mở lại selectionPanel
        objectSpawnTarget.transform.GetChild(objectSpawnTarget.transform.childCount - 2).transform.localScale = new Vector2(1, 1);

        // get ra phần tử cuối cùng trong objectSpawnTarget
        objectSpawnTarget.transform.GetChild(objectSpawnTarget.transform.childCount - 1).transform.DOScale(originalScale, tweenTime);

        Debug.Log("đã thu nhỏ quiz prefab");

        DestroyGameObject(tweenTime);
    }

    public void DestroyGameObject(float delay)
    {
        StartCoroutine(KillCurrentStory(tweenTime));

    }

    public IEnumerator KillCurrentStory(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject.Destroy(objectSpawnTarget.transform.GetChild(objectSpawnTarget.transform.childCount - 1).gameObject);
    }
    #endregion

    #region SpawningStoryAndQuizPrefabs

    public int GetPrefabsIndex()
    {
        return prefabsIndex;
    }

    public void SpawnStoryPrefabs(int storyPrefabsValue)
    {

        if (!isSelected)
        {
            if (audioManager != null)
            {
                audioManager.PlayStartAudio();

            }

            Debug.Log("Load anim chuyển màn");


            // chạy anim chuyển màn
            transitionsAnim.GetComponent<Animator>().SetTrigger("end");
            //StartCoroutine(ResetTransitionGameObject());

            // scale khung lựa chọn nhỏ lại
            HideSelectionPanel();

            StartCoroutine(ToogleStoryPrefabs(storyPrefabsValue));

            // ngăn không cho ấn liên tục bug game
            isSelected = true;
            StartCoroutine(ResetIsSelected(tweenTime));
        }
    }

    public void SpawnQuizPrefabs(int quizPrefabsValue)
    {
        if (!isSelected)
        {

            if (audioManager != null)
            {
                audioManager.PlayStartAudio();

            }

            // chạy anim chuyển màn
            transitionsAnim.GetComponent<Animator>().SetTrigger("end");
            //StartCoroutine(ResetTransitionGameObject());

            // scale khung lựa chọn nhỏ lại
            HideSelectionPanel();

            StartCoroutine(ToogleQuizPrefabs(quizPrefabsValue));


            isSelected = true;

            StartCoroutine(ResetIsSelected(tweenTime));
        }
    }

    IEnumerator ToogleStoryPrefabs(int storyPrefabsValue)
    {
        // ngưng load tầm 1s để anim chạy, xong thì sẽ bdau hiện ra prefabs 
        yield return new WaitForSeconds(delayBeforeSpawnPrefabs);

        // sau khi đợi 1s để start anim chạy xong -> màn đen xì sẽ bdau load ra question
        storyListPanel.SetActive(false);

        switch (storyPrefabsValue)
        {
            case 0:
                // instantiate ra cái quiz section tương ứng ( CatAndTheBat section sẽ là 0 giống trong StoryID.txt)

                // Instantiate GameObject
                Instantiate(catAndTheBatStoryPrefab, objectSpawnTarget.transform);
                break;

            case 1:
                // Instantiate GameObject
                Instantiate(bennyTheBunnyStoryPrefab, objectSpawnTarget.transform);
                break;

            case 2:
                // Instantiate GameObject
                Instantiate(caseyTheCatStoryPrefab, objectSpawnTarget.transform);
                break;

            case 3:
                // Instantiate GameObject
                Instantiate(dannyTheDogStoryPrefab, objectSpawnTarget.transform);
                break;

            case 4:
                // Instantiate GameObject
                Instantiate(ellieTheElephantStoryPrefab, objectSpawnTarget.transform);
                break;

            case 5:
                // Instantiate GameObject
                Instantiate(freddyTheFishStoryPrefab, objectSpawnTarget.transform);
                break;

            case 6:
                // Instantiate GameObject
                Instantiate(ginaTheGooseStoryPrefab, objectSpawnTarget.transform);
                break;

            case 7:
                // Instantiate GameObject
                Instantiate(henryTheHedgehogStoryPrefab, objectSpawnTarget.transform);
                break;

            case 8:
                // Instantiate GameObject
                Instantiate(ivyTheIguanaStoryPrefab, objectSpawnTarget.transform);
                break;

            case 9:
                Instantiate(jaxTheJaguarStoryPrefab, objectSpawnTarget.transform);
                break;

        }
    }

    IEnumerator ToogleQuizPrefabs(int quizPrefabsValue)
    {
        // ngưng load tầm 1s để anim chạy, xong thì sẽ bdau hiện ra quiz 
        yield return new WaitForSeconds(delayBeforeSpawnPrefabs);

        // sau khi đợi 1s để start anim chạy xong -> màn đen xì sẽ bdau load ra question
        storyListPanel.SetActive(false);

        switch (quizPrefabsValue)
        {
            case 0:
                // instantiate ra cái quiz section tương ứng ( CatAndTheBat section sẽ là 0 giống trong StoryID.txt)

                // Instantiate GameObject
                Instantiate(catAndTheBatQuizPrefab, objectSpawnTarget.transform);
                break;

            case 1:
                // Instantiate GameObject
                Instantiate(bennyTheBunnyQuizPrefab, objectSpawnTarget.transform);
                break;

            case 2:
                // Instantiate GameObject
                Instantiate(caseyTheCatQuizPrefab, objectSpawnTarget.transform);
                break;

            case 3:
                // Instantiate GameObject
                Instantiate(dannyTheDogQuizPrefab, objectSpawnTarget.transform);
                break;

            case 4:
                // Instantiate GameObject
                Instantiate(ellieTheElephantQuizPrefab, objectSpawnTarget.transform);
                break;

            case 5:
                // Instantiate GameObject
                Instantiate(freddyTheFishQuizPrefab, objectSpawnTarget.transform);
                break;

            case 6:
                // Instantiate GameObject
                Instantiate(ginaTheGooseQuizPrefab, objectSpawnTarget.transform);
                break;

            case 7:
                // Instantiate GameObject
                Instantiate(henryTheHedgehogQuizPrefab, objectSpawnTarget.transform);
                break;

            case 8:
                // Instantiate GameObject
                Instantiate(ivyTheIguanaQuizPrefab, objectSpawnTarget.transform);
                break;

            case 9:
                // Instantiate GameObject
                Instantiate(jaxTheJaguarQuizPrefab, objectSpawnTarget.transform);
                break;
        }
    } 
    #endregion

    // sau khi chạy lần đầu vào thì phải tắt anim đi không thì các câu hỏi sau cũng phải chờ
    IEnumerator ResetTransitionGameObject()
    {
        yield return new WaitForSeconds(3f);

        //transitionsAnim.SetActive(false);
        transitionsAnim.GetComponent<Animator>().enabled = false;
    }

    public void ActivateQuizAnim()
    {
        transitionsAnim.SetActive(true);
        transitionsAnim.GetComponent<Animator>().enabled = true;
    }

    IEnumerator ResetIsSelected(float delay)
    {
        yield return new WaitForSeconds(delay);

        isSelected = false;
    }

    public void ActivateStoryList()
    {
        storyListPanel.SetActive(true);
    }


}
