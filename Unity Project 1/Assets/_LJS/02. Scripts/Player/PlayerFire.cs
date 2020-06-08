using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알 오브젝트를 담을 변수
    public GameObject bulletObject;
    // 총알 발사 위치를 담을 변수
    public GameObject firePoint;

    // 레이저를 발사하기 위해서는 LineRenderer가 필요 (선은 시작점과 끝점, 최소 2개의 점이 필요)
    // LineRenderer 컴포넌트를 담을 변수
    LineRenderer lr;
    
    // 레이저 출력 시간
    public float rayTime = 0.3f;
    // 레이저 출력 시간 누적량 변수
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject는 활성화, 비활성화 시 SetActive() 함수를 사용하나, 컴포넌트는 enabled 속성을 사용
        // LineRenderer 컴포넌트 추출
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 레이저 출력 기능이 활성화 되어 있을 때 레이저 출력
        if (lr.enabled) ShowRay();
    }

    // 레이저 출력 함수
    private void ShowRay()
    {
        // 레이저 지속 시간 타이머 누적
        timer += Time.deltaTime;
        // 지속 시간 누적량이 출력 시간 기준을 넘어섰을 경우
        if (timer > rayTime)
        {
            // 레이저 출력 해제 및 누적 시간 초기화
            lr.enabled = false;
            timer = 0.0f;
        }
    }

    // 레이저 발사 함수
    public void FireRay()
    {
        // LineRenderer 컴포넌트 활성화
        lr.enabled = true;
        // 라인의 시작점, 끝점 설정 (라인의 끝점은 충돌된 지점으로 변경)
        lr.SetPosition(0, transform.position);
        // lr.SetPosition(1, transform.position + Vector3.up * 10);

        // Ray를 이용하여 충돌 처리
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            // 레이저의 끝점을 충돌한 오브젝트 기준 좌표로 지정
            lr.SetPosition(1, hitInfo.point);
            // 충돌된 오브젝트 모두 지우기
            // Destroy(hitInfo.collider.gameObject);

            // DestroyZone과는 충돌 처리가 되지 않도록 설정
            if (hitInfo.collider.name != "Top")
            {
                Destroy(hitInfo.collider.gameObject);
            }

            // Prefab으로 만든 오브젝트는 생성될 때 클론으로 생성됨
            // Contains("Enemy") => Enemy(clone) 이런 것도 포함
            // 충돌된 에너미 오브젝트 삭제
            // if (hitInfo.collider.name.Contains("Enemy"))
            // {
            //     Destroy(hitInfo.collider.gameObject);
            // }

        }
        else
        {
            // 충돌된 오브젝트가 없으므로 끝점을 새로 지정
            lr.SetPosition(1, transform.position + Vector3.up * 10);
        }
    }

    // Fire 버튼 클릭 시 총알을 발사하는 함수
    public void OnFireButtonClick()
    {
        // 총알 게임오브젝트 생성
        GameObject bullet = Instantiate(bulletObject);

        // 총알 오브젝트의 위치 지정
        // bullet.transform.position = transform.position;
        bullet.transform.position = firePoint.transform.position;
    }
}
