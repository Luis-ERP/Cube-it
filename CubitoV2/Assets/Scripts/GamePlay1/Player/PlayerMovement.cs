using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public Transform player;

    public GameObject cameraScript;
    public float speed = 10f;

    private void FixedUpdate()
    {
        Movement(new Vector2(joystick.Horizontal, joystick.Vertical));
    }

    void Movement(Vector2 direction)
    {
        int score = cameraScript.GetComponent<Main>().score;
        float magnitud = (float) Math.Sqrt(Math.Pow(direction.x, 2) + Math.Pow(direction.y, 2));
        if (magnitud == 0f){
        	magnitud = 1f;
        }
        Vector2 unitario = new Vector2(direction.x/magnitud, direction.y/magnitud);
        speed = SpeedFunction(score);
        player.Translate(unitario * speed * Time.deltaTime);
    }

    float SpeedFunction(int _score)
    {
        if (_score < 30)
        {
            return (float)(7.7 * Math.Tanh(0.015 * Math.Pow(_score, 1.25)) + 4);
        }
        else
        {
            return (float)(14 * Math.Tanh(0.3 * _score));
        }
    }
}
