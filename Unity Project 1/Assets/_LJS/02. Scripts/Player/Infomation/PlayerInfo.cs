using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // 플레이어 체력
    private float initHp = 100.0f;
    public float currentHp;
    // 플레이어 파워
    public float playerPower = 1.0f;
    // 플레이어 잔기
    public float playerExtend = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = initHp;
    }
}
