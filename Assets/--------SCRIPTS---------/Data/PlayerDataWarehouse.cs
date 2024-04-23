using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using JetBrains.Annotations;
using Unity.VisualScripting;


public class PlayerDataWarehouse : MonoBehaviour
{
    public List<GameObject> storyBooks;
    [SerializeField] int totalBooks;

    private void Awake()
    {
        totalBooks = storyBooks.Count;

#pragma warning disable CS0618 // Type or member is obsolete
        int instanceCount = FindObjectsOfType(GetType()).Length;
#pragma warning restore CS0618 // Type or member is obsolete

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


    }

    private void Start()
    {
        StartCoroutine(LoadPlayerProgress());
    }

    IEnumerator LoadPlayerProgress()
    {

        yield return new WaitForSeconds(.1f);

        SavePlayerData("abc", 1);

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

    public PlayerProgressData[] LoadPlayerProgressData(string dataScript)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, dataScript);

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);



            PlayerProgressData[] starsData = JsonConvert.DeserializeObject<PlayerProgressData[]>(jsonContent);


            return starsData;




        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return null;
        }
    }

    public void SavePlayerData(
        string key, 
        int value)
    {
        string filePath = Application.persistentDataPath + "/interactiveStoriesData.json";
        string jsonData = File.Exists(filePath) ? File.ReadAllText(filePath) : "";

        if (System.IO.File.Exists(filePath))
        {
            PlayerProgressData[] dataList = JsonConvert.DeserializeObject<PlayerProgressData[]>(jsonData);

            for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].numberPlayed == key)
                {
                    // tăng số sao lên dựa theo số sao truyền vào
                    dataList[i].stars += value;
                }
            }

            string dataSave = "";
            for (int i = 0; i < dataList.Length; i++)
            {
                if (i == (dataList.Length - 1))
                {
                    string settingJSON = JsonUtility.ToJson(dataList[i]);
                    dataSave += settingJSON;
                }
                else
                {
                    string settingJSON = JsonUtility.ToJson(dataList[i]);
                    dataSave += settingJSON + ",";

                }
            }
            dataSave = ("[" + dataSave + "]");
            File.WriteAllText(filePath, dataSave);
        }
        // nếu file ko tồn tại thì phải tạo file mới và ghi đè
        else
        {
            // biến để lưu lại hết tất cả dữ liệu về người chơi
            List<PlayerProgressData> playerProgresses = new List<PlayerProgressData>();

            PlayerProgressData timesPlayed = new PlayerProgressData();
            timesPlayed.numberPlayed = "playerStars";
            timesPlayed.stars = 0;

            playerProgresses.Add(timesPlayed);

            for (int i = 0; i < totalBooks; i++)
            {
                PlayerProgressData saveStoryProgress = new PlayerProgressData();

                saveStoryProgress.numberPlayed = "StoryProgress" + i;

                saveStoryProgress.stars = 0;

                playerProgresses.Add(saveStoryProgress);
            }

            string dataSave = "";
            for (int i = 0; i < playerProgresses.Count; i++)
            {
                if ( i == (playerProgresses.Count - 1 ))
                {
                    string settingJSON = JsonUtility.ToJson(playerProgresses[i]);
                    dataSave += settingJSON;
                }
                else
                {
                    string settingJSON = JsonUtility.ToJson(playerProgresses[i]);
                    dataSave += settingJSON + ",";

                }
            }
            dataSave = ("[" + dataSave + "]");
            File.WriteAllText(filePath, dataSave);
        }



    }
}

[System.Serializable]
public class StoryData
{
    public string id;
    public string story;
    public List<string> sentences;
    public List<string> noun;
}

[System.Serializable]
public class PlayerProgressData
{
    public string numberPlayed;
    public int stars;

}






