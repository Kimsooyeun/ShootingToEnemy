using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PoolObject objectType;
    public float minY = -4;
    public float maxY = 4;
    public float interval = 1.0f;
    protected PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
            enemy.TargetPlayer = player;                    // EnemyBase�� �÷��̾� ����
            enemy.transform.position = transform.position;  // ������ ��ġ�� �̵�

            // ��� ���� Ŭ������ ���� ó��
            OnSpawn(enemy);
        }
    }
}
