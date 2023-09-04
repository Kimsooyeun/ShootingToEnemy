using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : EnemyBase
{

    [SerializeField]
    private float speed = 3f;
    public float frequency = 1;

    [Range(0.1f, 3.0f)]
    public float amplitude = 1;

    private PlayerController playerBase;
    Rigidbody rigid;

    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody>();
        score = 5;
        hitPoint = 2;
        maxHitPoint = 2;
    }

    private void Start()
    {
        playerBase =FindObjectOfType<PlayerController>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.localPosition = Vector3.zero;
        rigid.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        // 플레이어와 적의 위치 차이 벡터 계산
        Vector3 dirVec = playerBase.transform.position - transform.position;
        Vector3 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector3.zero;

        transform.LookAt(playerBase.transform);
    }
}
