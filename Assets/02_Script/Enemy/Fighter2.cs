using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter2 : EnemyBase
{
    [SerializeField] private float speed = 8.0f;
    [Range(0.1f, 3.0f)]
    public float amplitude = 1;

    private PlayerController player;
    Rigidbody rigid;

    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
        score = 10;
        hitPoint = 4;
        maxHitPoint = 4;

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.localPosition = Vector3.zero;
        rigid.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Vector3 dirVec = player.transform.position - transform.position;
        Vector3 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector3.zero;

        transform.LookAt(player.transform);
    }

    IEnumerator AttactToPlayer()
    {
        yield return new WaitForSeconds(1.5f);
    }

}
