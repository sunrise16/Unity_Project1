using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    // 플레이어 오브젝트
    public GameObject target;
    // 유도탄 속도
    public float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        // 타겟 방향 구하기 (벡터의 뺄셈)
        // 방향 = 타겟 - 자기 자신
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
