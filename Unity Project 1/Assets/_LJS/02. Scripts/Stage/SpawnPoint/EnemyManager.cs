using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 목표물 오브젝트를 담을 변수
    private GameObject target;
    // 적 오브젝트를 담을 변수
    public GameObject enemyObject;
    // 적 부모 오브젝트를 담을 변수
    public GameObject enemyParent;
    // 적이 스폰될 위치
    public GameObject[] spawnPoints;
    // 적 스폰 기준 타임
    private float spawnTime = 1.0f;
    // 적 스폰 누적 타임
    private float curTime = 0.0f;

    // 오브젝트 풀링
    // 풀 최초 사이즈 설정
    int poolSize = 15;
    // 적 오브젝트를 담을 풀
    public Queue<GameObject> enemyPool;

    void Start()
    {
        // 타겟 오브젝트 찾기
        target = GameObject.Find("Player");

        // 오브젝트 풀링 초기화
        InitObjectPooling();
    }

    // 오브젝트 풀링 초기화 함수
    void InitObjectPooling()
    {
        enemyPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyObject);
            enemy.SetActive(false);
            enemy.transform.SetParent(enemyParent.transform);
            enemyPool.Enqueue(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 적 생성
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (target != null)
        {
            // 몇초에 한번씩 이벤트 발동
            curTime += Time.deltaTime;
            if (curTime > spawnTime)
            {
                // 누적된 스폰 시간을 0초로 초기화 (반드시 해줘야 함)
                curTime = 0.0f;
                // 스폰 타임을 랜덤으로 설정
                spawnTime = Random.Range(0.5f, 2.0f);

                // 3. 큐 오브젝트 풀링으로 총알 발사
                if (enemyPool.Count > 0)
                {
                    GameObject enemy = enemyPool.Dequeue();
                    enemy.SetActive(true);
                    // 적 스폰 위치 랜덤 설정
                    int index = Random.Range(0, spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].transform.position;
                }
                else
                {
                    GameObject enemy = Instantiate(enemyObject);
                    enemy.SetActive(false);
                    enemy.transform.SetParent(enemyParent.transform);
                    enemyPool.Enqueue(enemy);
                }
            }
        }
    }
}