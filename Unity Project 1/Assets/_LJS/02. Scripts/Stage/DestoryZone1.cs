using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryZone1 : MonoBehaviour
{
    // 트리거 감지 후 해당 오브젝트 삭제
    private void OnTriggerEnter(Collider coll)
    {
        // 총알 탐지
        if (coll.gameObject.tag == "BULLET_D1")
        {
            // 트리거에 감지된 오브젝트 제거
            // Destroy(other.gameObject);

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
            if (coll.gameObject.layer == LayerMask.NameToLayer("PLAYER_BULLET_PRIMARY"))
            {
                coll.gameObject.SetActive(false);
                // 플레이어 오브젝트의 PlayerFire 컴포넌트의 리스트 오브젝트 풀 속성 추가
                GameObject.Find("Player").GetComponent<PlayerFirePrimary>().bulletPool.Enqueue(coll.gameObject);
            }

            switch (coll.gameObject.layer)
            {
                case 8:
                    break;
            }
        }
    }
}
