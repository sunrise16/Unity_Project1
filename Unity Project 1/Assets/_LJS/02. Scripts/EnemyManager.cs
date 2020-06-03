using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // EnemyManager의 역할 : 적들을 양산 (Enemy Prefab)
    public GameObject enemyFactory;
    // 적의 스폰 시간, 적의 스폰 위치값 필요
    private float spawnTime = 3.0f;
    private float currentTime = 0.0f;
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 적 생성
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        // 몇 초에 한번씩 이벤트 발생
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            // 적 생성
            GameObject enemy = Instantiate(enemyFactory);
            currentTime = 0.0f;
            int index = Random.Range(0, spawnPoints.Length);
            enemy.transform.position = transform.GetChild(index).position;

            // 스폰 시간 및 위치를 랜덤으로
            spawnTime = Random.Range(0.5f, 2.5f);
        }
    }
}
