using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnRate = 0.5f;
    public GameObject hexagonPrefab;
    private float nextTime2Spawn = 0f;

    public bool randomColorMode = false;
    float h;
    float s;
    float v;

    void Start()
    {
        h = Random.Range(0f, 1f);
        s = 1f;
        v = .4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime2Spawn)
        {
            GameObject hex = Instantiate(hexagonPrefab, new Vector3(0,0,1), Quaternion.identity);
            if (randomColorMode)
            {
                hex.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(h, s, v);
            }
            nextTime2Spawn = Time.time + 1f / spawnRate;
        }
    }
}
