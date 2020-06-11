using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    // Enemy 컴포넌트를 저장할 변수
    private EnemyInfo enemyObject;
    // 이펙트 오브젝트를 저장할 변수
    public GameObject[] fxObject;
    private int fxNum = 0;
    // 사운드 정보를 담을 변수
    private AudioSource audio;
    public AudioClip[] audioClip;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        enemyObject = gameObject.GetComponent<EnemyInfo>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        // 플레이어 총알과 충돌했을 경우
        if (coll.gameObject.tag == "BULLET_D1" && coll.gameObject.layer == LayerMask.NameToLayer("PLAYER_BULLET_PRIMARY"))
        {
            // 오브젝트의 체력 감소 및 충돌한 플레이어 총알 비활성화
            if (coll.gameObject.layer == LayerMask.NameToLayer("PLAYER_BULLET_PRIMARY"))
            {
                coll.gameObject.SetActive(false);
                // 플레이어 오브젝트의 PlayerFire 컴포넌트의 리스트 오브젝트 풀 속성 추가
                GameObject.Find("Player").GetComponent<PlayerFirePrimary>().bulletPool.Enqueue(coll.gameObject);
            }
            enemyObject.enemyCurrentHP -= 5;
            // 체력이 0이 되었을 경우 오브젝트 제거
            if (enemyObject.enemyCurrentHP <= 0)
            {
                // 사운드 출력
                audio.clip = audioClip[0];
                audio.Play();

                Destroy(gameObject);
                // 폭발 이펙트 출력
                ShowEffect();
                // 점수 추가
                ScoreMgr.instance.AddScore();
            }
        }
    }

    // 폭발 이펙트 출력 함수
    void ShowEffect()
    {
        fxNum = Random.Range(0, 2);
        GameObject fx = Instantiate(fxObject[fxNum]);
        fx.transform.position = transform.position;
    }
}
