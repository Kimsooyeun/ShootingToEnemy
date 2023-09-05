using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PoolObjectType objectType;
    public float min = -9.0f;
    public float max = 9.0f;
    public float interval = 1.0f;
    protected PlayerController player = null;
    public Transform[] spawnPoint;

    protected void Start()
    {
        StartCoroutine(Spawn());
    }

    protected void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        spawnPoint = player.transform.GetChild(2).GetComponentsInChildren<Transform>();
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);  // 인터벌만큼 대기

            //생성한 오브젝트를 스포너의 자식으로 만들기
            GameObject obj = Factory.Inst.GetObject(objectType);

            // 생성한 게임오브젝트에서 EnemyBase 컴포넌트 가져오기
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            EnemyBase enemy2 = obj.GetComponent<EnemyBase>();
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            enemy2.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            // 상속 받은 클래스별 별도 처리
            OnSpawn(enemy, enemy2);
        }
    }

    protected virtual void OnSpawn(EnemyBase enemy, EnemyBase enemy2)
    {
        float r = Random.Range(min, max);
        //enemy.transform.Translate(Vector3.left * r);
        Debug.Log("enemy OnSpawn:" + enemy.transform.position);
    }

    virtual protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,
            new Vector3(Mathf.Abs(max) + Mathf.Abs(min) + 2, 1, 1));
    }

    virtual protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 from = transform.position + Vector3.up * min;
        Vector3 to = transform.position + Vector3.up * max;
        Gizmos.DrawLine(from, to);
    }
}
