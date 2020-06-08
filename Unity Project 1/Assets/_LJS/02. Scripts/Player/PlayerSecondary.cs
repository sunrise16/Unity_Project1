using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondary : MonoBehaviour
{
    public GameObject secondary;
    public GameObject bulletObject;
    public float fireTime = 1.0f;
    float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateClone();
        AutoFire();
    }

    private void CreateClone()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            secondary.SetActive(true);
        }
    }

    // 총알 자동 발사 함수
    private void AutoFire()
    {
        // 보조무기가 액티브 상태일 때 총알 자동 발사 처리
        if(secondary.activeSelf == true)
        {
            // 총알 발사 간격 시간 누적
            currentTime += Time.deltaTime;
            if(currentTime > fireTime)
            {
                //당연히 curTime 0으로 초기화
                currentTime = 0.0f;

                //GameObject bullet1 = Instantiate(bulletFactory);
                //bullet1.transform.position = GameObject.Find("Sub1").transform.position;
                //bullet1.transform.position = clone.transform.Find("Sub1").position;
                //bullet1.transform.position = clone.transform.GetChild(0).position;

                //GameObject[] bullet = new GameObject[2];
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
