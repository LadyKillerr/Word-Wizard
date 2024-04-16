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
    [SerializeField] AudioClip[] answer5Audio;
    [SerializeField] AudioClip[] answer6Audio;


    [SerializeField] float timeBeforeAudioPlay = 1f;

    [SerializeField][Range(0, 1)] float answersAudioVolume;
    [SerializeField] Sprite wrongAnswerSprite;
    [SerializeField] Sprite rightAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;
    TextMeshProUGUI answersText;

    [SerializeField] AudioClip wrongAnswerClip;
    [SerializeField][Range(0, 1)] float wrongAudio;
    [SerializeField] AudioClip rightAnswerClip;
    [SerializeField][Range(0, 1)] float rightAudio;

    [Header("Question Section")]
    [SerializeField] AudioClip[] questionsAudio;
    [SerializeField][Range(0, 1)] float quizQuestionsAudioVolume;



    [Header("Quiz Settings")]

    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayTimeSmall = 1f;

    [SerializeField] Button nextButton;
    [SerializeField] Button backButton;
    [SerializeField] float fadedButtonOpacity = .5f;
    [SerializeField] bool isAnswered;
    [SerializeField] bool isAnswerCorrect;




    [Header("Quiz Effects")]
    [SerializeField] ParticleSystem rightAnswerPE;
    [SerializeField] GameObject screenDarkenEffects;
    [SerializeField] ParticleSystem finishLevelPE;

    // Components that are hidden
    AudioSource quizSectionAudio;

    AudioManager audioManager;

    [SerializeField] GameObject congratsWindow;
    [SerializeField] GameObject rewardWindow;

    [SerializeField] bool isRewarded;


    [SerializeField] GameObject quizSection;

    [SerializeField] QuestionManager questionManager;
    [SerializeField] StoryManager storyManager;

    LoadScene levelLoader;

    Animator transitionsAnim;

    public void ActivatePendingStatus()
    {
        if (PlayerPrefs.GetInt(levelPrefName) == 1)
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt(levelPrefName, 2);

        }
    }

    void Awake()
    {
        levelLoader = FindAnyObjectByType<LoadScene>();
        playerProgress = FindAnyObjectByType<PlayerDataWarehouse>();
        audioManager = FindAnyObjectByType<AudioManager>();
        quizSectionAudio = GetComponent<AudioSource>();

        isRewarded = false;

        transitionsAnim = FindAnyObjectByType<Animator>();
    }

    private void Start()
    {
        LoadQuestion();
    }

    private void Update()
    {
        if (quizSection.activeSelf)
        {
            CheckIsAnswered();

        }
    }

    void CheckIsAnswered()
    {
        if (!isAnswerCorrect)
        {
            nextButton.interactable = false;
            nextButton.GetComponent<Image>().color = new(255, 255, 255, fadedButtonOpacity);
        }
        else if (isAnswerCorrect)
        {
            nextButton.interactable = true;

            nextButton.GetComponent<Image>().color = new(255, 255, 255, 1);

        }
        else if (currentIndex == questionsSO.Length)
        {
            nextButton.interactable = false;
            nextButton.GetComponent<Image>().color = new(255, 255, 255, fadedButtonOpacity);

        }

        if (currentIndex == 0)
        {
            if (storyManager != null)
            {
                backButton.interactable = true;
                backButton.GetComponent<Image>().color = new(255, 255, 255, 1);


            }
            else if (storyManager == null)
            {
                backButton.interactable = false;
                backButton.GetComponent<Image>().color = new(255, 255, 255, fadedButtonOpacity);
            }
        }
        else
        {
            backButton.interactable = true;

            backButton.GetComponent<Image>().color = new(255, 255, 255, 1);

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

            StartLoadQuestionAudio();

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
            Invoke(nameof(LoadNextQuestion), delayTime);
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

    public void StartLoadQuestionAudio()
    {
        StartCoroutine(LoadQuestionAudio());
    }

    public IEnumerator LoadQuestionAudio()
    {
        //Debug.Log("transitionsAnim status: " + transitionsAnim.isActiveAndEnabled);
        // nếu có anim transitions thì phải đợi hết anim mới load audio vào 
        if (!quizSectionAudio.isPlaying && (transitionsAnim != null && transitionsAnim.enabled))
        {
            // thời gian đợi trước khi tự động đọc audio của câu đầu tiên(đợi để anim chạy xong)
            yield return new WaitForSeconds(timeBeforeAudioPlay);

            quizSectionAudio.PlayOneShot(questionsAudio[currentIndex], quizQuestionsAudioVolume);
            
            Debug.Log("Có load anim cùng audio");

        }
        // nếu không có anim transitions thì chạy bthg 
        else if (!quizSectionAudio.isPlaying && quizSection.activeSelf && (transitionsAnim == null || !transitionsAnim.enabled))
        {
            Debug.Log("Load audio luôn mà không phải chờ đợi anim");

            quizSectionAudio.PlayOneShot(questionsAudio[currentIndex], quizQuestionsAudioVolume);

        }
        else { yield return null; }
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


                break;
            case 1:
                if (!quizSectionAudio.isPlaying && answer2Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 2
                    quizSectionAudio.PlayOneShot(answer2Audio[index], answersAudioVolume);

                }


                break;
            case 2:
                if (!quizSectionAudio.isPlaying && answer3Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 3
                    quizSectionAudio.PlayOneShot(answer3Audio[index], answersAudioVolume);

                }


                break;
            case 3:
                if (!quizSectionAudio.isPlaying && answer4Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 4
                    quizSectionAudio.PlayOneShot(answer4Audio[index], answersAudioVolume);

                }


                break;

            case 4:
                if (!quizSectionAudio.isPlaying && answer4Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 4
                    quizSectionAudio.PlayOneShot(answer5Audio[index], answersAudioVolume);

                }


                break;

            case 5:
                if (!quizSectionAudio.isPlaying && answer4Audio[currentIndex] != null)
                {
                    // chạy âm thanh đáp án của câu hỏi 4
                    quizSectionAudio.PlayOneShot(answer6Audio[index], answersAudioVolume);

                }


                break;



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
            nextButton.GetComponent<Image>().color = new(255, 255, 255, fadedButtonOpacity);


            // khi trả lời đúng câu hỏi cuối cùng
            StartCoroutine(LoadVictoryScreen());
        }

    }

    IEnumerator LoadVictoryScreen()
    {
        yield return new WaitForSeconds(delayTimeSmall);

        finishLevelPE.Play();
        screenDarkenEffects.SetActive(true);

        if (audioManager != null)
        {
            audioManager.PlayCongratsClip();

        }

        // kiểm tra trong player pref nếu level hiện tại có status là hoàn thành (== 1)
        if (!isRewarded && PlayerPrefs.GetInt(levelPrefName) == 1)
        {
            isRewarded = true;

            // chạy màn chúc mừng (không cộng điểm)
            congratsWindow.SetActive(true);

            rewardWindow.SetActive(false);
        }
        //kiểm tra trong player pref nếu level hiện tại có status là chưa hoàn thành(0 hoặc 2)
        else if (!isRewarded && PlayerPrefs.GetInt(levelPrefName) != 1)
        {
            isRewarded = true;
            rewardWindow.SetActive(true);
            congratsWindow.SetActive(false);

            // tang sao cho nguoi choi
            playerProgress.SavePlayerData("playerStars", starsReward);

            // lưu vào biến là đã hoàn thành
            PlayerPrefs.SetInt(levelPrefName, 1);
        }
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

            if (storyManager != null)
            {
                storyManager.ToggleLastStoryPart(storyManager.GetLastPartIndex());

            }

            else if (storyManager == null)
            {
                return;
            }
        }
        else { return; }
    }

    public void LoadSceneWithAnim(int sceneIndex)
    {
        finishLevelPE.Stop() ;
        finishLevelPE.Clear() ;



        // nếu có transitions anim
        if (transitionsAnim != null)
        {
            PrefabsSpawner quizOnlyManager = FindAnyObjectByType<PrefabsSpawner>();

            if (quizOnlyManager != null)
            {
                // bật lại component quiz Anim để chạy anim
                quizOnlyManager.ActivateQuizAnim();
            }

            // chạy animation end (chuyển màn)
            transitionsAnim.SetTrigger("end");

            // thì chạy coroutine đợi để anim chạy xong r mới load
            levelLoader.LoadLevelWithAnim(sceneIndex);

            Debug.Log("Run transitions anim before reload scene");
        }
        // còn nếu không phải đang ở màn có transitions anim thì load luôn(sử dụng loading screen)
        else
        {
            levelLoader.LoadLevel(sceneIndex);
            Debug.Log("Trying to load scene 13");

        }

    }
    public void LoadButtonAudio()
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonClip();

        }
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
        yield return new WaitForSeconds(delayTimeSmall);

        isAnswered = false;
    }
}
