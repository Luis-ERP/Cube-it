using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataJson
{
    // main configurations
    public bool music = true;
    public bool soundFX = true;
    public bool lowDetailMode = false;

    // main user configs
    public int highScore = 0;

    // achievements
    public bool firstExtraHeart = false;
    public bool randomBoosts = false;
    public bool fiveSecShield = false;
    public bool tenSecShield = false;
    public bool secondExtraHeart = false;
    public bool thridExtraHeart = false;
}
