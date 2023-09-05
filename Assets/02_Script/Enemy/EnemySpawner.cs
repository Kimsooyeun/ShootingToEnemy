using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawner : Spawner
{
    protected override void OnSpawn(EnemyBase enemy, EnemyBase enemy2)
    {
        Fighter fighter = enemy as Fighter;
        Fighter2 fighter2 = enemy as Fighter2;
        if (fighter != null) 
        {
            float r = Random.Range(min, max);

            //fighter.transform.position = new Vector3(r, fighter.transform.position.y, fighter.transform.position.z);
        }
        if (fighter2 != null)
        {
            float r = Random.Range(min, max);

            //fighter.transform.position = new Vector3(r, fighter.transform.position.y, fighter.transform.position.z);
        }

    }
}
