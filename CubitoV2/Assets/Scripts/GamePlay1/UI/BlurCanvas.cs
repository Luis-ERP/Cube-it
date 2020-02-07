using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurCanvas : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject gameOverCanvas;
    public GameObject configCanvas;

    public GameObject panel;
    public GameObject label1;

    public void EnableCanvas(bool _enable, string _canvas)
    {
        panel.SetActive(_enable);
        label1.SetActive(_enable);

        Text label1Text = label1.GetComponent<Text>();

        if (_canvas == "pause")
        {
            label1Text.text = "Pause";
            pauseCanvas.SetActive(_enable);
        }
        else if (_canvas == "gameOver")
        {
            label1Text.text = "GameOver";
            gameOverCanvas.SetActive(_enable);
        }
        else if (_canvas == "config")
        {
            label1Text.text = "Configurations";
            configCanvas.SetActive(_enable);
        }
        else
        {
            label1Text.text = "";
            Debug.Log("Canvas not found");
        }
    }
}
