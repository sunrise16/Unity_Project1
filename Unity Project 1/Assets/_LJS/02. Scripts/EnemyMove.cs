using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 자기 자신도 없애고 충돌된 오브젝트도 없애기
        // Destroy 함수에서 2번째 인자는 제거하는 데에 소요되는 딜레이 시간을 뜻함 (몇 초 후)
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
