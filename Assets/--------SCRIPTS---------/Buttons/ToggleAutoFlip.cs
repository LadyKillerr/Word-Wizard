using UnityEngine;
using UnityEngine.UI;

public class ToggleAutoFlip : MonoBehaviour
{
    SwipeHandler swipeHandler;
    Image autoButtonImage;

    [SerializeField] Sprite pauseAutoSprite;
    [SerializeField] Sprite continueAutoSprite;

    private void Awake()
    {

        autoButtonImage = GetComponent<Image>();

        swipeHandler = FindAnyObjectByType<SwipeHandler>();
    }

    private void Update()
    {
        if (swipeHandler.GetIsAutoNext())
        {
            autoButtonImage.sprite = continueAutoSprite;

        }
        else if (!swipeHandler.GetIsAutoNext())
        {
            autoButtonImage.sprite = pauseAutoSprite;


        }
    }

    public void ToggleAutoNext()
    {

        swipeHandler.ToggleAutoNextPart();
        Debug.Log("đã chuyển đổi isAutoNextPart");
    }
}
