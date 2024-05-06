using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwipeHandler : MonoBehaviour
{
    [Header("Swipe Function")]
    [SerializeField] float swipeDistance;
    [SerializeField] float swipeThreshold = 300f;
    
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;

    [Header("Auto Flip Page Function")]
    [SerializeField] bool isAutoNextPage;
    [SerializeField] float autoFlipDelay;


    [Header("Game Components")]
    [SerializeField] StoryManager storyManager;
    [SerializeField] GameObject interactiveStorySection;

    AudioSource storyAudioSource;

    [SerializeField] Button nextButton;
    [SerializeField] Button backButton;


    private void Awake()
    {
        storyAudioSource = storyManager.GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        HandlerSwipeControl();
        AutoNextPartOnRead();

        CheckBackButton();
        CheckNextButton();
    }

    void AutoNextPartOnRead()
    {

        // nếu phần đọc truyện đang active và isReading && isAutoNextPage
        if (interactiveStorySection.activeSelf && storyManager.GetIsFinishReading() && isAutoNextPage)
        {
            StartCoroutine(AutoFlipPage());

            
        }


    }

    IEnumerator AutoFlipPage()
    {
        yield return new WaitForSeconds(autoFlipDelay);


        if (storyManager.GetIsFinishReading() && isAutoNextPage  && !storyAudioSource.isPlaying && interactiveStorySection.activeSelf)
        {
            Debug.Log("Tự động sang trang");

            storyManager.NextPart();

            storyManager.SetIsFinishReading(false);
        }

    }

    private void HandlerSwipeControl()
    {
        if (interactiveStorySection.activeSelf && Input.touchCount > 0)
        {
            //kiểm tra xem có hàm touch nào được thực hiện hay không
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
                swipeDistance = endTouchPosition.x - startTouchPosition.x;

                // so sánh khoảng cách đó với swipeThreshhold để biết khoảng cách có đủ lớn không 
                if (swipeDistance < -Mathf.Epsilon
                    && Mathf.Abs(swipeDistance) > swipeThreshold
                    && (!storyAudioSource.isPlaying || storyManager.GetIsCheating()))
                {

                    storyManager.NextPart();

                    isAutoNextPage = false;

                    // Chạy hàm vuốt sang trái
                }
                else if (swipeDistance > Mathf.Epsilon && Mathf.Abs(swipeDistance) > swipeThreshold)
                {

                    storyManager.PreviousPart();

                    isAutoNextPage = false;

                    // chạy hàm vuốt sang phải

                }

            }
        }
    }

    void CheckNextButton()
    {
        // thì bắt đầu check bthg 
        if (!storyManager.GetIsFinishReading())
        {
            nextButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            nextButton.GetComponent<Button>().interactable = true;
            nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    void CheckBackButton()
    {

        if (storyManager.GetCurrentIndex() == 0)
        {
            backButton.GetComponent<Button>().interactable = false;
            backButton.GetComponent<Image>().color = new Color(255, 255, 255, 125);
        }
        else
        {
            backButton.GetComponent<Button>().interactable = true;
            backButton.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    public void ToggleAutoNextPart()
    {
        isAutoNextPage = !isAutoNextPage;
    }

    public bool GetIsAutoNext()
    {
        return isAutoNextPage;
    }

    public void SetIsAutoNextPage(bool nextPageValue)
    {
        isAutoNextPage = nextPageValue;
    }

    
}
