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
        // 플레이어와 적의 위치 차이 벡터 계산
        Vector3 moveDirection = playerBase.transform.position - transform.position;

        // 벡터를 정규화하여 이동 방향 설정
        Vector3 normalizedMoveDirection = moveDirection.normalized;

        // 이동 방향으로 이동
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
