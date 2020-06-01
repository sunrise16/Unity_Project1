using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어 이동
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // 저속 이동
        if (Input.GetKey(KeyCode.LeftShift)) { speed = 2.0f; }
        else { speed = 5.0f; }

        // 이동 함수
        Move();

        // 화면 밖으로 벗어나지 못하게 하기
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.05f) { pos.x = 0.05f; }
        if (pos.x > 0.95f) { pos.x = 0.95f; }
        if (pos.y < 0.025f) { pos.y = 0.025f; }
        if (pos.y > 0.975f) { pos.y = 0.975f; }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);

        // 이동 공식
        // 1)
        // transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
        // 2)
        // Vector3 dir = Vector3.right * h + Vector3.up * v;
        // 3)
        transform.Translate(dir * speed * Time.deltaTime);
        // 4)
        // transform.position += (dir * speed * Time.deltaTime);
    }
}
