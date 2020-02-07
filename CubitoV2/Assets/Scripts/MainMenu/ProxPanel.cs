using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProxPanel : MonoBehaviour
{
    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadCommingSoon()
    {
        SceneManager.LoadScene("Achievements");
    }
    
}
