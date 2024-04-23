using UnityEngine;

public class StoryStatus : MonoBehaviour
{
    [SerializeField] GameObject doneIcon;
    [SerializeField] GameObject pendingIcon;
    [SerializeField] string storyPrefName;
    int storyStatus;

    private void Awake()
    {
        CheckStoryStatus();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void CheckStoryStatus()
    {
        storyStatus = PlayerPrefs.GetInt(storyPrefName);

        switch (storyStatus)
        {
            case 0:
                // 0 là chưa làm j, chưa đọc chưa xem chưa chạm vào
                doneIcon.SetActive(false);
                pendingIcon.SetActive(false);
                break;
            case 1:
                // 1 là đã hoàn thành, đã đọc và nhận thưởng xong
                doneIcon.SetActive(true);
                pendingIcon.SetActive(false);
                break;
            case 2:
                // 2 là đang pending, đã đọc nhưng vẫn còn dở dang và không đọc tới cuối 
                doneIcon.SetActive(false);
                pendingIcon.SetActive(true);
                break;
        }
    }
}
