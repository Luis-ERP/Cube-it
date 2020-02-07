using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    public GameObject cameraScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            cameraScript.GetComponent<Main>().score++;
            this.GetComponent<BaseSpawn>().SpawnBase();
        }
    }
}
