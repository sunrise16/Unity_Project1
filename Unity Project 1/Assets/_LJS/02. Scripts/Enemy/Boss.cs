using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // 보스 탄막 발사 (탄막 패턴)
    // 1. 플레이어를 향해 발사 (조준탄)
    // 2. 탄막 회전시키기

    // 탄막 Prefab
    public GameObject bulletFactory;
    // 플레이어 타겟
    public GameObject target;
    // 탄막 발사 딜레이
    public float fireTime1 = 1.0f;           // 1.0f = 1초에 1번씩 발사
    public float fireTime2 = 1.5f;
    private float currentTime1 = 0.0f;
    private float currentTime2 = 0.0f;
    public int bulletMax = 50;

    // Update is called once per frame
    void Update()
    {
        AutoFire1();
        AutoFire2();
    }

    // 1. 플레이어를 향해 발사 (조준탄)
    private void AutoFire1()
    {
        // 타겟이 없을 때의 예외 처리
        if (target != null)
        {
            currentTime1 += Time.deltaTime;
            if (currentTime1 > fireTime1)
            {
                // 탄막 생성
                GameObject bullet = Instantiate(bulletFactory);
                // 탄막 생성 위치
                bullet.transform.position = transform.position;
                // 플레이어 방향 구하기 (벡터의 뺄셈)
                Vector3 dir = target.transform.position - transform.position;
                dir.Normalize();            // 벡터의 방향만을 구하는 경우 반드시 Normalize를 해줄 것!
                // 총구의 방향 맞추기
                bullet.transform.up = dir;
                // 타이머 초기화
                currentTime1 = 0.0f;
            }
        }
    }

    // 2. 탄막 회전시키기
    private void AutoFire2()
    {
        // 타겟이 없을 때의 예외 처리
        if (target != null)
        {
            currentTime2 += Time.deltaTime;
            if (currentTime2 > fireTime2)
            {
                for (int i = 0; i < bulletMax; i++)
                {
                    // 탄막 생성
                    GameObject bullet = Instantiate(bulletFactory);
                    // 탄막 생성 위치
                    bullet.transform.position = transform.position;
                    // 360도 방향으로 탄막 발사
                    float angle = 360.0f / bulletMax;
                    // 총구의 방향 맞추기
                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
                }
                // 타이머 초기화
                currentTime2 = 0.0f;
            }
        }
    }
}
