using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet1Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    // Update is called once per frame
    void Update()
    {
        // 화면 바깥으로 벗어나지 않게 하는 3가지 방법
        // 1) 화면 바깥의 공간에 큐브 4개를 만들어 배치한 후, 리지드바디의 충돌체로 이동하지 못하게 막기
        // 2) 플레이어의 포지션으로 이동 처리
        // 3) 메인 카메라의 뷰포트를 가져와서 처리 (스크린좌표 : 왼쪽하단부터 x, y 좌표값 0.0 ~ Max) (뷰포트좌표 : 왼쪽하단부터 x, y 좌표값 0.0 ~ 1.0)

        // 화면 위로 이동
        transform.position += transform.up * speed * Time.deltaTime;

        // 화면 바깥으로 벗어났을 시 제거
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y > 1.0f)
        {
            Destroy(this.gameObject);
        }
        else if (pos.x < 0.0f || pos.x > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
