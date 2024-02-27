using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using JetBrains.Annotations;


public class PlayerDataWarehouse : MonoBehaviour
{

    private void Awake()
    {

    }

    // dùng tên tương ứng với các data trong streamingAssets

    // hàm dành cho storyData
    public StoryData[] LoadStoryData(string dataScript)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, dataScript);

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);



            StoryData[] storyList = JsonConvert.DeserializeObject<StoryData[]>(jsonContent);


            return storyList;

            


        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return null;
        }
    }

    // hàm của QuestionData
    //public QuestionData[] LoadQuestionData(string dataScript)
    //{
    //    string filePath = Path.Combine(Application.streamingAssetsPath, dataScript);

    //    if (File.Exists(filePath))
    //    {
    //        string jsonContent = File.ReadAllText(filePath);



    //        QuestionData[] dataList = JsonConvert.DeserializeObject<QuestionData[]>(jsonContent);


    //        return dataList;


    //    }
    //    else
    //    {
    //        Debug.LogError("File not found: " + filePath);
    //        return null;
    //    }
    //}


}

[System.Serializable]
public class StoryData
{
    public string id;
    public string story;
    public List<string> sentences;
    public List<string> noun;
}






