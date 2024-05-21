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


    bool isRewardCollected = true;
    [SerializeField] bool atHome = false;

    PlayerProgressData[] dataList;

    [SerializeField] int increasedStarsNumber = 1;

    int currentStars;
    int targetStars;

    //PlayerDataWarehouse gameData;
    // Start is called before the first frame update
    [System.Obsolete]
    void Awake()
    {
        filePath = Application.persistentDataPath + "/interactiveStoriesData.json";
        jsonData = File.Exists(filePath) ? File.ReadAllText(filePath) : "";


        dataList = JsonConvert.DeserializeObject<PlayerProgressData[]>(jsonData);


        LoadStarsData();

        int.TryParse(starsNumber.text, out currentStars);


        currentStars = int.Parse(starsNumber.text);

        Debug.Log("Player Stars" + dataList[0].stars);

    }

    // Update is called once per frame
    void Update()
    {
        CheckStarsNumber();


        // chỉ khi ở màn Home mới bật biến bool atHome để update số sao liên tục
        if (atHome)
        {
            CheckHomeStars();
        }

    }

    void CheckHomeStars()
    {
        starsNumber.text = dataList[0].stars.ToString();
    }

    void CheckStarsNumber()
    {
        int.TryParse(starsNumber.text, out currentStars);


        // set số sao sau khi reward để tăng số sao hiên tai lên bằng số đó
        targetStars = dataList[0].stars;


        filePath = Application.persistentDataPath + "/interactiveStoriesData.json";
        jsonData = File.Exists(filePath) ? File.ReadAllText(filePath) : "";


        dataList = JsonConvert.DeserializeObject<PlayerProgressData[]>(jsonData);


        if (dataList != null)
        {

            Debug.Log("Player Stars right now is: " + dataList[0].stars);


            while (currentStars < targetStars && isRewardCollected)
            {
                StartCoroutine(IncreasingStars(0.2f));



                isRewardCollected = false;


            }


            // duyet qua các prefab nút trong list nút ẩn để set text của chúng thành chữ trong json file
            //hiddenButtonsText[i].GetComponent<TextMeshProUGUI>().text = gameStory[storyId].noun[i];


        }
    }

    IEnumerator IncreasingStars(float delay)
    {
        yield return new WaitForSeconds(delay);

        currentStars += increasedStarsNumber;

        starsNumber.text = currentStars.ToString();


        Debug.Log("Stars is increasing hehe " + currentStars);

        isRewardCollected = true;
    }



    public void LoadStarsData()
    {

        filePath = Application.persistentDataPath + "/interactiveStoriesData.json";
        jsonData = File.Exists(filePath) ? File.ReadAllText(filePath) : "";


        dataList = JsonConvert.DeserializeObject<PlayerProgressData[]>(jsonData);


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




    public void SetTargetStars(int value)
    {
        targetStars = value;
    }

    public int GetStarsNumber()
    {
        return dataList[0].stars;
    }
}
