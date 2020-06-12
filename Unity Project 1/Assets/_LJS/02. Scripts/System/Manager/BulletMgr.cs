using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : MonoBehaviour
{
    // 총알 오브젝트를 담을 변수
    public GameObject bulletObject;
    // 총알 부모 오브젝트를 담을 변수
    public GameObject bulletParent;
    // 목표물 오브젝트의 위치를 담을 변수
    private Transform target;

    // 오브젝트 풀링
    // 풀 최초 사이즈 설정
    int poolSize = 200;
    // 총알 오브젝트를 담을 풀
    public Queue<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        // 타겟의 위치 찾기
        target = GameObject.Find("Player").transform;

        // 오브젝트 풀링 초기화
        InitObjectPooling();
    }

    // 오브젝트 풀링 초기화 함수
    void InitObjectPooling()
    {
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletObject);
            bullet.SetActive(false);
            bullet.transform.SetParent(bulletParent.transform);
            bulletPool.Enqueue(bullet);
            // 플레이어를 향하는 방향 구하기 (벡터의 뺄셈)
            Vector3 dir = target.position - transform.position;
            dir.Normalize();
            // 총구의 방향 맞춰주기
            bullet.transform.up = dir;
        }
    }
}
