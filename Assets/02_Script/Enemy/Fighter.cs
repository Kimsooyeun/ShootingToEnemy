using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : EnemyBase
{
    public int maxHitPoint = 3;
    private int hitPoint = 3;
    private float speed = 4f;
    public float frequency = 1;
    private PlayerController playerBase;

    float baseX;
    public float Base
    {
        set => baseX = value;
    }

    private void Start()
    {
        playerBase =FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        // �÷��̾�� ���� ��ġ ���� ���� ���
        Vector3 moveDirection = playerBase.transform.position - transform.position;

        // ���͸� ����ȭ�Ͽ� �̵� ���� ����
        Vector3 normalizedMoveDirection = moveDirection.normalized;

        // �̵� �������� �̵�
        transform.position += normalizedMoveDirection * speed * Time.deltaTime;
        transform.LookAt(playerBase.transform);
    }

    protected override void Attacked()
    {
        hitPoint--;
        OnHit();
        if (hitPoint < 1)
        {
            Crush();
        }
    }

    protected override void OnHit()
    {
        base.OnHit();
    }
}
