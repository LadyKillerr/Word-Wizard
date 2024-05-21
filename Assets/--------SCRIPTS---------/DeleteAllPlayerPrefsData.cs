using UnityEngine;

public class DeleteAllPlayerPrefsData : MonoBehaviour
{
    PlayerDataWarehouse playerDataWarehouse;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerDataWarehouse = FindAnyObjectByType<PlayerDataWarehouse>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();

        playerDataWarehouse.ResetPlayerStars("playerStars", 0);
    }
}
