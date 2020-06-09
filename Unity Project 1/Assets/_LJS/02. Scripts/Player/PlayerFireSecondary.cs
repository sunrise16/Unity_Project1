using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireSecondary : MonoBehaviour
{
    // 플레이어 보조무기 오브젝트를 담을 변수
    public GameObject secondary;

    // 레이저를 발사하기 위해서는 LineRenderer가 필요 (선은 시작점과 끝점, 최소 2개의 점이 필요)
    // LineRenderer 컴포넌트를 담을 변수
    LineRenderer lr;
    // 사운드 재생
    AudioSource audio;

    // 플레이어 보조 샷 레이저 데미지 딜레이
    private float secondaryDelay = 0.05f;
    // 플레이어 보조 샷 레이저 데미지 딜레이 누적값
    private float secondaryTimer = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject는 활성화, 비활성화 시 SetActive() 함수를 사용하나, 컴포넌트는 enabled 속성을 사용
        // LineRenderer 컴포넌트 추출
        lr = GetComponent<LineRenderer>();

        // 오디오 소스 컴포넌트 캐스팅
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 보조 샷 발사
        SecondaryShot();
    }

    // 보조 샷 발사 함수
    public void SecondaryShot()
    {
        // 보조무기가 활성화 된 상태에서 Z 키를 누르고 있을 경우
        if (Input.GetKey(KeyCode.Z) && secondary.activeSelf == true)
        {
            // 레이저 사운드 재생 (중복 재생 방지)
            if (!audio.isPlaying)
            {
                audio.Play();
            }

            // LineRenderer 컴포넌트 활성화
            lr.enabled = true;
            // 라인의 시작점, 끝점 설정 (라인의 끝점은 충돌된 지점으로 변경)
            lr.SetPosition(0, transform.position);
            // lr.SetPosition(1, transform.position + Vector3.up * 10);

            // 플레이어 서브 샷 데미지 딜레이 누적값 증가
            secondaryTimer += Time.deltaTime;
            // 누적값이 데미지 딜레이 기준점을 넘어섰을 경우
            if (secondaryTimer > secondaryDelay)
            {
                secondaryTimer = 0.0f;
            }

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
        // Z 키를 누르고 있다가 뗐을 경우
        if (Input.GetKeyUp(KeyCode.Z) && secondary.activeSelf == true)
        {
            // LineRenderer 컴포넌트 비활성화
            lr.enabled = false;
            // 효과음 중지
            audio.Stop();
            // 플레이어 서브 샷 데미지 딜레이 누적값 재설정
            secondaryTimer = 0.04f;
        }
    }
}
