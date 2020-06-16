using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgShrink : MonoBehaviour
{
    public float shrinkSpeed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
