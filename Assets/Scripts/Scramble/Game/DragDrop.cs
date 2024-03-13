using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] float showTime = 0.3f, hideTime = 0.2f;
    [SerializeField] Vector3 startTweenScale = new Vector3(1, 1, 1);
    [SerializeField] Vector3 endTweenScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] Ease showEase = Ease.OutBack, hideEase = Ease.InBack;
    [SerializeField] Transform tweenGo;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

        // nút sẽ bắt đầu animate ra 1 tý
        tweenGo.localScale = startTweenScale;

        // nút sẽ to ra và dừng lại khi chạm tới endTweenScale
        tweenGo.DOScale(endTweenScale, showTime).SetEase(showEase);

        if(tweenGo.localScale == endTweenScale)
        {
            tweenGo.DOScale(startTweenScale, hideTime).SetEase(hideEase);
             
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

        // nút sẽ bắt đầu animate trở về như cũ
        tweenGo.DOScale(startTweenScale, hideTime).SetEase(hideEase);
    }
    
}
