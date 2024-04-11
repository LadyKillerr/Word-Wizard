﻿using System.Collections;
using UnityEngine;

public class QuizOnlyManager : MonoBehaviour
{

    // hidden components
    GameObject spawnedObject;
    RectTransform rectTransform;
    AudioManager audioManager;

    [Header("Open Components")]
    [SerializeField] GameObject transitionsAnim;
    public Canvas quizCanvas;
    [SerializeField] GameObject quizList;
    [SerializeField] GameObject quizSpawnTarget;

    [Header("Quiz only Prefabs")]
    [SerializeField] GameObject catAndTheBatPrefab;
    [SerializeField] GameObject bennyTheBunnyPrefab;
    [SerializeField] GameObject caseyTheCatPrefab;
    [SerializeField] GameObject dannyTheDogPrefab;
    [SerializeField] GameObject ellieTheElephantPrefab;
    [SerializeField] GameObject freddyTheFishPrefab;
    [SerializeField] GameObject ginaTheGoosePrefab;
    [SerializeField] GameObject henryTheHedgehogPrefab;
    [SerializeField] GameObject ivyTheIguanaPrefab;

    private void Awake()
    {
        transitionsAnim.GetComponent<Animator>().SetTrigger("start");
        audioManager = FindAnyObjectByType<AudioManager>();

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void StartToggleQuizSection(int quizValue)
    {
        // bắt đầu đợi 2s để anim chạy
        StartCoroutine(ToggleQuizSection(quizValue));

        // anim chạy trong khoảng 1.5s 
        transitionsAnim.GetComponent<Animator>().SetTrigger("end");

        StartCoroutine(ResetTransitionGameObject());
    }

    IEnumerator ToggleQuizSection(int quizValue)
    {
        // ngưng load tầm 1.5s để anim chạy, xong thì sẽ bdau hiện ra quiz 
        yield return new WaitForSeconds(1.5f);
        
        // sau khi đợi 1.5s để start anim chạy xong -> màn đen xì sẽ bdau load ra question
        quizList.SetActive(false);

        if (audioManager != null)
        {
            audioManager.PlayStartAudio();

        }

        switch (quizValue)
        {
            case 0:
                // instantiate ra cái quiz section tương ứng ( CatAndTheBat section sẽ là 0 giống trong StoryID.txt)

                // Instantiate GameObject
                spawnedObject = Instantiate(catAndTheBatPrefab, quizSpawnTarget.transform);
                break;

            case 1:
                // Instantiate GameObject
                spawnedObject = Instantiate(bennyTheBunnyPrefab, quizSpawnTarget.transform);
                break;

            case 2:
                // Instantiate GameObject
                spawnedObject = Instantiate(caseyTheCatPrefab, quizSpawnTarget.transform);
                break;

            case 3:
                // Instantiate GameObject
                spawnedObject = Instantiate(dannyTheDogPrefab, quizSpawnTarget.transform);
                break;

            case 4:
                // Instantiate GameObject
                spawnedObject = Instantiate(ellieTheElephantPrefab, quizSpawnTarget.transform);
                break;

            case 5:
                // Instantiate GameObject
                spawnedObject = Instantiate(freddyTheFishPrefab, quizSpawnTarget.transform);
                break;

            case 6:
                // Instantiate GameObject
                spawnedObject = Instantiate(ginaTheGoosePrefab, quizSpawnTarget.transform);
                break;

            case 7:
                // Instantiate GameObject
                spawnedObject = Instantiate(henryTheHedgehogPrefab, quizSpawnTarget.transform);
                break;

            case 8:
                // Instantiate GameObject
                spawnedObject = Instantiate(ivyTheIguanaPrefab, quizSpawnTarget.transform);
                break;
        }

        // Thiết lập RectTransform của GameObject
        rectTransform = spawnedObject.GetComponent<RectTransform>();

        // Set Anchor để gameObject neo full màn hình
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = Vector2.zero;
    }

    // sau khi chạy lần đầu vào thì phải tắt anim đi không thì các câu hỏi sau cũng phải chờ
    IEnumerator ResetTransitionGameObject()
    {
        yield return new WaitForSeconds(2.5f);

        
        transitionsAnim.SetActive(false);
        transitionsAnim.GetComponent<Animator>().enabled = false;

        Debug.Log("Killed The ANIM thing");
        
    }

    public void ActivateQuizAnim()
    {
        transitionsAnim.SetActive(true);
        transitionsAnim.GetComponent<Animator>().enabled = true;
    }
}
