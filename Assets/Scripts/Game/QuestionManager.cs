using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    PlayerDataWarehouse playerProgress;
    [SerializeField] int starsReward;

    [Header("Questions Section")]
    [SerializeField] int currentIndex = 0;

    // Tên Level để lưu vào PlayerPrefs
    [SerializeField] string levelPrefName;

    // question Text
    [SerializeField] TextMeshProUGUI questionText;

    // questions arrays
    [SerializeField] QuestionSO[] questions;

    [Header("Answers Section")]
    [SerializeField] GameObject[] answers;

    [Header("Answers Audio")]
    // số câu hỏi hiện tại sẽ là key để answer1Audio shift theo
    [SerializeField] AudioClip[] answer1Audio;
    [SerializeField] AudioClip[] answer2Audio;
    [SerializeField] AudioClip[] answer3Audio;
    [SerializeField] AudioClip[] answer4Audio;
    [SerializeField] AudioClip[] answer5Audio;


    [SerializeField][Range(0, 1)] float answersAudioVolume;
    [SerializeField] Sprite wrongAnswerSprite;
    [SerializeField] Sprite rightAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;
    TextMeshProUGUI answersText;

    [SerializeField] AudioClip wrongAnswerClip;
    [SerializeField][Range(0, 1)] float wrongAudio;
    [SerializeField] AudioClip rightAnswerClip;
    [SerializeField][Range(0, 1)] float rightAudio;

    [Header("Quiz Section")]
    [SerializeField] AudioClip[] questionsAudio;
    [SerializeField][Range(0, 1)] float quizQuestionsAudioVolume;



    [Header("Quiz Settings")]

    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayTimeSmall = 1f;

    [SerializeField] Button nextButton;
    [SerializeField] float buttonOpacity = .5f;
    [SerializeField] bool isAnswered;
    [SerializeField] bool isAnswerCorrect;




    [Header("Quiz Effects")]
    [SerializeField] ParticleSystem rightAnswerPE;


    // Components that are hidden
    AudioSource quizSectionAudio;
    LoadScene gameSceneLoader;
    AudioManager audioManager;


    [SerializeField] GameObject rewardWindow;

    [SerializeField] int gameHomeIndex = 1;
    [SerializeField] bool isRewarded;


    [SerializeField] GameObject quizSection;

    [SerializeField] QuestionManager questionManager;
    [SerializeField] StoryManager storyManager;



    void Awake()
    {
        playerProgress = FindAnyObjectByType<PlayerDataWarehouse>();
        audioManager = FindObjectOfType<AudioManager>();
        quizSectionAudio = GetComponent<AudioSource>();

        LoadQuestion();

        // k can thiet
        //for ( int i = 0; i < gameQuestion.Length; i++)
        //{
        //    // in ra tiêu đề câu hỏi trong phần question
        //    questions[i].GetComponent<TextMeshProUGUI>().text = gameQuestion[i].q;
        //}

        gameSceneLoader = FindAnyObjectByType<LoadScene>();
    }

    private void Update()
    {
        CheckIsAnswered();
    }

    void CheckIsAnswered()
    {
        if (!isAnswerCorrect)
        {
            nextButton.GetComponent<Image>().color = new(255, 255, 255, buttonOpacity);
        }
        else if (isAnswerCorrect)
        {
            nextButton.GetComponent<Image>().color = new(255, 255, 255, 1);

        }
    }


    void LoadQuestion()
    {
        isAnswerCorrect = false;
        isAnswered = false;

        // Get ra câu hỏi theo index
        questionText.text = questions[currentIndex].GetQuestion();

        if (quizSection.activeSelf)
        {
            LoadQuestionAudio();

        }



        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].GetComponent<Image>().sprite = defaultAnswerSprite;

            answersText = answers[i].GetComponentInChildren<TextMeshProUGUI>();

            answersText.text = questions[currentIndex].GetAnswer(i);
        }

        if (currentIndex <= questions.Length - 1 && isAnswerCorrect && currentIndex >= 0)
        {
            //Debug.Log("đã lưu dữ liệu vào trong PlayerPrefs");
            //// Khi hoàn thành level trong scene A
            //string levelName = levelPrefName; // Tên của level
            //PlayerPrefs.SetInt(levelName, 1); // Ghi lại trạng thái hoàn thành (1: true)
            //PlayerPrefs.Save(); // Lưu lại PlayerPrefs


        }

    }

    public void OnAnswerSelected(int userAnswerIndex)
    {
        // nếu trả lời đúng
        if (userAnswerIndex == questions[currentIndex].GetCorrectAnswerIndex() && isAnswered == false)
        {
            // dừng audio câu hỏi cho đỡ rối âm thanh
            quizSectionAudio.Stop();

            // làm hiệu ứng tung hoa bằng particles
            rightAnswerPE.Play();

            // chạy âm thanh câu trả lời đúng 
            quizSectionAudio.PlayOneShot(rightAnswerClip, rightAudio);


            // chuyển ảnh của nút bấm sang ảnh mới
            answers[userAnswerIndex].GetComponent<Image>().sprite = rightAnswerSprite;

            Invoke("LoadNextQuestion", delayTime);


            isAnswered = true;
            isAnswerCorrect = true;
        }
        // nếu trả lời sai 
        else if (userAnswerIndex != questions[currentIndex].GetCorrectAnswerIndex() && isAnswered == false)
        {
            // dừng audio câu hỏi cho đỡ rối âm thanh
            quizSectionAudio.Stop();

            // tạm thời khoá nút lại khoảng chừng 2s
            isAnswered = true;
            isAnswerCorrect = false;
            StartCoroutine(ResetIsAnswered());

            // làm đth rung 1 tý
            Handheld.Vibrate();

            Debug.Log("Phone vibrate performed");






            // chạy hiệu ứng âm thanh trả lời sai
            quizSectionAudio.PlayOneShot(wrongAnswerClip, wrongAudio);


            // chuyển ảnh của nút bấm sang ảnh mới
            answers[userAnswerIndex].GetComponent<Image>().sprite = wrongAnswerSprite;



        }
    }

    public void LoadQuestionAudio()
    {
        if (!quizSectionAudio.isPlaying)
        {
            quizSectionAudio.PlayOneShot(questionsAudio[currentIndex], quizQuestionsAudioVolume);

        }
        else { return; }
    }

    // bật âm thanh của đáp án
    public void LoadAnswerAudio(int index)
    {
        switch (currentIndex)
        {
            // nếu đang câu hỏi 1
            case 0:
                if (!quizSectionAudio.isPlaying && answer1Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 1
                    quizSectionAudio.PlayOneShot(answer1Audio[index], answersAudioVolume);

                }
                else { return; }

                break;
            case 1:
                if (!quizSectionAudio.isPlaying && answer2Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 1
                    quizSectionAudio.PlayOneShot(answer2Audio[index], answersAudioVolume);

                }
                else { return; }

                break;
            case 2:
                if (!quizSectionAudio.isPlaying && answer3Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 2
                    quizSectionAudio.PlayOneShot(answer3Audio[index], answersAudioVolume);

                }
                else { return; }

                break;
            case 3:
                if (!quizSectionAudio.isPlaying && answer4Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 3
                    quizSectionAudio.PlayOneShot(answer4Audio[index], answersAudioVolume);

                }
                else { return; }

                break;
            case 4:
                if (!quizSectionAudio.isPlaying && answer5Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 4
                    quizSectionAudio.PlayOneShot(answer5Audio[index], answersAudioVolume);

                }
                else { return; }

                break;
                //case 5:
                //    if (!quizSectionAudio.isPlaying && answer6Audio[currentIndex] != null)
                //    {
                //        // chạy âm thanh đáp án của câu hỏi 5
                //        quizSectionAudio.PlayOneShot(answer6Audio[index], answersAudioVolume);

                //    }
                //    else { return; }

                //    break;



        }
    }

    void MuteAudio()
    {
        quizSectionAudio.Stop();
    }

    public void LoadNextQuestion()
    {
        // questions.Length - 1 vì mảng bắt đầu từ 0, nếu để tới độ dài của mảng thì sẽ thừa 1
        // nếu đã trả lời đúng thì mới cho next
        if (currentIndex >= 0 && currentIndex < questions.Length - 1 && isAnswerCorrect)
        {
            currentIndex++;

            MuteAudio();

            LoadQuestion();

            // dừng Particle Effects tung hoa 
            rightAnswerPE.Stop();

            isAnswered = false;
            isAnswerCorrect = false;
        }
        else if (currentIndex >= 0 && currentIndex == questions.Length - 1 && isAnswerCorrect)
        {
            // khi trả lời đúng câu hỏi cuối cùng
            // cho back lại story list (tạm thời là vậy, sau sẽ chạy mà báo điểm thường)
            //StartCoroutine(LoadHome());

            nextButton.GetComponent<Image>().color = new(255, 255, 255, buttonOpacity);
            StartCoroutine(LoadRewardPopup());
            audioManager.PlayCongratsClip();
        }

    }

    IEnumerator LoadRewardPopup()
    {
        yield return new WaitForSeconds(delayTimeSmall);

        if (!isRewarded)
        {
            rewardWindow.SetActive(true);
            isRewarded = true;
        }
        else if (isRewarded)
        {
            rewardWindow.SetActive(false);
            isRewarded = false;
        }



    }

    public void HideRewardPopup()
    {
        if (isRewarded)
        {
            rewardWindow.SetActive(false);
            isRewarded = false;
        }

        LoadHome();

        audioManager.PlayButtonClip();
    }

    void LoadHome()
    {


        gameSceneLoader.LoadLevel(gameHomeIndex);

        playerProgress.SavePlayerData("playerStars", starsReward);

        Debug.Log("Testing effective");


    }

    public void LoadPreviousQuestions()
    {
        if (currentIndex > 0 && currentIndex <= questions.Length)
        {
            MuteAudio();

            currentIndex--;

            LoadQuestion();

        }
        else if (currentIndex == 0)
        {
            MuteAudio();

            storyManager.ToggleLastStoryPart(storyManager.GetLastPartIndex());


        }
        else { return; }
    }

    public int GetTotalQuestions()
    {
        return questions.Length;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    IEnumerator ResetIsAnswered()
    {
        yield return new WaitForSeconds(delayTime);

        isAnswered = false;
    }
}
