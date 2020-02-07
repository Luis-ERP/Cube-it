using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    SpriteRenderer rend;
    public int fadeMode = 0; // 0: fadeIn     1: fadeOut

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (fadeMode == 0)
        {
            Color c = rend.material.color;
            c.a = 0f;
            rend.material.color = c;
        }
        
    }

    IEnumerator FadeOut()
    {
        for (float f=1f; f >= -0.05f; f = -0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartFadingIn()
    {
        StartCoroutine("FadeIn");
    }

    public void StartFadingOut()
    {
        StartCoroutine("FadeOut");
    }
}
