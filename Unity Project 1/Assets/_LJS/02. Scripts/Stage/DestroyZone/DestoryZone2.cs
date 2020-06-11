using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryZone2 : MonoBehaviour
{
    // 트리거 감지 후 해당 오브젝트 삭제
    private void OnTriggerEnter(Collider coll)
    {
        // 총알 탐지
        if (coll.gameObject.tag == "BULLET_D2")
        {
            // 1. 배열 사용 시
            // if (other.gameObject.name.Contains("Bullet"))
            // {
            //     other.gameObject.SetActive(false);
            // }

            // 2. 리스트 사용 시 (레이어로 충돌체 찾기)
            // if (other.gameObject.name.Contains("Bullet"))
            // if (other.gameObject.layer == LayerMask.NameToLayer("PLAYER_BULLET_PRIMARY"))
            // {
            //     other.gameObject.SetActive(false);
            //     // 플레이어 오브젝트의 PlayerFire 컴포넌트의 리스트 오브젝트 풀 속성 추가
            //     GameObject.Find("Player").GetComponent<PlayerFire>().bulletPool.Add(other.gameObject);
            // }

            // 3. 큐 사용 시 (레이어로 충돌체 찾기)
            // if (other.gameObject.name.Contains("Bullet"))

            // 플레이어 총알 제거
            if (coll.gameObject.layer == LayerMask.NameToLayer("PLAYER_BULLET_PRIMARY"))
            {
                coll.gameObject.SetActive(false);
                // 플레이어 오브젝트의 PlayerFire 컴포넌트의 리스트 오브젝트 풀 속성 추가
                GameObject.Find("Player").GetComponent<PlayerFirePrimary>().bulletPool.Enqueue(coll.gameObject);
            }
            // 적 총알 제거
            else if (coll.gameObject.layer == LayerMask.NameToLayer("ENEMY_BULLET"))
            {
                Destroy(coll.gameObject);
            }
        }
        // 적 기체 제거
        else if (coll.gameObject.tag == "ENEMY")
        {
            Destroy(coll.gameObject);
        }
    }
}
