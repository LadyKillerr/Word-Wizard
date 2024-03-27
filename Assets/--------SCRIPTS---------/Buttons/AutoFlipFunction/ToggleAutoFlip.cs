using UnityEngine;
using UnityEngine.UI;

public class ToggleAutoFlip : MonoBehaviour
{
    StoryManager storyManager;
    Image autoButtonImage;


    [SerializeField] Sprite pauseAutoSprite;
    [SerializeField] Sprite continueAutoSprite;

    private void Awake()
    {
        autoButtonImage = GetComponent<Image>();

        storyManager = FindAnyObjectByType<StoryManager>();
    }

    private void Update()
    {
        if (storyManager.GetIsAutoNext())
        {
            autoButtonImage.sprite = continueAutoSprite;
            Debug.Log("Continue is good");
        }
        else if (!storyManager.GetIsAutoNext())
        {
            autoButtonImage.sprite = pauseAutoSprite;
            Debug.Log("Continue is BAD");

        }
    }

    public void ToggleAutoNext()
    {
        storyManager.ToggleAutoNextPart();
        Debug.Log("đã chuyển đổi isAutoNextPart");
    }
}
