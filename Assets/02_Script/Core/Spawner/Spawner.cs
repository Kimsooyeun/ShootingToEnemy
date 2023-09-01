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
            yield return new WaitForSeconds(interval);  // ���͹���ŭ ���

            // �����ϰ� ������ ������Ʈ�� �������� �ڽ����� �����
            GameObject obj = Factory.Inst.GetObject(objectType);

            // ������ ���ӿ�����Ʈ���� EnemyBase ������Ʈ ��������
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            enemy.transform.position = transform.position;  // ������ ��ġ�� �̵�

            // ��� ���� Ŭ������ ���� ó��
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
