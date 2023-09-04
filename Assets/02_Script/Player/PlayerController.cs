using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 데이터")]
    public float speed = 6.0f;
    public Vector3 inputVec;
    public float turnSpeed = 1.0f;
    int hp = 5;

    public PoolObjectType bulletType;
    public EnermyScanner scanner;
    [Header("컴포넌트")]
    private Rigidbody rigid;

    Quaternion rotate;
    Transform firePos;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        scanner = GetComponent<EnermyScanner>();
    }

    private void Start()
    {
        firePos = transform.GetChild(0);
        StartCoroutine(AttackCorutine());
    }

    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.z = Input.GetAxisRaw("Vertical");

        if (!scanner.nearestTarget)
        {

            rotate = Quaternion.identity;
        }
        else
        {
            Vector3 targetPos = scanner.nearestTarget.position;
            Vector3 dir = targetPos - firePos.position;
            dir = dir.normalized; // 정규화

            rotate = Quaternion.LookRotation(dir);
        }
    }

    private void FixedUpdate()
    {
        Vector3 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    IEnumerator AttackCorutine()
    {
        while (true)
        {
                GameObject obj = Factory.Inst.GetObject(bulletType);
                obj.transform.position = transform.position;
                obj.transform.rotation = rotate;

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnDie()
    {
        gameObject.SetActive(false);
    }
}