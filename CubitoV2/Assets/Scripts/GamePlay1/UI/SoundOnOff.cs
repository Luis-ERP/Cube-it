using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    public AudioSource Audio;
    public Button btn;
    public Sprite soundOnImg;
    public Sprite soundOffImg;
    bool isSoundOn = true;

    private void Start()
    {
        if (Audio.isPlaying)
        {
            btn.image.sprite = soundOnImg;
            isSoundOn = true;
        }
        else
        {
            btn.image.sprite = soundOffImg;
            isSoundOn = false;
        }
    }

    public void Sound()
    {
        if (isSoundOn)
        {
            Audio.Pause();
            btn.image.sprite = soundOffImg;
            isSoundOn = false;
        }
        else
        {
            Audio.UnPause();
            btn.image.sprite = soundOnImg;
            isSoundOn = true;
        }
    }
}
