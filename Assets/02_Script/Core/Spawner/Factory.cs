using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    Bullet = 0,
    Enemy,
    Enemy2
}
public class Factory : Singleton<Factory>
{
    BulletPool bulletPool;
    EnemyPool enemyPool;
    EnemyPool2 enemyPool2;

    protected override void PreInitialize()
    {
        bulletPool = GetComponentInChildren<BulletPool>();
        enemyPool = GetComponentInChildren<EnemyPool>();
        enemyPool2 = GetComponentInChildren<EnemyPool2>();
    }

    protected override void Initialize()
    {
        bulletPool?.Initialize();
        enemyPool?.Initialize();
        enemyPool2?.Initialize();
    }

    public GameObject GetObject(PoolObjectType type)
    {
        GameObject result = null;
        switch (type) 
        {
            case PoolObjectType.Bullet:
                result = GetBullet().gameObject;
                break;
            case PoolObjectType.Enemy:
                result = GetEnemy().gameObject;
                break;
            case PoolObjectType.Enemy2:
                result = GetEnemy().gameObject;
                break;
        }

        return result;
    }

    public Bullet GetBullet() => bulletPool?.GetObject();
    public EnemyBase GetEnemy() => enemyPool?.GetObject();
    public EnemyBase GetEnemy2() => enemyPool?.GetObject();
}
