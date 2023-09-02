using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject
{
    public float speed = 4f;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(LifeOver(5.0f));
    }

    private void Start()
    {
        //rigid.velocity = transform.forward * speed;
    }

    /* private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Enemy"))
         {
             StartCoroutine(LifeOver(0.0f));
         }
     }*/

    private void FixedUpdate()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(LifeOver(0.0f));
        }
    }
}