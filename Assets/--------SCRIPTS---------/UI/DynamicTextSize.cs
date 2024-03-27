using TMPro;
using UnityEngine;

public class DynamicTextSize : MonoBehaviour
{
     TextMeshProUGUI textMeshPro;

    public float heightScaleFactor = 0.3f;
    public float widthScaleFactor = 0.75f;


    public float padding = 200f;

    Rect safeArea;

    private void Awake()
    {
        safeArea = Screen.safeArea;

        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Tính toán chiều cao mới dựa trên chiều cao của màn hình
        float newHeight = Screen.height * heightScaleFactor;

        // Tính chiều rộng mới của màn hình sau khi đã trừ đi Safe Area và padding ( Tính khoảng cách mỗi bên)
        float newWidth = (Screen.width - 2 * padding) * widthScaleFactor;

        // Đặt chiều cao mới cho TextMeshPro
        textMeshPro.rectTransform.sizeDelta = new Vector2(newWidth, newHeight);


        // Đặt chiều rộng mới cho TMP 

    }
}
