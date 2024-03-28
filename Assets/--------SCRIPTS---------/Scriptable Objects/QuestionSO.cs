using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter your question text here";

    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswersIndex;




    ///* All the existing code is here */

    //public static QuestionSO CreateQuestion(QuestionSet question)
    //{
    //    QuestionSO result = CreateInstance<QuestionSO>();
    //    result.question = question.question;

    //    // pick a random index for the correct answer
    //    result.correctAnswerIndex = Random.Range(0, 4);
    //    int currentIncorrectIndex = 0;
    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (i == result.correctAnswerIndex)
    //        {
    //            result.answersButton[i] = question.correct_answer;
    //        }
    //        else
    //        {
    //            result.answersButton[i] = question.incorrect_answers[currentIncorrectIndex++];
    //        }
    //    }

    //    return result;
    //}


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
