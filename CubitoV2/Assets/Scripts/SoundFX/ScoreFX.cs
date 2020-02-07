using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFX : MonoBehaviour
{
    public AudioSource sound;

    public void ScoreSoundFX()
    {
        sound.Play();
    }
}
