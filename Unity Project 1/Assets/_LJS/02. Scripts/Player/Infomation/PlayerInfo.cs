using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // 플레이어의 현재 생존 상태
    public enum PlayerState { PLAYER_ALIVE, PLAYER_DEAD }
    // 플레이어 바디 오브젝트를 담을 변수
    private GameObject playerBody;
    
    // 플레이어 체력
    private float initHp = 100.0f;
    public float currentHp;
    // 플레이어 파워
    public float playerPower = 1.0f;
    // 플레이어 총 격추된 횟수
    public int playerDeadCount = 0;
    // 플레이어의 현재 상태
    public PlayerState playerState;
    // 플레이어 무적 상태를 담을 변수
    public bool isInvincible = false;
    // 플레이어 무적 지속 시간을 담을 변수
    private float delayTime = 2.5f;
    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.Find("PlayerBody");

        currentHp = initHp;
        playerState = PlayerState.PLAYER_ALIVE;
    }

    void Update()
    {
        if (isInvincible == true)
        {
            PlayerInvincible();
        }
    }

    void PlayerInvincible()
    {
        currentTime += Time.deltaTime;

        if ((int)(currentTime * 10) % 2 == 0)
        {
            playerBody.SetActive(false);
        }
        else
        {
            playerBody.SetActive(true);
        }

        if (currentTime > delayTime)
        {
            currentTime = 0.0f;
            isInvincible = false;
        }
    }
}
