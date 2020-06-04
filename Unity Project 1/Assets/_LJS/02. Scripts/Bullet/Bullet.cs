using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 탄 속도 설정 (기본값)
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // 탄 이동
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
    }

    // 카메라 화면 밖으로 나가서 보이지 않게 되면 호출되는 이벤트 함수
    // private void OnBecameInvisible()
    // {
    //     Destroy(gameObject);
    // }
}
