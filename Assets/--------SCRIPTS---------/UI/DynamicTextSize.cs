using TMPro;
using UnityEditor;
using UnityEngine;

public class DynamicTextSize : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    public float heightScaleFactor = 0.3f;
    //public float widthScaleFactor = 0.75f;
    

    public float padding = 200f;

    Rect safeArea;

    Vector2 viewportSize;

    RectTransform viewportRectTransform;
    Canvas canvas;

    float newHeight;
    float newWidth;

    private void Awake()
    {
        canvas = FindAnyObjectByType<Canvas>();

        // Lấy RectTransform của Viewport
        viewportRectTransform = canvas.GetComponent<RectTransform>();

        safeArea = Screen.safeArea;

        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Tính toán chiều cao mới dựa trên chiều cao của màn hình
    }

    void Update()
    {
        
        newHeight = Screen.height * heightScaleFactor;


        if (viewportRectTransform != null)
        {
            // Lấy kích thước của Viewport
            Vector2 viewportSize = viewportRectTransform.rect.size;

            // Tính toán chiều rộng mới của TextMeshPro
            newWidth = viewportSize.x - (2 * padding);

            // Đặt chiều rộng mới cho TextMeshPro
            textMeshPro.rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        }
    }
}
