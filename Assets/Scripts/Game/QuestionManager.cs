using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
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

    [SerializeField] bool isReading;
    [SerializeField] bool isAnswered;
    [SerializeField] bool isAnswerCorrect;




    [Header("Quiz Effects")]
    [SerializeField] ParticleSystem rightAnswerPE;


    // Components that are hidden
    AudioSource quizSectionAudio;

    [SerializeField] QuestionManager questionManager;
    [SerializeField] StoryManager storyManager;

    PlayerData playerDataManager;

    void Awake()
    {


        quizSectionAudio = GetComponent<AudioSource>();

        LoadQuestion();


    }

    private void Update()
    {
        CheckIsReading();
    }

    private void CheckIsReading()
    {
        if (quizSectionAudio.isPlaying)
        {
            isReading = true;
        }
        else
        {
            isReading = false;
        }
    }

    void LoadQuestion()
    {
        isAnswerCorrect = false;
        isAnswered = false;

        // Get ra câu hỏi theo index
        questionText.text = questions[currentIndex].GetQuestion();

        LoadQuestionAudio();

        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].GetComponent<Image>().sprite = defaultAnswerSprite;

            answersText = answers[i].GetComponentInChildren<TextMeshProUGUI>();

            answersText.text = questions[currentIndex].GetAnswer(i);
        }

        if (currentIndex <= questions.Length - 1 && isAnswerCorrect && currentIndex >= 0)
        {
            Debug.Log("đã lưu dữ liệu vào trong PlayerPrefs");
            // Khi hoàn thành level trong scene A
            string levelName = levelPrefName; // Tên của level
            PlayerPrefs.SetInt(levelName, 1); // Ghi lại trạng thái hoàn thành (1: true)
            PlayerPrefs.Save(); // Lưu lại PlayerPrefs
        }

    }

    public void OnAnswerSelected(int userAnswerIndex)
    {
        // nếu trả lời đúng
        if (userAnswerIndex == questions[currentIndex].GetCorrectAnswerIndex() && isAnswered == false)
        {
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
            // tạm thời khoá nút lại khoảng chừng 2s
            isAnswered = true;
            isAnswerCorrect = false;

            // làm đth rung 1 tý
            Handheld.Vibrate();

            Debug.Log("Phone vibrate performed");



            Invoke("ResetIsAnswered", delayTimeSmall);



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
        if (currentIndex >= 0 && currentIndex < questions.Length - 1 && isAnswerCorrect)
        {
            currentIndex++;

            MuteAudio();

            LoadQuestion();

            isAnswered = false;
            isAnswerCorrect = false;
        }
        else
        {


            return;
        }

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

    void ResetIsAnswered()
    {
        isAnswered = false;
    }
}
