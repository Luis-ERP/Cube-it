using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgShrink2 : MonoBehaviour
{
    float shrinkSpeed = 0.152f;
    float deltaTime = 0.05f;
    float counter = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = shrinkSpeed * counter;
        float y = 0.15f * Mathf.Sin(10f * Mathf.PI * 0.5f * x) - x + 3.5f;
        transform.localScale = Vector3.one * y;
        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }
        counter += deltaTime;
    }
}
