using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyBase;
    float spawnRateMin = 0.5f;
    float spawnRateMax = 1f;

    public Transform target;
    private float SpawnRate;
    private float timeAfterSpawn;


    private void Start()
    {
        timeAfterSpawn = 0f;
        SpawnRate = Random.Range(spawnRateMin, spawnRateMax);
        PlayerController player = FindObjectOfType<PlayerController>();
        target = player.transform;
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= SpawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject Enemy = Instantiate(EnemyBase, transform.position, transform.rotation);
            Enemy.transform.LookAt(target);

            SpawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
