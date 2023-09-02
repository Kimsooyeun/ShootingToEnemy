using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : EnemyBase
{
    public int maxHitPoint = 1;

    [SerializeField]
    private int hitPoint = 1;
    private float speed = 4f;
    public float frequency = 1;

    [Range(0.1f, 3.0f)]
    public float amplitude = 1;

    private PlayerController playerBase;

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerBase =FindObjectOfType<PlayerController>();
    }

    protected override void OnEnable()
    {
        transform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        // 플레이어와 적의 위치 차이 벡터 계산
        Vector3 dirVec = playerBase.transform.position - transform.position;
        Vector3 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector3.zero;

        transform.LookAt(playerBase.transform);
    }

    protected override void Attacked()
    {
        hitPoint--;
        OnHit();
        if (hitPoint < 1)
        {
            Crush();
            hitPoint = maxHitPoint;
        }
    }

    protected override void OnHit()
    {
        base.OnHit();
    }
}
