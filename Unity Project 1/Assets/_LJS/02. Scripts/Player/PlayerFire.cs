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

    // 레이저를 발사하기 위해서는 LineRenderer가 필요
    private LineRenderer lr;
    // 일정 시간 동안만 레이저 출력
    public float rayTime = 0.3f;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // LineRenderer 컴포넌트 추가
        lr = GetComponent<LineRenderer>();
        // 컴포넌트를 활성화, 비활성화 시킬 경우 SetActive가 아닌 enabled 사용
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        FireRay();

        // 일정 시간이 지나면 레이저 출력 비활성화
        if (lr.enabled) ShowRay();
    }

    void ShowRay()
    {
        timer += Time.deltaTime;
        if (timer > rayTime)
        {
            lr.enabled = false;
            timer = 0.0f;
        }
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
    private void FireRay()
    {
        if (Input.GetKey(KeyCode.X))
        {
            // LineRenderer 컴포넌트 활성화
            lr.enabled = true;
            // 라인의 시작점, 끝점
            lr.SetPosition(0, transform.position);
            // lr.SetPosition(1, transform.position + Vector3.up * 10);
            // 오브젝트와 충돌한 지점을 끝점으로 변경
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo;     // Ray와 충돌한 오브젝트의 정보를 담는 변수
            // Ray와 충돌한 오브젝트가 존재할 경우
            if (Physics.Raycast(ray, out hitInfo))
            {
                lr.SetPosition(1, hitInfo.point);
                // 충돌된 적 오브젝트 지우기
                if (hitInfo.collider.tag == "ENEMY")
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
            // 충돌하지 않았을 경우
            else
            {
                lr.SetPosition(1, transform.position + Vector3.up * 100);
            }
        }
    }
}
