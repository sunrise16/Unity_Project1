using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // 플레이어 본체 오브젝트
    public GameObject player;

    private void OnTriggerEnter(Collider coll)
    {
        // 적 본체와 충돌했을 경우
        if (coll.gameObject.tag == "ENEMY")
        {
            // 플레이어 오브젝트만 제거
            Destroy(player);
        }
        // 적 총알과 충돌했을 경우
        else if (coll.gameObject.tag == "BULLET" && coll.gameObject.layer == LayerMask.NameToLayer("ENEMY_BULLET"))
        {
            // 플레이어 오브젝트와 충돌한 적 총알 전부 제거
            Destroy(player);
            Destroy(coll.gameObject);
        }
    }
}
