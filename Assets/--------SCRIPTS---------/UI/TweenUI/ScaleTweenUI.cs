using DG.Tweening;
using UnityEngine;

public class ScaleTweenUI : TweenUI
{
    public bool scaleOnStart;
    [SerializeField] float showTime = 0.3f;
    [SerializeField] Ease showEase = Ease.OutBack;
    [SerializeField] Transform tweenGo;

    private void OnEnable()
    {
        if (scaleOnStart)
        {
            
            
                if (tweenGo == null)
                {
                    tweenGo = transform;
                }

            tweenGo.localScale = Vector3.zero;
            tweenGo.DOScale(1, showTime).SetEase(showEase);
            
        }
    }

}
