using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("�÷��̾� ������")]
    public float speed = 8.0f;
    public float turnSpeed = 1.0f;
    int hp = 5;


    private float mouseDelta;
    private Vector3 inputDir = Vector3.zero;
    private Vector3 v3;

    [Header("������Ʈ")]
    private PlayerInputAction input;
    private Rigidbody rigid;

    private void Awake()
    {
        input = new PlayerInputAction();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //GetAxis : �������Ӹ��� ȣ�� > CPU ������ƸԴ´ٴ� �̽� ����
        //InputSystem :  Ű ���� �� ȣ�� > �� ��Ƹ���
        //���� InputSystem���� �ٲ����.....................


        //------GetAxis���------------
         float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newDir = new Vector3(xSpeed, 0f, zSpeed);
        rigid.velocity = newDir;

    }

    /* private void FixedUpdate()
     {
         Move();
     }

     private void OnEnable()
     {
         input.Player.Enable();
         input.Player.Move.performed += OnPlayerMove;
         input.Player.Move.canceled += OnPlayerMove;
         input.Player.Attack.performed += OnAttack;
         //input.Player.Rotate.performed += OnRotaion;
     }

     private void OnDisable()
     {
         input.Player.Disable();
         input.Player.Move.performed -= OnPlayerMove;
         input.Player.Move.canceled -= OnPlayerMove;
         input.Player.Attack.performed -= OnAttack;
         //input.Player.Rotate.performed -= OnRotaion;
     }

     private void OnPlayerMove(InputAction.CallbackContext context)
     {
         Vector3 vec3 = context.ReadValue<Vector2>();
         inputDir.z = vec3.y;
         inputDir.x = vec3.x;
     }

    *//* private void OnRotaion(InputAction.CallbackContext context)
     {
         mouseDelta = context.ReadValue<float>();
     }*//*

     private void Move()
     {
         v3 = new Vector3(0,mouseDelta,0);
         mouseDelta = 0.0f;

         //transform.Rotate(v3 * turnSpeed);

         rigid.MovePosition(Time.fixedDeltaTime * speed * transform.TransformDirection(inputDir).normalized + transform.position);
     }*/

    private void OnAttack(InputAction.CallbackContext context)
    {
        
    }
}
