﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter your question text here";

    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswersIndex;

    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswersIndex;
    }

    // get ra câu hỏi được chỉ định dựa trên index 
    public string GetAnswer(int index)
    {
        return answers[index];
    }

}
