using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 위에서 아래로 떨어지기만 한다 (똥피하기 느낌)
    // 충돌처리 (에너미랑 플레이어, 에너미랑 플레이어 총알)

    // 낙하 속도
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // 적 이동
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    // 충돌 시 오브젝트 없애기
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PLAYER" && other.gameObject.layer == 8)
        {
            // 자기 자신과 충돌한 오브젝트를 동시에 없애기
            // Destroy(gameObject, 1.0f);   //1초후에 오브젝트 삭제
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
