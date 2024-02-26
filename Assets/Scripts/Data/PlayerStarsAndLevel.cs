using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;


public class PlayerStarsAndLevel : MonoBehaviour
{

    private void Awake()
    {

    }

    // dùng tên tương ứng với các data trong streamingAssets
    public QuestionData[] LoadQuestionData(string dataScript)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, dataScript);

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);



            QuestionData[] dataList = JsonConvert.DeserializeObject<QuestionData[]>(jsonContent);


            return dataList;


        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return null;
        }
    }
}

[System.Serializable]
public class QuestionData
{
    public string q;
    public List<string> a;
    public string c;
}

[System.Serializable]
public class StoryData
{
    public string q;
    public List<string> a;
    public string c;
}

[System.Serializable]
public class QuestionSet
{
    public QuestionData[] questions;
}



