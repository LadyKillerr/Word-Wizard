using DG.Tweening;
using UnityEngine;

public class ScaleTweenUI : TweenUI
{
    public bool scaleOnStart;
    [SerializeField] float showTime = 0.3f, hideTime = 0.2f;
    [SerializeField] Ease showEase = Ease.OutBack, hideEase = Ease.InBack;
    [SerializeField] Transform tweenGo;

    void Start()
    {
          
        
    }

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
