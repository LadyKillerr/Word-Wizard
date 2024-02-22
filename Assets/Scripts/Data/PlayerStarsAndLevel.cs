using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarsAndLevel : MonoBehaviour
{
    public int level = 0;
    public int stars = 0;

    public void SavePlayer()
    {
        //SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        stars = data.stars;
    }
}
