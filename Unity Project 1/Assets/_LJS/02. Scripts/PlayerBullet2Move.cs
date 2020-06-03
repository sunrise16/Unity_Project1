using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2Move : MonoBehaviour
{
    public float speed;
    public float damage;
    public GameObject target;
    public GameObject[] enemy;
    private bool isFind = false;
    private float findDist = 15.0f;
    private Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        // 거리 내의 적 인식
        if (isFind == false)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                float dist = Vector3.Distance(transform.position, enemy[i].transform.position);
                if (dist <= findDist)
                {
                    target = enemy[i];
                    dir = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0);
                    isFind = true;
                    break;
                }
            }
        }

        // 화면 바깥으로 벗어나지 않게 하는 3가지 방법
        // 1) 화면 바깥의 공간에 큐브 4개를 만들어 배치한 후, 리지드바디의 충돌체로 이동하지 못하게 막기
        // 2) 플레이어의 포지션으로 이동 처리
        // 3) 메인 카메라의 뷰포트를 가져와서 처리 (스크린좌표 : 왼쪽하단부터 x, y 좌표값 0.0 ~ Max) (뷰포트좌표 : 왼쪽하단부터 x, y 좌표값 0.0 ~ 1.0)

        // 화면 위로 이동
        if (isFind == false)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        // 타겟을 향해 유도
        else
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }

        // 속도 증감
        if (isFind == false)
        {
            speed += 0.1f;
            if (speed >= 10.0f)
            {
                speed = 10.0f;
            }
        }
        else
        {
            speed -= 0.1f;
            if (speed <= 5.0f)
            {
                speed = 5.0f;
            }
        }

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
