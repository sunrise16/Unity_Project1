using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    // 적 본체 오브젝트
    public GameObject enemy;

    private void OnTriggerEnter(Collider coll)
    {
        // 플레이어 총알과 충돌했을 경우
        if (coll.gameObject.tag == "BULLET" &&
            coll.gameObject.layer == LayerMask.NameToLayer("PLAYER_BULLET_PRIMARY") || coll.gameObject.layer == LayerMask.NameToLayer("PLAYER_BULLET_SECONDARY"))
        {
            // 적 오브젝트와 충돌한 플레이어 총알 전부 제거
            Destroy(enemy);
            Destroy(coll.gameObject);

            // 점수 추가
            
        }
    }
}
