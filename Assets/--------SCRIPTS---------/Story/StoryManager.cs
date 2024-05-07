using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoryManager : MonoBehaviour
{
    // nếu muốn chỉnh sửa data thì phải sửa trong file json nằm trong mục assets/StreamingAssets
    [Header("Data-Warehouse")]
    public PlayerDataWarehouse gameStoryData;

    public int storyId;

    [Header("Materials Arrays")]

    // index của story parts hiện tại
    [SerializeField] int currentIndex = 0;

    // mảng chứa các mảnh ghép của câu truyện
    [SerializeField] GameObject[] storyParts;

    // mảng chứa các hình ảnh tương ứng với câu truyện đó
    [SerializeField] GameObject[] imageParts;

    // mảng chứa các audio tương ứng với câu truyện
    [SerializeField] AudioClip[] audioParts;

    [Header("Audio Adjustment")]

    [SerializeField][Range(0, 1)] float storyVolume;

    [Header("Delay Time Variables")]
    //[SerializeField] float delayTime = 3f;
    [SerializeField] float delayFirstStoryAudio = 1.75f;
    // 1.5s anim end + 1s anim start

    [SerializeField] float delayBeforeStory = 0.75f;

    int lastIndex;
    public bool isIntersect;

    public bool isReading;

    public bool isFinishReading;

    [Header("Game Session Zone")]

    // phần truyện tương tác được
    [SerializeField] GameObject interactiveStorySection;

    //phần câu hỏi trắc nghiệm sau mỗi câu truyện
    [SerializeField] GameObject questionSection;

    // Phần màn hình giao giữa story và quiz section
    [SerializeField] GameObject intersectionSection;



    // Components
    Animator transitionsAnim;
    LoadScene levelLoader;
    AudioSource storyAudioSource;
    AudioManager audioManager;
    SwipeHandler swipeHandler;
    [SerializeField] QuestionManager questionManager;

    public bool isCheating = false;
    // flow code: Awake sẽ là LoadFirstStoryPart, sau đó tiếp tục load part các index tiếp theo dần dần thông qua nextPart và Previous Part

    // Devlopment only zone
    public bool GetIsCheating()
    {
        return isCheating;
    }

    private void Update()
    {

    }

    void Awake()
    {
        levelLoader = FindAnyObjectByType<LoadScene>();
        transitionsAnim = FindAnyObjectByType<Animator>();

        audioManager = FindAnyObjectByType<AudioManager>();

        storyAudioSource = GetComponent<AudioSource>();

        swipeHandler = FindAnyObjectByType<SwipeHandler>();

        questionSection.SetActive(false);

        intersectionSection.SetActive(false);



        HideAllImageParts();
        HideAllStoryParts();
        MuteAudio();
         
        ActivateStorySection();
        currentIndex = 0;
        // load ra hình với ảnh và câu hỏi ẩn của index phù hợp
        storyParts[currentIndex].SetActive(true);

        imageParts[currentIndex].SetActive(true);

        Invoke(nameof(PlayCurrentAudioParts), delayFirstStoryAudio);

        // reset index

        // gọi tới data warehouse
        StoryData[] gameStory = gameStoryData.LoadStoryData("story-section.json");


        // đếm xem data sentence của câu truyện thứ 2 có bnh câu
        int sentenceCount = gameStory[storyId].sentences.Count;

        for (int i = 0; i < sentenceCount; i++)
        {

            // duyẹt qua các story trong storyPart và set text của chúng dựa trên file json
            storyParts[i].GetComponent<TextMeshProUGUI>().text = gameStory[storyId].sentences[i];

            // duyet qua các prefab nút trong list nút ẩn để set text của chúng thành chữ trong json file -- chưa làm
            //hiddenButtonsText[i].GetComponent<TextMeshProUGUI>().text = gameStory[storyId].noun[i];
        }
        // storyId là để biết đang ở data truyện nào trong file json

        lastIndex = storyParts.Length - 1;

    }

    public void LoadSceneWithAnim(int sceneIndex)
    {

        // nếu có transitions anim
        if (transitionsAnim != null)
        {
            PrefabsSpawner prefabsSpawner = FindAnyObjectByType<PrefabsSpawner>();

            if (prefabsSpawner != null)
            {
                // bật lại component quiz Anim để chạy anim
                prefabsSpawner.ActivateQuizAnim();
            }

            // thì chạy coroutine đợi để anim chạy xong r mới load
            levelLoader.LoadLevelWithAnim(sceneIndex);


            Debug.Log("Run transitions anim before reload scene");
        }
        // còn nếu không phải đang ở màn có transitions anim thì load luôn(sử dụng loading screen)
        else
        {
            levelLoader.LoadLevel(sceneIndex);
            Debug.Log("Cant not find TransitionsAnim");

        }

    }

    // load ra part tương ứng với index
    void LoadParts()
    {
        // load ra hình với ảnh và câu hỏi ẩn của index phù hợp
        storyParts[currentIndex].SetActive(true);

        imageParts[currentIndex].SetActive(true);

        // bool đánh dấu đã đọc xong chưa
        isReading = false;

        isFinishReading = false;

        StartCoroutine(AutoLoadAudio(delayBeforeStory));


    }

    IEnumerator AutoLoadAudio(float delay)
    {
        yield return new WaitForSeconds(delay);

        PlayCurrentAudioParts();
    }

    void HideParts()
    {
        storyParts[currentIndex].SetActive(false);

        imageParts[currentIndex].SetActive(false);

        MuteAudio();
    }

    // chức năng sang trang tiếp theo của trang sách
    public void NextPart()
    {

        Debug.Log("NextPartActivated");
        // nếu index chưa phải max (chưa phải part cuối trong 1 câu truyện)
        // trừ 1 vì bắt đầu từ mảng bắt đầu từ 0
        if (currentIndex >= 0 && currentIndex < lastIndex && (!isReading || isCheating))
        {

            // ẩn hình với truyện hiện tại đi
            HideParts();

            MuteAudio();

            currentIndex += 1;

            if (audioManager != null)
            {
                audioManager.PlayPageTurningClip();

            }

            // tăng index lên sau khi đã ẩn hình với ảnh hiện tại đi
            LoadParts();


        }
        // nếu index đã max (là part cuối trong 1 câu truyện)
        else if (currentIndex >= 0 && currentIndex >= lastIndex && !isReading && !isIntersect)
        {


            // tắt âm thanh màn stories
            MuteAudio();

            if (audioManager != null)
            {
                audioManager.PlayPageTurningClip();

            }

            if (isIntersect == false)
            {
                // bật intersection
                ToggleIntersection();
                isIntersect = true;

            }





        }

    }

    // chức năng back lại trang cũ
    public void PreviousPart()
    {

        if (currentIndex > 0 && currentIndex <= lastIndex)
        {

            // ẩn hình với truyện hiện tại đi
            HideParts();
            MuteAudio();

            // giảm index đi để lùi trang truyện và trang tranh về trang trước 
            currentIndex -= 1;

            if (audioManager != null)
            {
                audioManager.PlayPageTurningClip();

            }

            // load ra trang tương ứng với index mới trừ đó
            LoadParts();
        }
        else if (currentIndex == 0 && currentIndex < lastIndex)
        {
            // nếu đã back về scene đầu tiên rồi thì không lùi được nữa
            return;
        }
    }

    // bật đoạn giao giữa 2 scene story và quiz
    void ToggleIntersection()
    {
        // tắt cái audioSource trên intersect đi để ngăn không cho âm thanh phát ra sớm
        intersectionSection.GetComponent<AudioSource>().enabled = false;

        // kích hoạt intersect
        intersectionSection.SetActive(true);

        intersectionSection.GetComponent<Animator>().SetTrigger("end");

        StartCoroutine(DisableIntersection());
    }

    IEnumerator DisableIntersection()
    {
        yield return new WaitForSeconds(0.5f);
        intersectionSection.GetComponent<AudioSource>().enabled = true;

        // đợi chạy anim end trước - sau 1.5s mới load quiz vào 
        yield return new WaitForSeconds(1f);
        interactiveStorySection.SetActive(false);
        questionSection.SetActive(true);

        // đợi chạy xong anim start - r mới kill intersect screen đi 
        yield return new WaitForSeconds(1f);
        intersectionSection.SetActive(false);

        // đoạn này bắt đầu đọc âm thanh question 
        questionManager.StartLoadQuestionAudio();

        isIntersect = false;
    }

    void MuteAudio()
    {
        isReading = false;
        storyAudioSource.enabled = false;
        storyAudioSource.enabled = true;

    }

    public void PlayCurrentAudioParts()
    {
        if (!storyAudioSource.isPlaying)
        {
            isReading = true;



            storyAudioSource.PlayOneShot(audioParts[currentIndex], storyVolume);
            StartCoroutine(StopReading(audioParts[currentIndex].length));
        }
        else { return; }
    }

    IEnumerator StopReading(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);



        
            // biến để set trạng thái đang đọc
            isReading = false;

            // biến riêng để set trạng thái khi đã đọc xong 
            isFinishReading = true;

        


    }

    void ActivateStorySection()
    {
        interactiveStorySection.SetActive(true);
    }

    void HideAllStoryParts()
    {
        foreach (GameObject part in storyParts)
        {
            part.SetActive(false);
        }
    }

    void HideAllImageParts()
    {
        foreach (GameObject part in imageParts)
        {
            part.SetActive(false);
        }
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public int GetTotalIndex()
    {
        return storyParts.Length;
    }

    public int GetLastPartIndex()
    {
        return lastIndex;
    }

    public void ToggleLastStoryPart(int index)
    {
        currentIndex = index;

        // tắt màn hình câu hỏi
        questionSection.SetActive(false);

        // bật màn câu hỏi  
        interactiveStorySection.SetActive(true);

        LoadParts();

        // tắt âm thanh linh tinh
        MuteAudio();

        // chạy âm thanh của index hiện tại
        PlayCurrentAudioParts();
    }

    public void LoadButtonAudio()
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonClip();

        }
    }

    // Lien kết file và viết hàm set indexx = 9
    // Set currentIndex về index cuối cùng của trang story
    public void SetCurrentIndex()
    {
        currentIndex = storyParts.Length - 1;
    }

    public bool GetIsReading()
    {
        return isReading;
    }

    public void SetIsReading(bool value)
    {
        isReading = value;
    }

    public float GetDelayBeforeStory()
    {
        return delayBeforeStory;
    }

    public bool GetIsFinishReading()
    {
        return isFinishReading;
    }

    public void SetIsFinishReading(bool value)
    {
        isFinishReading = value;
    }
}
