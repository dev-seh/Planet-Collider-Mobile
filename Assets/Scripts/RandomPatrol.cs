﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    float speed;
    Vector2 targetPosition;
    public float minSpeed;
    public float maxSpeed;
    public float secondsToMaxDifficulty;
    public GameObject restartPanel;


    void Start()
    {
        targetPosition = GetRandomPosition();
    }


    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }
    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            restartPanel.SetActive(true);
        }
    }
        float GetDifficultyPercent()
        {
            return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
        }
    }
