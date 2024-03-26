using TMPro;
using UnityEngine;

public class DynamicTextSize : MonoBehaviour
{
     TextMeshProUGUI textMeshPro;

    public float scaleFactor = 0.02f;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Tính toán chiều cao mới dựa trên chiều cao của màn hình
        float newHeight = Screen.height * scaleFactor;

        // Đặt chiều cao mới cho TextMeshPro
        textMeshPro.rectTransform.sizeDelta = new Vector2(textMeshPro.rectTransform.sizeDelta.x, newHeight);
    }
}
