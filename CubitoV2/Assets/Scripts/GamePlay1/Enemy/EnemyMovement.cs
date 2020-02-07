using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    private GameObject cameraScript;

    private Transform player;
    private Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.transform;

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        cameraScript = GameObject.Find("Main Camera");
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        int score = cameraScript.GetComponent<Main>().score;
        speed = SpeedFunction(score);
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    float SpeedFunction(int _score)
    {
        return (float)(8 * Math.Tanh(0.015 * Math.Pow(_score, 1.3)) + 2);
    }
}
