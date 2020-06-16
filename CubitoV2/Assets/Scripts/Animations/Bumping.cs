using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bumping : MonoBehaviour
{
    public float shrinkSpeed = 0.25f;

    public float amplitud = 0.08f;
    public float quantity = 20f;
    public float baseScale = 1f;

    // Update is called once per frame
    void Update()
    {
        float x = shrinkSpeed * Time.time;
        float y = amplitud * Mathf.Sin(quantity * x) + baseScale;
        try
        {
            transform.localScale = Vector3.one * y;
        }
        catch
        {
            gameObject.GetComponent<RectTransform>().localScale = Vector3.one * y;
        }
        
        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }
    }
}
