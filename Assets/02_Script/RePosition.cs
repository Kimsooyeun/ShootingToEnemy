using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
     float dirx;
     float dirz;
     Vector3 playerDir;
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffx = Mathf.Abs(playerPos.x - myPos.x);
        float diffz = Mathf.Abs(playerPos.z - myPos.z);
        //Debug.Log("dirx : " + dirx + "dirz :"+ dirz);

        switch (transform.tag)
        {
            case "Ground":
                if(diffx > diffz)
                {
                    transform.Translate(Vector3.right * dirx * 40);
                    dirx = 0;
                }
                else if(diffx < diffz)
                {
                    transform.Translate(Vector3.forward * dirz * 40);
                    dirz = 0;
                }
                break;
            case "Enemy":
                    Debug.Log(playerDir);
                    transform.Translate(playerDir * 20f +
                        new Vector3(Random.Range(-3f,3f), 0 , Random.Range(-3f, 3f))
                        );

                break;

        }
    }



    private void FixedUpdate()
    {
        NewPos();
    }

    void NewPos()
    {
        playerDir = GameManager.instance.player.inputVec;
        if (playerDir.x < 0)
        {
            dirx = -1.0f;
        }
        else if (playerDir.x > 0)
        {
            dirx = 1.0f;
        }

        if (playerDir.z < 0)
        {
            dirz = -1.0f;
        }
        else if (playerDir.z > 0)
        {
            dirz = 1.0f;
        }
    }
}
