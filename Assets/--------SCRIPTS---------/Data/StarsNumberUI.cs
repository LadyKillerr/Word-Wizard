using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class StarsNumberUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsNumber;

    string filePath;
    string jsonData;

    PlayerProgressData[] dataList;

    [SerializeField] int increasedStarsNumber = 2;

    int currentStars;

    //PlayerDataWarehouse gameData;
    // Start is called before the first frame update
    [System.Obsolete]
    void Awake()
    {
        filePath = Application.persistentDataPath + "/interactiveStoriesData.json";
        jsonData = File.Exists(filePath) ? File.ReadAllText(filePath) : "";


        dataList = JsonConvert.DeserializeObject<PlayerProgressData[]>(jsonData);


        LoadStarsData();

        currentStars = int.Parse(starsNumber.text);

        Debug.Log("Player Stars" + dataList[0].stars);

    }

    // Update is called once per frame
    void Update()
    {
        CheckStarsNumber();
    }

    void CheckStarsNumber()
    {

        if (dataList != null)
        {
            for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].numberPlayed == "playerStars")
                {
                    //starsNumber.text = dataList[i].stars.ToString();

                    while (currentStars < dataList[i].stars)
                    {
                        currentStars += increasedStarsNumber;


                        starsNumber.text = currentStars.ToString();

                        Debug.Log("Stars is increasing hehe");
                    }
                }



                // duyet qua các prefab nút trong list nút ẩn để set text của chúng thành chữ trong json file
                //hiddenButtonsText[i].GetComponent<TextMeshProUGUI>().text = gameStory[storyId].noun[i];
            }

        }
    }


    public void LoadStarsData()
    {
        
        if (dataList != null)
        {
        for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].numberPlayed == "playerStars")
                {
                    starsNumber.text = dataList[i].stars.ToString();
                }
                


                // duyet qua các prefab nút trong list nút ẩn để set text của chúng thành chữ trong json file
                //hiddenButtonsText[i].GetComponent<TextMeshProUGUI>().text = gameStory[storyId].noun[i];
            }

        }
    }
}
