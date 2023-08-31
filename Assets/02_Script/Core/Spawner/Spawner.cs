using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PoolObject objectType;
    public float minY = -4;
    public float maxY = 4;
    public float interval = 1.0f;
    protected PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);  // 인터벌만큼 대기

            // 생성하고 생성한 오브젝트를 스포너의 자식으로 만들기
            GameObject obj = Factory.Inst.GetObject(objectType);

            // 생성한 게임오브젝트에서 EnemyBase 컴포넌트 가져오기
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            enemy.TargetPlayer = player;                    // EnemyBase에 플레이어 설정
            enemy.transform.position = transform.position;  // 스포너 위치로 이동

            // 상속 받은 클래스별 별도 처리
            OnSpawn(enemy);
        }
    }
}
