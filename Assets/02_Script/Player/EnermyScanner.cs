using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class EnermyScanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit[] targets;
    public Transform nearestTarget;

    PlayerController controller;

    private void FixedUpdate()
    {
        targets = Physics.SphereCastAll(transform.position, scanRange, Vector3.forward, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;

        float diff = 100.0f;
        foreach(RaycastHit target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
            Debug.DrawLine(transform.position, target.point, Color.red, 1.0f);
        }


        Debug.DrawRay(transform.position, Vector3.up * scanRange, Color.blue);
        return result;
    }
}
