using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerData : MonoBehaviour
{
    // lưu số sao vào trong player prefs -- Rất không nên - nhưng nhanh nên oke tạm đc 


    [Header("Stars Data")]
    [SerializeField] TextMeshProUGUI starsNumber;
    [SerializeField] int starsRewardPerLevel = 10;


    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        LoadStarsData();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // chuyển số sao sau mỗi màn thành string r cộng vào số sao hiện có
    public void IncreaseStars()
    {
        starsNumber.text += starsRewardPerLevel.ToString();


    }

    // lưu số sao đó vào player prefs
    public void SaveStarsData()
    {
        PlayerPrefs.SetString("StarsNumber", starsNumber.text);
    }

    // load số sao đó ra khi về menu
    public void LoadStarsData()
    {
        if (starsNumber.text != null)
        {

            starsNumber.text = PlayerPrefs.GetString("StarsNumber");
        }
        else
        {
            Debug.Log("Stars number is null");
        }
    }

    public void DecreaseStarsNumber()
    {

    }
}
