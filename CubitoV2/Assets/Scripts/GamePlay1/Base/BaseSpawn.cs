using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawn : MonoBehaviour
{
    public Transform player;
    public float noSpawningRadius = 2.5f;

    private Vector2 screenBounds;
    Vector3 position;

    public void SpawnBase()
    {
        do
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            float randX = Random.Range((screenBounds.x * -1) + 2, (screenBounds.x)-2);
            float randY = Random.Range((screenBounds.y * -1) + 2, (screenBounds.y) - 2);
            position = new Vector3(randX, randY, 0);
        }
        while (EuclideanDistance(position.x, player.transform.position.x, position.y, player.transform.position.y) < noSpawningRadius);
        transform.position = position;
    }

    private float EuclideanDistance(float x1, float x2, float y1, float y2)
    {
        float answer;

        answer = Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
        return answer;
    }
}
