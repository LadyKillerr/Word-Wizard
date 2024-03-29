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
    public string levelPrefName;

    // question Text
    [SerializeField] TextMeshProUGUI questionText;

    // questionsSO arrays
    [SerializeField] QuestionSO[] questionsSO;

    [Header("Answers Section")]
    [SerializeField] GameObject[] answersButton;

    [Header("Answers Audio")]
    // số câu hỏi hiện tại sẽ là key để answer1Audio shift theo
    [SerializeField] AudioClip[] answer1Audio;
    [SerializeField] AudioClip[] answer2Audio;
    [SerializeField] AudioClip[] answer3Audio;
    [SerializeField] AudioClip[] answer4Audio;


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
    [SerializeField] GameObject screenDarkenEffects;
    [SerializeField] ParticleSystem finishLevelPE;

    // Components that are hidden
    AudioSource quizSectionAudio;
    LoadScene gameSceneLoader;
    AudioManager audioManager;

    [SerializeField] GameObject congratsWindow;
    [SerializeField] GameObject rewardWindow;

    [SerializeField] int gameHomeIndex = 1;
    [SerializeField] bool isRewarded;


    [SerializeField] GameObject quizSection;

    [SerializeField] QuestionManager questionManager;
    [SerializeField] StoryManager storyManager;

    public void ActivatePendingStatus()
    {
        PlayerPrefs.SetInt(levelPrefName, 2);
    }

    void Awake()
    {
        playerProgress = FindAnyObjectByType<PlayerDataWarehouse>();
        audioManager = FindAnyObjectByType<AudioManager>();
        quizSectionAudio = GetComponent<AudioSource>();

        isRewarded = false;

        congratsWindow.SetActive(false);
        rewardWindow.SetActive(false);

        // k can thiet
        //for ( int i = 0; i < gameQuestion.Length; i++)
        //{
        //    // in ra tiêu đề câu hỏi trong phần question
        //    questionsSO[i].GetComponent<TextMeshProUGUI>().text = gameQuestion[i].q;
        //}

        gameSceneLoader = FindAnyObjectByType<LoadScene>();
    }

    private void Start()
    {
        LoadQuestion();
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
        questionText.text = questionsSO[currentIndex].GetQuestion();

        if (quizSection.activeSelf)
        {
            LoadQuestionAudio();

        }



        for (int i = 0; i < answersButton.Length; i++)
        {
            // loop qua các đáp án và set answer cho chúng
            answersButton[i].GetComponent<Image>().sprite = defaultAnswerSprite;

            // Get ra text của các buttons và set lại text của chúng 
            answersText = answersButton[i].GetComponentInChildren<TextMeshProUGUI>();

            // set text theo answersButton
            answersText.text = questionsSO[currentIndex].GetAnswer(i);
        }



    }

    public void OnAnswerSelected(int userAnswerIndex)
    {
        // nếu trả lời đúng
        if (userAnswerIndex == questionsSO[currentIndex].GetCorrectAnswerIndex() && isAnswered == false)
        {
            // dừng audio câu hỏi cho đỡ rối âm thanh
            quizSectionAudio.Stop();

            // làm hiệu ứng tung hoa bằng particles
            rightAnswerPE.Play();

            // chạy âm thanh câu trả lời đúng 
            quizSectionAudio.PlayOneShot(rightAnswerClip, rightAudio);


            // chuyển ảnh của nút bấm sang ảnh mới
            answersButton[userAnswerIndex].GetComponent<Image>().sprite = rightAnswerSprite;



            isAnswered = true;
            isAnswerCorrect = true;
            Invoke("LoadNextQuestion", delayTime);
        }
        // nếu trả lời sai 
        else if (userAnswerIndex != questionsSO[currentIndex].GetCorrectAnswerIndex() && isAnswered == false)
        {
            // làm đth rung 1 tý
            Handheld.Vibrate();

            Debug.Log("Phone vibrate performed");


            // dừng audio câu hỏi cho đỡ rối âm thanh
            quizSectionAudio.Stop();

            // tạm thời khoá nút lại khoảng chừng 2s
            isAnswered = true;
            isAnswerCorrect = false;
            StartCoroutine(ResetIsAnswered());

            // chạy hiệu ứng âm thanh trả lời sai
            quizSectionAudio.PlayOneShot(wrongAnswerClip, wrongAudio);


            // chuyển ảnh của nút bấm sang ảnh mới
            answersButton[userAnswerIndex].GetComponent<Image>().sprite = wrongAnswerSprite;

        }
    }

    public void LoadQuestionAudio()
    {
        if (!quizSectionAudio.isPlaying && quizSection.activeSelf)
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
            //case 4:
            //    if (!quizSectionAudio.isPlaying && answer5Audio[currentIndex] != null)
            //    {
            //        // chạy âm thanh đáp án của câu hỏi 4
            //        quizSectionAudio.PlayOneShot(answer5Audio[index], answersAudioVolume);

            //    }
            //    else { return; }

            //    break;
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

    // Xử lý điều sẽ xảy ra khi đã hết câu hỏi 
    public void LoadNextQuestion()
    {
        // questionsSO.Length - 1 vì mảng bắt đầu từ 0, nếu để tới độ dài của mảng thì sẽ thừa 1
        // nếu đã trả lời đúng thì mới cho next
        if (currentIndex >= 0 && currentIndex < questionsSO.Length - 1 && isAnswerCorrect)
        {
            currentIndex++;

            MuteAudio();

            LoadQuestion();

            // dừng Particle Effects tung hoa 
            rightAnswerPE.Stop();

            isAnswered = false;
            isAnswerCorrect = false;
        }
        else if (currentIndex >= 0 && currentIndex == questionsSO.Length - 1 && isAnswerCorrect)
        {
            // khi trả lời đúng câu hỏi cuối cùng
            nextButton.GetComponent<Image>().color = new(255, 255, 255, buttonOpacity);


            if (PlayerPrefs.GetInt(levelPrefName) == 0)
            {
                StartCoroutine(LoadRewardPopup());

                congratsWindow.SetActive(false);
            }
            else if (PlayerPrefs.GetInt(levelPrefName) != 0)
            {
                rewardWindow.SetActive(false);
                StartCoroutine(LoadCongratsPopup());
            }




        }

    }

    IEnumerator LoadCongratsPopup()
    {
        yield return new WaitForSeconds(delayTimeSmall);

        congratsWindow.SetActive(true);
        finishLevelPE.Play();

        screenDarkenEffects.SetActive(true);
        audioManager.PlayCongratsClip();
    }

    IEnumerator LoadRewardPopup()
    {
        yield return new WaitForSeconds(delayTimeSmall);

        if (!isRewarded)
        {
            rewardWindow.SetActive(true);
            finishLevelPE.Play();

            screenDarkenEffects.SetActive(true);
            audioManager.PlayCongratsClip();

            // Set int thành 1 ý là đã hoàn thành
            PlayerPrefs.SetInt(levelPrefName, 1);

            Debug.Log("Level Saved");

            isRewarded = true;
        }
        else if (isRewarded)
        {
            rewardWindow.SetActive(false);
            finishLevelPE.Stop();
            isRewarded = false;
        }



    }

    public void HideRewardPopup()
    {
        if (isRewarded)
        {
            rewardWindow.SetActive(false);
            isRewarded = false;
            screenDarkenEffects.SetActive(false);
        }
        // LOAD RA MÀN HOME khi đã end game
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
        if (currentIndex > 0 && currentIndex <= questionsSO.Length)
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
        return questionsSO.Length;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    IEnumerator ResetIsAnswered()
    {
        yield return new WaitForSeconds(1);

        isAnswered = false;
    }
}
