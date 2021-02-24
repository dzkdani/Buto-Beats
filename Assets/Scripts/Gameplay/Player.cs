using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {

    }

    public void AddScore(int value)
    {
        score += value;
        LevelManager.Instance.scoreText.text = "Score : " + score;
        LevelManager.Instance.CheckUpLevel(score);        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            LevelManager.Instance.GotoDeadScene(score);
        }
    }

    public bool TakePoint(int value)
    {
        if (score >= 1)
        {
            AddScore(-1);
            return true;
        }
        return false;

    }
}
