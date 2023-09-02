using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : PoolObject
{
    /*private int EnemyHp = 5;
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
    }*/

    /*public int maxHitPoint = 1;
    public float moveSpeed = 3.0f;
    public int score = 10;

    private int hitpoint = 1;*/
    PlayerController player;

    public PlayerController TargetPlayer
    {
        protected get => player;
        set
        {
            if (player == null)
                player = value;
        }
    }

    protected virtual void OnEnable()
    {
        /*hitpoint = maxHitPoint;*/
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Attacked();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("�浹");
            Attacked();
        }
    }

    protected virtual void Attacked()
    {
    }

    protected virtual void OnHit()
    {
    }

    protected void Crush()
    {
            /*GameObject obj = Factory.Inst.GetObject(destroyEffect);
            obj.transform.position = transform.position;*/

            gameObject.SetActive(false);    // ��Ȱ��ȭ 
    }

    /*protected virtual void OnCrush()
    {
        player?.AddScore(score);
    }*/
}