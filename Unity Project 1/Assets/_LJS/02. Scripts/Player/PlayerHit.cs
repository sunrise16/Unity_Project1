using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // 이펙트 오브젝트를 저장할 변수
    public GameObject fxObject;

    private void OnTriggerEnter(Collider coll)
    {
        // 적 본체와 충돌했을 경우
        if (coll.gameObject.tag == "ENEMY")
        {
            // 폭발 이펙트 출력
            ShowEffect();
            // 플레이어 오브젝트만 제거
            Destroy(gameObject);
        }
        // 적 총알과 충돌했을 경우
        else if (coll.gameObject.layer == LayerMask.NameToLayer("ENEMY_BULLET"))
        {
            // 폭발 이펙트 출력
            ShowEffect();
            // 플레이어 오브젝트와 충돌한 적 총알 전부 제거
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

    // 폭발 이펙트 출력 함수
    void ShowEffect()
    {
        GameObject fx = Instantiate(fxObject);
        fx.transform.position = transform.position;
    }
}
