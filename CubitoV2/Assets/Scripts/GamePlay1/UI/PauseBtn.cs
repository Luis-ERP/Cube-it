using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    public bool paused = false;
    public GameObject cameraScript;
    
    
    public void ActivePause()
    {
        if (paused)
        {
            cameraScript.GetComponent<Main>().paused = false;
            paused = false;
        }
        else
        {
            cameraScript.GetComponent<Main>().paused = true;
            paused = true;
        }
    }
}
