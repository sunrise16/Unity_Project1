using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // 충돌한 탄 오브젝트 가져오기
    public GameObject bullet;

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 탄 또는 보스일 경우 사망 처리
        if (other.gameObject == bullet)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "ENEMY" && other.gameObject.layer == 13)
        {
            Destroy(gameObject);
        }
    }
}
