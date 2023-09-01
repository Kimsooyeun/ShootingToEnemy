using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    Bullet = 0,
    Enemy
}
public class Factory : Singleton<Factory>
{
    BulletPool bulletPool;
    EnemyPool enemyPool;

    protected override void PreInitialize()
    {
        bulletPool = GetComponentInChildren<BulletPool>();
        enemyPool = GetComponentInChildren<EnemyPool>();
    }

    protected override void Initialize()
    {
        bulletPool?.Initialize();
        enemyPool?.Initialize();
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
        }

        return result;
    }

    public Bullet GetBullet() => bulletPool?.GetObject();
    public EnemyBase GetEnemy() => enemyPool?.GetObject();
}
