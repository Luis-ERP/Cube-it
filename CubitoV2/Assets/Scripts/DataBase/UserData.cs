using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    //general configuration
    public int highScore;

    //achievements
    public bool twoEnemies;
    public bool twoLifes;
    public bool speedX2 = false;
    public bool threeLifes = false;

    public UserData (Main player, MainAchievements achievs)
    {
        highScore = player.highScore;

        twoEnemies = achievs.twoEnemies;
        twoLifes = achievs.twoLifes;
        speedX2 = achievs.speedX2;
        threeLifes = achievs.threeLifes;
    }

}
