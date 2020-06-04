using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 플레이어 탄 Prefab
    public GameObject bulletFactory;
    // 플레이어 탄 발사 위치
    public GameObject firePoint;
    // 플레이어 탄 발사 딜레이
    private float currentTime = 0.0f;
    private float fireDelay = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        // Z 키로 탄 발사
        if(Input.GetKey(KeyCode.Z))
        {
            // 발사 딜레이 적용
            currentTime += Time.deltaTime;
            if (currentTime >= fireDelay)
            {
                currentTime = 0.0f;
                // Instantiate() 함수로 Prefab 파일을 게임 오브젝트로 동적 생성
                GameObject bullet = Instantiate(bulletFactory);
                // 오브젝트의 위치 지정
                // bullet.transform.position = transform.position;
                bullet.transform.position = firePoint.transform.position;
            }
        }
    }
}
