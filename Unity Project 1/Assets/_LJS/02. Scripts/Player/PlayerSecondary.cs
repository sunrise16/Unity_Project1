using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondary : MonoBehaviour
{
    // 보조무기 오브젝트를 담을 변수
    public GameObject secondary;
    // 총알 오브젝트를 담을 변수
    public GameObject bulletObject;
    // 총알 발사 간격
    public float fireTime = 1.0f;
    // 총알 발사 간격 딜레이 누적값
    float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // 보조무기 활성화
        ActiveSecondary();
        // 보조무기 총알 자동 발사
        AutoFire();
    }

    // 보조무기 활성화 함수
    private void ActiveSecondary()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            secondary.SetActive(true);
        }
    }

    // 보조무기 총알 자동 발사 함수
    private void AutoFire()
    {
        // 보조무기가 액티브 상태일 때 총알 자동 발사 처리
        if(secondary.activeSelf == true)
        {
            // 총알 발사 간격 시간 누적
            currentTime += Time.deltaTime;
            if(currentTime > fireTime)
            {
                // 자동 발사 간격 누적값 초기화
                currentTime = 0.0f;

                // GameObject bullet1 = Instantiate(bulletFactory);
                // bullet1.transform.position = GameObject.Find("Sub1").transform.position;
                // bullet1.transform.position = clone.transform.Find("Sub1").position;
                // bullet1.transform.position = clone.transform.GetChild(0).position;

                // GameObject[] bullet = new GameObject[2];
                GameObject[] bullet = new GameObject[secondary.transform.childCount];
                for(int i = 0; i < secondary.transform.childCount; i++)
                {
                    bullet[i] = Instantiate(bulletObject);
                    bullet[i].transform.position = secondary.transform.GetChild(i).position;
                }
            }
        }
    }
}
