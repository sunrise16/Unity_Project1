using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    // 적 이동 속도
    public float speed = 10.0f;
    // 적의 체력
    public float enemyInitHP;
    public float enemyCurrentHP;

    void Start()
    {
        // 적의 체력 초기화
        enemyCurrentHP = enemyInitHP;
    }

    // Update is called once per frame
    void Update()
    {
        // 스폰된 적이 아래로 지속 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
