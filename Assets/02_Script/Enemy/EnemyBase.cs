using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : PoolObject
{
    private int EnemyHp = 5;
    private float speed = 4f;
    public Transform player;
    private PlayerController playerBase;
    Rigidbody rigid;

    Bullet bullet;
    private void Awake()
    {
        playerBase = FindObjectOfType<PlayerController>();
        rigid = GetComponent<Rigidbody>();
        bullet = FindObjectOfType<Bullet>();
    }

    private void Start()
    {
        player = playerBase.transform;
    }

    private void OnEnable()
    {
        bullet.OnAttack += OnAttacted;
    }

    private void OnDisable()
    {
        bullet.OnAttack -= OnAttacted;
    }

    private void Update()
    {
        // �÷��̾�� ���� ��ġ ���� ���� ���
        Vector3 moveDirection = player.position - transform.position;

        // ���͸� ����ȭ�Ͽ� �̵� ���� ����
        Vector3 normalizedMoveDirection = moveDirection.normalized;

        // �̵� �������� �̵�
        transform.position += normalizedMoveDirection * speed * Time.deltaTime;
    }

    private void OnAttacted()
    {
        EnemyHp--;

        if(EnemyHp < 1)
        {
            Destroy(gameObject);
        }
    }

}
