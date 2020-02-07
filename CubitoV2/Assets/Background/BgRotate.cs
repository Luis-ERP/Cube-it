using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRotate : MonoBehaviour
{
    public float rotateAngle = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateAngle * Time.deltaTime);
    }
}
