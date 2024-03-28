using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizQuestionsUI : MonoBehaviour
{
    QuestionManager questionManager;

    TextMeshProUGUI questionNumberText;

    int totalQuestions;
    int currentQuestion;

    void Awake()
    {
        questionManager = FindAnyObjectByType<QuestionManager>();

        // Get ra UI questionNumber hiện tại
        questionNumberText = GetComponent<TextMeshProUGUI>();

        // Get ra tổng số câu hỏi trong mảng
        totalQuestions = questionManager.GetTotalQuestions();
    }

    void Update()
    {
        ShowQuizProgress();
    }

    void ShowQuizProgress()
    {
        currentQuestion = questionManager.GetCurrentIndex() + 1;


        questionNumberText.text = currentQuestion.ToString("00") + "/" + totalQuestions.ToString("00");
    }
}
