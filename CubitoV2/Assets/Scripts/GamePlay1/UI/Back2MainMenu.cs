using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back2MainMenu : MonoBehaviour
{
    public void Change2MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
