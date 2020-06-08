using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    // 총알 이동 속도
    public float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // 카메라 화면 밖으로 나가서 보이지 않게 되면 호출되는 이벤트 함수
    // private void OnBecameInvisible()
    // {
    //     Destroy(gameObject);
    // }
}
