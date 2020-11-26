﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isUpDown;   // inspector controll
    public float movingSpeed;
    public float amplitude;
    Vector2 startPosition;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Using Sin graph
        if (isUpDown) {
            rigid.transform.position = new Vector2(
                startPosition.x, startPosition.y + amplitude * Mathf.Sin(Time.time * movingSpeed) );
        } else {
            rigid.transform.position = new Vector2(
                startPosition.x + amplitude * Mathf.Sin(Time.time * movingSpeed), startPosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player") && collision.gameObject.GetComponent<PlayerMove>().isGround ) {
            collision.transform.SetParent(transform);
            // using player script to prevent wall stick
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            collision.transform.SetParent(null);
        }
    }
}
