using DG.Tweening;
using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour
{
    [Header("DotTween")]
    [SerializeField] float showTime = 0.3f, hideTime = 0.2f;
    [SerializeField] Vector3 startTweenScale;
    [SerializeField] Vector3 endTweenScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] Ease showEase = Ease.OutBack, hideEase = Ease.InBack;
    [SerializeField] Transform tweenGo;

    [Header("Drag and drop")]
    [SerializeField] bool isDragging;
    [SerializeField] bool isInSlots;
    [SerializeField] AudioClip wordAudioClip;
    [SerializeField] AudioClip wordDropSound;
    [SerializeField] float delayTime = .2f;


    // biến lưu giá trị string của Piece
    public string wordPiece;

    // bool báo đã ghép đúng 1 từ
    public bool isAnswerCorrect;

    // bool báo đã ghép đúng toàn bộ


    // ref tới phần tử cha chứa toàn bộ các puzzlePiece
    public GameObject puzzlePieceGameObject;

    [Header("Puzzle Audio")]
    [SerializeField] AudioClip[] puzzleAudio;



    // hidden components 
    //AudioManager audioManager;
    AudioSource puzzlePieceAudio;
    AudioManager audioManager;
    PuzzleManager puzzleManager;


    RectTransform puzzlePieceTransform;
    Vector3 originalPosition;
    Vector3 isInSlotsPosition;

    // khoảng cách từ chuột tới vật thể, khoá offset này lại thì vật sẽ đi theo chuột 
    Vector2 offset;

    // biến để lưu giá trị text của puSzzleSlot Piece này chạm vào 
    string puzzleSlotText;

    bool solvedPuzzle;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        puzzlePieceAudio = GetComponent<AudioSource>();

        puzzlePieceTransform = GetComponent<RectTransform>();

        puzzleManager = FindAnyObjectByType<PuzzleManager>();

        startTweenScale = puzzlePieceTransform.localScale;


    }

    private void Start()
    {
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

    void OnTriggerStay2D(Collider2D other)
    {
        // nếu đang kéo và đang chạm vào puzzle Slots
        if (other.CompareTag("PuzzleSlot"))
        {


            isInSlots = true;

            isInSlotsPosition = other.GetComponent<RectTransform>().position;

            puzzleSlotText = other.gameObject.GetComponent<PuzzleSlots>().GetPuzzleSlotText();

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PuzzleSlot"))
        {
            isInSlots = false;

        }
    }

    private void CheckAllAnswer()
    {
        solvedPuzzle = true;

        for (int i = 0; i < puzzlePieceGameObject.transform.childCount; i++)
        {
            
            // lặp qua từng phần tử trong GameObject PuzzlePiece kiểm tra, chỉ cần có 1 câu sai là biến thành false luôn
            if (puzzlePieceGameObject.transform.GetChild(i).GetComponent<PuzzlePiece>().isAnswerCorrect == false )
            {
                Debug.Log(puzzlePieceGameObject.transform.GetChild(i).GetComponent<PuzzlePiece>().isAnswerCorrect);
                Debug.Log("The Answer is INCORRECTmessage: ");

                solvedPuzzle = false;
            }

        }

        // nếu không có câu sai nào thì đã trả lời đúng
        if (solvedPuzzle == true)
        {


            Debug.Log("Đã trả lời đúng hết các ô chữ.");

            audioManager.PlayCongratsClip();


            StartCoroutine(PlayCongratsEffects());
        }

    }

    IEnumerator PlayCongratsEffects()
    {
        yield return new WaitForSeconds(delayTime);

        puzzleManager.PlayTurtleAudio();


        Debug.Log("The Next Puzzle Appears");
    }

    

    private void OnMouseDown()
    {
        if (!puzzlePieceAudio.isPlaying)
        {
            puzzlePieceAudio.PlayOneShot(wordAudioClip);

        }

        tweenGo.localScale = startTweenScale;
        tweenGo.DOScale(endTweenScale, showTime).SetEase(showEase);

        isDragging = true;

        if (isDragging)
        {
            offset = GetMousePos() - (Vector2)transform.position;

        }

    }

    private void OnMouseUp()
    {
        // so sánh đáp án đúng với đáp án ghép vào của piece hiện tại
        if (wordPiece == puzzleSlotText)
        {
            Debug.Log("Bạn đã xếp chữ ĐÚNG rùi");

            isAnswerCorrect = true;

            CheckAllAnswer();
            
        }
        else if (wordPiece != puzzleSlotText)
        {

            Debug.Log("Bạn đã xếp chữ SAIII rùi");
            isAnswerCorrect = false;

        }

        isDragging = false;

        //nếu đang chạm vào hộp
        if (isInSlots)
        {
            puzzlePieceTransform.position = isInSlotsPosition;

        }
        else if (!isInSlots)
        {
            // nếu không thì trả về chỗ cũ 
            puzzlePieceTransform.position = originalPosition;

        }


        puzzlePieceAudio.PlayOneShot(wordDropSound);




        StartCoroutine(ResetLocalScale());

    }


    IEnumerator ResetLocalScale()
    {
        yield return new WaitForSeconds(.2f);

        tweenGo.localScale = puzzlePieceTransform.localScale;
        tweenGo.DOScale(startTweenScale, hideTime).SetEase(hideEase);
    }

    Vector2 GetMousePos()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
