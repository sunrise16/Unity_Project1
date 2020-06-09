using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        // 적 본체와 충돌했을 경우
        if (coll.gameObject.tag == "ENEMY")
        {
            // 플레이어 오브젝트만 제거
            Destroy(gameObject);
        }
        // 적 총알과 충돌했을 경우
        else if (coll.gameObject.tag == "BULLET" && coll.gameObject.layer == LayerMask.NameToLayer("ENEMY_BULLET"))
        {
            // 플레이어 오브젝트와 충돌한 적 총알 전부 제거
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
