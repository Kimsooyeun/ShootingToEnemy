using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PoolObjectType objectType;
    public float min = 5.0f;
    public float max = 10.0f;
    public float interval = 1.0f;
    protected PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);  // 인터벌만큼 대기

            // 생성하고 생성한 오브젝트를 스포너의 자식으로 만들기
            GameObject obj = Factory.Inst.GetObject(objectType);

            // 생성한 게임오브젝트에서 EnemyBase 컴포넌트 가져오기
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            enemy.transform.position = transform.position;  // 스포너 위치로 이동

            // 상속 받은 클래스별 별도 처리
            OnSpawn(enemy);
        }
    }

    protected virtual void OnSpawn(EnemyBase enemy)
    {
        float r = Random.Range(min, max);
        enemy.transform.Translate(Vector3.left * r);
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
