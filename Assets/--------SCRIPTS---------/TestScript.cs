using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestScript : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Image testImage;
    public float minSwipeDistance = 0;

    Vector2 startPosition;
    Vector2 endPosition;

    public void OnDrag(PointerEventData eventData)
    {
        // Không cần thực hiện gì trong phương thức này
        testImage.color = Color.blue;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        testImage.color = Color.green;

        endPosition = eventData.position;
        float swipeDistance = (endPosition - startPosition).magnitude;

        if (swipeDistance > minSwipeDistance)
        {
            Vector2 swipeDirection = (endPosition - startPosition).normalized;

            if (swipeDirection.x > 0.5f)
            {
                Debug.Log("Swipe RIGHT");

                // Vuốt sang phải, chuyển sang màn hình kế tiếp
                // Gọi hàm để chuyển màn hình tại đây
            }
            else if (swipeDirection.x < -0.5f)
            {
                Debug.Log("Swipe Left");

                // Vuốt sang trái, chuyển sang màn hình trước đó
                // Gọi hàm để chuyển màn hình tại đây
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = eventData.position;
        testImage.color = Color.red;
        Debug.Log("Đã bắt đầu drag");
    }
}
