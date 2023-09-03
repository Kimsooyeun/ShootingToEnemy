using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : PoolObject
{
    public int score = 10;
    public int maxHitPoint = 1;
    [SerializeField]
    public int hitPoint = 1;
    protected ScoreBoard scoreBoard;
    bool isCrushed = false;

    protected virtual void Awake()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    protected virtual void OnEnable()
    {
        isCrushed = false;
        hitPoint = maxHitPoint;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Attacked();
        }
    }

    protected virtual void Attacked()
    {
        hitPoint--;
        OnHit();
        if (hitPoint < 1)
        {
            Crush();
        }
    }

    protected virtual void OnHit()
    {
    }

    protected void Crush()
    {
        if (!isCrushed)
        {
            isCrushed = true;          
            OnCrush();

            gameObject.SetActive(false);
        }
    }

    protected virtual void OnCrush()
    {
        scoreBoard.AddScore(score);
    }
}