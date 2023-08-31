using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefeb;
    float spawnRateMin = 0.5f;
    float spawnRateMax = 1f;

    private float SpawnRate;
    private float timeAfterSpawn;


    private void Start()
    {
        timeAfterSpawn = 0f;
        SpawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= SpawnRate) 
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefeb, transform.position,transform.rotation);

            SpawnRate = Random.Range(spawnRateMin,spawnRateMax);
        }
    }
}
