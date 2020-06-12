using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    // 총알을 꺼내올 오브젝트 풀을 담을 변수
    private BulletMgr bulletManager;
    // 목표물 오브젝트의 위치를 담을 변수
    private Transform target;
    // 사운드 정보를 담을 변수
    private AudioSource audio;
    public AudioClip[] audioClip;
    // 총알 발사 간격
    public float fireTime = 0.1f;
    // 총알 발사 간격 누적 시간
    float currentTime = 0.0f;
    // 총알 발사 갯수 제한
    private int bulletMax = 5;
    private int currentBullet = 0;
    private bool fireDelay = false;
    private float fireDelayTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 풀 찾기
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletMgr>();

        // 타겟의 위치 찾기
        target = GameObject.Find("Player").transform;

        // 오디오 소스 컴포넌트 캐스팅
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Fire();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BORDER" && other.gameObject.layer == LayerMask.NameToLayer("BORDER_BOTTOM"))
        {
            target = null;
        }
    }

    void Fire()
    {
        // 타겟이 없을때 에러가 발생하므로 예외 처리
        if (target != null)
        {
            if (!fireDelay)
            {
                currentTime += Time.deltaTime;
                if (currentTime > fireTime)
                {
                    // 사운드 재생
                    audio.clip = audioClip[0];
                    audio.Play();

                    if (bulletManager.bulletPool.Count > 0)
                    {
                        GameObject bullet = bulletManager.bulletPool.Dequeue();
                        bullet.SetActive(true);
                        bullet.transform.position = transform.position;
                        // 플레이어를 향하는 방향 구하기 (벡터의 뺄셈)
                        Vector3 dir = target.position - transform.position;
                        dir.Normalize();
                        // 총구의 방향 맞춰주기
                        bullet.transform.up = dir;
                    }
                    else
                    {
                        GameObject bullet = Instantiate(bulletManager.bulletObject);
                        bullet.SetActive(false);
                        bullet.transform.SetParent(bulletManager.bulletParent.transform);
                        bulletManager.bulletPool.Enqueue(bullet);
                        // 플레이어를 향하는 방향 구하기 (벡터의 뺄셈)
                        Vector3 dir = target.position - transform.position;
                        dir.Normalize();
                        // 총구의 방향 맞춰주기
                        bullet.transform.up = dir;
                    }

                    // 타이머 초기화
                    currentTime = 0.0f;
                    // 총알 현재 갯수 증가
                    currentBullet++;
                }
            }

            if (currentBullet >= bulletMax)
            {
                currentBullet = 0;
                fireDelay = true;
            }
            if (fireDelay)
            {
                fireDelayTime += Time.deltaTime;
            }
            if (fireDelay && fireDelayTime >= 1.0f)
            {
                fireDelayTime = 0.0f;
                fireDelay = false;
            }
        }
    }
}
