using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 탄 속도 설정 (기본값)
    public float speed = 10.0f;
    // 충돌한 오브젝트의 레이어 추출값을 담을 변수
    private int layer;

    void Awake()
    {
        layer = LayerMask.NameToLayer("PLAYER_OBJECT");
    }

    // Update is called once per frame
    void Update()
    {
        // 탄 이동
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 플레이어일 경우 플레이어 사망 처리
        if (other.gameObject.tag == "PLAYER" && other.gameObject.layer == layer)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
