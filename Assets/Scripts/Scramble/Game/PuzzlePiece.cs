using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour
{
    [Header("DotTween")]
    [SerializeField] float showTime = 0.3f, hideTime = 0.2f;
    [SerializeField] Vector3 startTweenScale = new Vector3(1, 1, 1);
    [SerializeField] Vector3 endTweenScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] Ease showEase = Ease.OutBack, hideEase = Ease.InBack;
    [SerializeField] Transform tweenGo;

    [Header("Drag and drop")]
    [SerializeField] bool isDragging;
    [SerializeField] AudioClip wordAudioClip;
    [SerializeField] AudioClip wordDropSound;

    // hidden components 
    //AudioManager audioManager;
    RectTransform puzzlePieceTransform;
    Vector3 originalPosition;

    // khoảng cách từ chuột tới vật thể, khoá offset này lại thì vật sẽ đi theo chuột 
    Vector2 offset;

    AudioSource puzzlePieceAudio;

    private void Awake()
    {
        puzzlePieceAudio = GetComponent<AudioSource>();

        puzzlePieceTransform = GetComponent<RectTransform>();

        // originalPosition là biến lưu vị trí gốc từ awake
        originalPosition = puzzlePieceTransform.position;
    }

    private void Update()
    {
        if (!isDragging) return;

        var mousePosition = GetMousePos();

        // khi đang isDragging thì sẽ lấy chuột trừ khoảng cách offset để vật gắn liền với object
        transform.position = mousePosition - offset;
    }

    private void OnMouseDown()
    {
        puzzlePieceAudio.PlayOneShot(wordAudioClip);


        offset = GetMousePos() - (Vector2)transform.position;

    }
     
    private void OnMouseDrag()
    {
        isDragging = true;

        tweenGo.localScale = startTweenScale;
        tweenGo.DOScale(endTweenScale, showTime).SetEase(showEase);
    }

    private void OnMouseUp()
    {
        transform.position = originalPosition;
        isDragging = false;

        puzzlePieceAudio.PlayOneShot(wordDropSound);

        StartCoroutine(ResetLocalScale());

    }

    IEnumerator ResetLocalScale()
    {
        yield return new WaitForSeconds(hideTime);

        tweenGo.localScale = puzzlePieceTransform.localScale;
        tweenGo.DOScale(startTweenScale, hideTime).SetEase(hideEase);
    }

    Vector2 GetMousePos()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
