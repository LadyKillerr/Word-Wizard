
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class JSONLoader : MonoBehaviour
{
    [SerializeField] TextAsset questionsFile;

    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public string[] answer;
        public int correctAnswer;
    }

    [System.Serializable]
    public class QuestionSet
    {
        public QuestionData[] questions;
    }

    void Start()
    {
        string jsonString = questionsFile.text; // read the questions from the file

        Debug.Log(jsonString);

        QuestionSet questions = JsonUtility.FromJson<QuestionSet>(jsonString);
    }
    
    void Awake()
    {
        


    }


}
