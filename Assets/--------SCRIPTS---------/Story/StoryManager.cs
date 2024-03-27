
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

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

    // mảng chứa các nút bấm tương tác tương ứng với trang ảnh minh hoạ
    [SerializeField] GameObject[] hiddenButtonsParts;

    // mảng chứa các audio tương ứng với câu truyện
    [SerializeField] AudioClip[] audioParts;

    [Header("Audio Adjustment")]
    [SerializeField][Range(0, 1)] float storyVolume;

    [Header("Question time before continue")]
    [SerializeField] float delayTime = 3f;
    [SerializeField] float delayTimeSmall = .5f;
    [SerializeField] float intersectionTime = 1.5f;

    [SerializeField] bool isReading;

    [Header("Game Session Zone")]

    // phần truyện tương tác được
    [SerializeField] GameObject interactiveStorySection;

    //phần câu hỏi trắc nghiệm sau mỗi câu truyện
    [SerializeField] GameObject questionSection;

    // Phần màn hình giao giữa story và quiz section
    [SerializeField] GameObject intersectionSection;

    // Components
    AudioSource storyAudioSource;
    AudioManager gameAudioManager;
    [SerializeField] QuestionManager questionManager;

    // Swipe Handler
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;
    float swipeDistance;
    [SerializeField] float swipeThreshold = 200f;


    // flow code: Awake sẽ là LoadFirstStoryPart, sau đó tiếp tục load part các index tiếp theo dần dần thông qua nextPart và Previous Part

    void Awake()
    {
        gameAudioManager = FindAnyObjectByType<AudioManager>();

        storyAudioSource = GetComponent<AudioSource>();

        questionSection.SetActive(false);

        intersectionSection.SetActive(false);

        LoadFirstStoryPart();


        // gọi tới data warehouse
        StoryData[] gameStory = gameStoryData.LoadStoryData("story-section.json");
        //Debug.Log(gameStory.Length);
        //Debug.Log("StoryID: " + storyId);

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

    }

    void Start()
    {

    }

    private void Update()
    {
        CheckIsReading();

        if (interactiveStorySection.activeSelf)
        {
            HandlerSwipeControl();

        }
    }

    // xử lý vuốt để qua màn
    void HandlerSwipeControl()
    {
        // kiểm tra xem có hàm touch nào được thực hiện hay không
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        // Luu vi tri touch bat dau khi cham vao man hinh 
        if (touch.phase == TouchPhase.Began)
        {
            startTouchPosition = touch.position;
        }
        // kiểm tra khi touch kết thúc 
        else if (touch.phase == TouchPhase.Ended)
        {
            // luu vi tri khi touch kết thúc 
            endTouchPosition = touch.position;


            // Tính toán xem khoảng cách giữa touch bắt đầu và touch kết thúc để biết người dùng swipe về bên nào
            float swipeDistance = endTouchPosition.x - startTouchPosition.x;
            Debug.Log(swipeDistance);

            // so sánh khoảng cách đó với swipeThreshhold để biết khoảng cách có đủ lớn không 
            if (swipeDistance < -Mathf.Epsilon && Mathf.Abs(swipeDistance) > swipeThreshold)
            {
                NextPart();
            }
            else if (swipeDistance > Mathf.Epsilon && Mathf.Abs(swipeDistance) > swipeThreshold)
            {
                PreviousPart();

            }

        }

    }

    private void CheckIsReading()
    {
        if (storyAudioSource.isPlaying)
        {
            isReading = true;
        }
        else
        {
            isReading = false;
        }
    }

    void LoadFirstStoryPart()
    {
        // tắt hết đi và reset index
        HideAllStoryParts();
        HideAllImageParts();
        MuteAllAudioParts();
        HideAllHiddenButtons();

        // reset index
        currentIndex = 0;

        // kích hoạt phần interactive story section
        ActivateStoryPart();

        // hiện story Parts đầu tiên
        PlayCurrentStoryPart();

        // hiện image parts đầu tiên 
        PlayCurrentImagePart();

        // bật hidden buttons section đầu tiên
        PlayCurrentHiddenButtons();

        // chạy âm thanh của trang truyện đầu tiên sau chừng delayTimeSmall
        Invoke("PlayCurrentAudioParts", delayTimeSmall);
    }

    // load ra part tương ứng với index
    void LoadParts()
    {
        // load ra hình với ảnh và câu hỏi ẩn của index phù hợp
        storyParts[currentIndex].SetActive(true);

        imageParts[currentIndex].SetActive(true);

        hiddenButtonsParts[currentIndex].SetActive(true);

        // load ra âm thanh của index phù hợp sau chừng delayTimeSmall
        Invoke("PlayCurrentAudioParts", delayTimeSmall);
    }


    // Lien kết file và viết hàm set indexx = 9
    // Set currentIndex về index cuối cùng của trang story
    public void SetCurrentIndex()
    {
        currentIndex = storyParts.Length - 1;
    }


    // chức năng sang trang tiếp theo của trang sách
    public void NextPart()
    {
        // nếu index chưa phải max (chưa phải part cuối trong 1 câu truyện)
        // trừ 1 vì bắt đầu từ mảng bắt đầu từ 0
        if (currentIndex >= 0 && currentIndex < storyParts.Length - 1 && !isReading)
        {

            // ẩn hình với truyện hiện tại đi
            HideCurrentImagePart();
            HideCurrentStoryPart();
            HideCurrentHiddenButtons();
            MuteAllAudioParts();


            currentIndex += 1;

            gameAudioManager.PlayPageTurningClip();

            // tăng index lên sau khi đã ẩn hình với ảnh hiện tại đi
            LoadParts();


        }
        // nếu index đã max (là part cuối trong 1 câu truyện)
        else if (currentIndex >= 0 && currentIndex >= storyParts.Length - 1 && !isReading)
        {
            // tắt âm thanh màn stories
            MuteAllAudioParts();


            // load ra màn hình câu hỏi trắc nghiệm, sẽ có câu hỏi riêng để ng chơi trả lời trắc nghiệm
            // ẩn hết màn hình câu hỏi đi 
            interactiveStorySection.SetActive(false);

            gameAudioManager.PlayPageTurningClip();

            // bật intersection
            ToggleIntersection();


        }
    }

    // chức năng back lại trang cũ
    public void PreviousPart()
    {
        if (currentIndex > 0 && currentIndex <= storyParts.Length - 1)
        {


            // ẩn hình với truyện hiện tại đi
            HideCurrentImagePart();
            HideCurrentStoryPart();
            HideCurrentHiddenButtons();
            MuteAllAudioParts();

            // giảm index đi để lùi trang truyện và trang tranh về trang trước 
            currentIndex -= 1;

            gameAudioManager.PlayPageTurningClip();

            // load ra trang tương ứng với index mới trừ đó
            LoadParts();
        }
        else if (currentIndex == 0 && currentIndex < storyParts.Length - 1)
        {
            // nếu đã back về scene đầu tiên rồi thì không lùi được nữa
            return;
        }
    }

    // bật đoạn giao giữa 2 scene story và quiz
    void ToggleIntersection()
    {
        intersectionSection.SetActive(true);



        StartCoroutine(DisableIntersection());


    }

    IEnumerator DisableIntersection()
    {
        yield return new WaitForSecondsRealtime(intersectionTime);

        intersectionSection.SetActive(false);

        // bật màn hình câu hỏi
        questionSection.SetActive(true);

        // bật âm thanh câu hỏi trắc nghiệm 
        questionManager.LoadQuestionAudio();
    }


    void PlayCurrentHiddenButtons()
    {
        hiddenButtonsParts[currentIndex].SetActive(true);
    }

    void HideAllHiddenButtons()
    {
        foreach (GameObject part in hiddenButtonsParts)
        {
            part.SetActive(false);
        }
    }

    void HideCurrentHiddenButtons()
    {
        hiddenButtonsParts[currentIndex].SetActive(false);
    }

    void MuteAllAudioParts()
    {
        storyAudioSource.enabled = false;
        storyAudioSource.enabled = true;

    }

    public void PlayCurrentAudioParts()
    {
        if (!storyAudioSource.isPlaying)
        {
            storyAudioSource.PlayOneShot(audioParts[currentIndex], storyVolume);

        }
        else { return; }
    }

    void ActivateStoryPart()
    {
        interactiveStorySection.SetActive(true);
    }

    void PlayCurrentStoryPart()
    {
        storyParts[currentIndex].SetActive(true);
    }

    void HideCurrentStoryPart()
    {
        if (currentIndex >= 0 && currentIndex <= storyParts.Length)
        {
            storyParts[currentIndex].SetActive(false);
        }

    }

    void HideAllStoryParts()
    {
        foreach (GameObject part in storyParts)
        {
            part.SetActive(false);
        }
    }

    void PlayCurrentImagePart()
    {
        imageParts[currentIndex].SetActive(true);
    }

    void HideCurrentImagePart()
    {
        imageParts[currentIndex].SetActive(false);
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
        return storyParts.Length - 1;
    }

    public void ToggleLastStoryPart(int index)
    {
        currentIndex = index;

        // tắt màn hình câu hỏi
        questionSection.SetActive(false);

        // bật màn câu hỏi  
        interactiveStorySection.SetActive(true);

        // hiện story Parts tương ứng
        PlayCurrentStoryPart();

        // hiện image parts tương ứng
        PlayCurrentImagePart();

        // bật hidden buttons section tương ứng 
        PlayCurrentHiddenButtons();

        // tắt âm thanh linh tinh
        MuteAllAudioParts();

        // chạy âm thanh của index hiện tại
        PlayCurrentAudioParts();
    }
}
