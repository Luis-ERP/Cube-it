using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigAnim : MonoBehaviour
{
    public GameObject configBG;
    public Transform titleLabel;
    public Text betaLabel;
    public GameObject achievsIcon;
    public GameObject playBtn;
    public Image playPanel;

    bool _enabled = false;

    public void EnableConfig()
    {
        if (_enabled)
        {
            Hide();
            _enabled = false;
        }
        else
        {
            Show();
            _enabled = true;
        }
    }

    void Show()
    {
        configBG.SetActive(true);
        StartCoroutine(moveToRightGB());
        StartCoroutine(moveToRightTitle());

        betaLabel.CrossFadeAlpha(0, 0.3f, false);
        FadeOut(achievsIcon.GetComponent<Image>());
        FadeOut(playBtn.GetComponent<Image>());
        FadeOut(playPanel);

        achievsIcon.SetActive(false);
        playBtn.SetActive(false);
    }

    void Hide()
    {
        StartCoroutine(moveToLeftGB());
        StartCoroutine(moveToLeftTitle());

        achievsIcon.SetActive(true);
        playBtn.SetActive(true);

        betaLabel.CrossFadeAlpha(1, 0.3f, false);
        FadeIn(achievsIcon.GetComponent<Image>());
        FadeIn(playBtn.GetComponent<Image>());
        FadeIn(playPanel);
    }
    

    IEnumerator moveToRightGB()
    {
        for (float i = -14.5f; i < -4.5f; i += 0.5f)
        {
            configBG.transform.position = new Vector3(i, -0.6f, 0);
            yield return new WaitForSeconds(0.0f);
        }
    }

    IEnumerator moveToRightTitle()
    {
        Debug.Log("moving title right");
        int counter = 0;
        for (float i = 327.5f; i < 417.5f; i += 5f)
        {
            titleLabel.position = new Vector3(i, 257.4f, 0);
            counter++;
            Debug.Log(counter);
            yield return new WaitForSeconds(0.0f);
        }
    }

    IEnumerator moveToLeftGB()
    {
        for (float i = -5.5f; i > -14.5f; i -= 0.5f)
        {
            configBG.transform.position = new Vector3(i, -0.6f, 0);
            yield return new WaitForSeconds(0.0f);
        }
        configBG.SetActive(false);
    }

    IEnumerator moveToLeftTitle() //25.6
    {
        Debug.Log("moving title left");
        int counter = 0;
        for (float i = 397.5f; i >= 307.5f; i -= 5f)
        {
            titleLabel.position = new Vector3(i, 257.4f, 0);
            counter++;
            Debug.Log(titleLabel.position);
            yield return new WaitForSeconds(0.0f);
        }
    }


    void FadeIn(Image rend)
    {
        rend.CrossFadeAlpha(1f, 0.3f, false);
    }

    void FadeOut(Image rend)
    {
        rend.CrossFadeAlpha(0f, 0.3f, false);
    }
}
