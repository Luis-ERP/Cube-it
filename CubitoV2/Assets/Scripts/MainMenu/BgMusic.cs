using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public AudioSource audioMusic;

    void Awake()
    {
        int len = Resources.FindObjectsOfTypeAll(typeof(AudioSource)).Length;
        if (len > 1)
        {
            Destroy(gameObject);
        }
        StartCoroutine(Wait());
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        audioMusic.Play();
        DontDestroyOnLoad(transform.gameObject);
    } 
}
