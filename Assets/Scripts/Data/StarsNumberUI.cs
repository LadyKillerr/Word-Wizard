using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class StarsNumberUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsNumber;

    PlayerDataWarehouse gameData;

    // Start is called before the first frame update
    [System.Obsolete]
    void Awake()
    {
        gameData = FindObjectOfType<PlayerDataWarehouse>();
        LoadStarsData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStarsData()
    {
        string filePath = Application.persistentDataPath + "/interactiveStoriesData.json";
        string jsonData = File.Exists(filePath) ? File.ReadAllText(filePath) : "";


        PlayerProgressData[] dataList = JsonConvert.DeserializeObject<PlayerProgressData[]>(jsonData);
        for (int i = 0; i < dataList.Length; i++)
        {
            if(dataList[i].numberPlayed == "playerStars")
            {
                starsNumber.text = dataList[i].stars.ToString();
            }
            // duyẹt qua các story trong storyPart và set text của chúng dựa trên file json


            // duyet qua các prefab nút trong list nút ẩn để set text của chúng thành chữ trong json file
            //hiddenButtonsText[i].GetComponent<TextMeshProUGUI>().text = gameStory[storyId].noun[i];
        }
    }
}
