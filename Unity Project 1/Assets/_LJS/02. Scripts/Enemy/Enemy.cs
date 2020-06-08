using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 총알 오브젝트를 담을 변수
    public GameObject bulletObject;
    // 목표물 오브젝트를 담을 변수
    public GameObject target;
    // 총알 발사 간격
    public float fireTime = 1.0f;
    // 총알 발사 간격 누적 시간
    float currentTime = 0.0f;
    // 최대 총알 갯수
    public int bulletMax = 10;
    // 적 이동 속도
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // 스폰된 적이 아래로 지속 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 총알 자동 발사
        AutoFire();
    }

    void AutoFire()
    {
        //타겟이 없을때 에러발생하니 예외처리
        if (target != null)
        {
            currentTime += Time.deltaTime;
            if (currentTime > fireTime)
            {
                //총알공장에서 총알생성
                GameObject bullet = Instantiate(bulletObject);
                //총알생성 위치
                bullet.transform.position = transform.position;
                //플레이어를 향하는 방향 구하기 (벡터의 뺄셈)
                Vector3 dir = target.transform.position - transform.position;
                dir.Normalize();
                //총구의 방향도 맞춰준다(이게 중요함)
                bullet.transform.up = dir;
                //타이머 초기화
                currentTime = 0.0f;
            }
        }
    }
}
