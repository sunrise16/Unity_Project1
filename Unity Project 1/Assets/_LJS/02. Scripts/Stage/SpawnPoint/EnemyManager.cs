using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 적 생성 포인트 Prefab
    public GameObject enemyFactory;
    // 적이 스폰될 위치
    public GameObject[] spawnPoints;
    // 적 스폰 기준 타임
    private float spawnTime = 1.0f;
    // 적 스폰 누적 타임
    private float curTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // 적 생성
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // 몇초에 한번씩 이벤트 발동
        curTime += Time.deltaTime;
        if(curTime > spawnTime)
        {
            // 누적된 스폰 시간을 0초로 초기화 (반드시 해줘야 함)
            curTime = 0.0f;
            // 스폰 타임을 랜덤으로 설정
            spawnTime = Random.Range(0.5f, 2.0f);
            // 적 생성 (Instantiate 사용)
            GameObject enemy = Instantiate(enemyFactory);
            // enemy.transform.position = spawnPoint.transform.position;
            // 적 스폰 위치 랜덤 설정
            int index = Random.Range(0, spawnPoints.Length);
            enemy.transform.position = spawnPoints[index].transform.position;
            // enemy.transform.position = transform.GetChild(index).position;
        }
    }
}