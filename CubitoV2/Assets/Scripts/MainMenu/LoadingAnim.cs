using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnim : MonoBehaviour
{
    Text actualColor;
    public float animDuration = 0.05f;

    public GameObject panelObj;
    public GameObject playBtnObj;

    RectTransform text;
    RectTransform panel;

    Image playBtn;
    

    // Start is called before the first frame update
    void Start()
    {
        // text
        actualColor = GetComponent<Text>();
        // transform
        text = GetComponent<RectTransform>();
        panel = panelObj.GetComponent<RectTransform>();
        //  image
        playBtn = playBtnObj.GetComponent<Image>();

        Color c = actualColor.color;
        c.a = 0f;
        actualColor.color = c;

        StartAnimation();
    }


    IEnumerator Animation()
    {
        // FadeIn
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = actualColor.color;
            c.a = f;
            actualColor.color = c;
            yield return new WaitForSeconds(animDuration);
        }

        yield return new WaitForSeconds(1f);

        // Shrink
        for (float s = 1; s >= -0.05f; s -= 0.05f)
        {
            text.localScale = new Vector3(s, s, 1);
            if (s*10+0.5 >= 1)
            {
                panel.localScale = new Vector3(s * 10, s * 10, 1);
            }
            yield return new WaitForSeconds(animDuration);
        }

        yield return new WaitForSeconds(0.05f);

        // Start bumping
        panelObj.GetComponent<Bumping>().enabled = true;

        yield return new WaitForSeconds(animDuration);

        // Appear Btn
        playBtnObj.SetActive(true);
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = playBtn.GetComponent<Image>().color;
            c.a = f;
            playBtn.color = c;
            yield return new WaitForSeconds(animDuration);
        }


    }

    public void StartAnimation()
    {
        StartCoroutine("Animation");
    }

}
