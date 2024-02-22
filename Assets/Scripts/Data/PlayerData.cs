using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;


public class PlayerData
{
    public int level;
    public int stars;

    public PlayerData(PlayerData player)
    {
        level = player.level;
        stars = player.stars;

        
    }


    
}
