using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStatus : MonoBehaviour
{
    [SerializeField] string levelPrefName;

    void Start()
    {
        /* 
         * mỗi khi có chuyện mới sẽ phải vào Scene của truyện đó set tên sẽ đặt trong PlayerPrefs, sau đó qua phần StatusBox nhập tên trong PlayerPrefs vào trong SerializeField thì mới dc\
         * tên level trong PlayerPrefs:
         * level 1 == CatAndTheBat
         
        */


        // Kiểm tra trạng thái hoàn thành của level trong scene B
        string levelName = levelPrefName; // Tên của level
        int levelCompletion = PlayerPrefs.GetInt(levelName, 0); // Lấy giá trị trạng thái hoàn thành (0: false)
        if (levelCompletion == 1)
        {
            // Level đã hoàn thành
            Debug.Log("Level " + levelName + " đã hoàn thành!");
        }
        else
        {
            // Level chưa hoàn thành
            Debug.Log("Level " + levelName + " chưa hoàn thành.");
        }
    }


    void Update()
    {

    }
}
