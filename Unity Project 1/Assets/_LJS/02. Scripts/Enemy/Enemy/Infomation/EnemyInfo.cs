using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    // 적 기체의 현재 생존 상태
    public enum EnemyState { ENEMY_ALIVE, ENEMY_DEAD }

    // 적의 체력
    public float enemyInitHP;
    public float enemyCurrentHP;
    // 적의 현재 상태
    public EnemyState enemyState;

    void Start()
    {
        enemyCurrentHP = enemyInitHP;
        enemyState = EnemyState.ENEMY_ALIVE;
    }
}
