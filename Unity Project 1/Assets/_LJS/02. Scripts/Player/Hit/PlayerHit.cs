using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHit : MonoBehaviour
{
    // 플레이어 오브젝트를 저장할 변수
    private Transform player;
    private GameObject playerBody;
    // 플레이어 정보를 저장할 변수
    private PlayerInfo playerInfo;
    // 이펙트 오브젝트를 저장할 변수
    public GameObject fxObject;
    // 사운드 정보를 담을 변수
    private AudioSource audio;
    public AudioClip[] audioClip;

    // 격추 시 지연 시간을 담을 변수
    private float delayTime = 1.0f;
    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 오브젝트 찾기
        player = GameObject.Find("Player").transform;
        playerBody = GameObject.Find("PlayerBody");
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();

        // 오디오 소스 컴포넌트 캐스팅
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerDead();
    }

    void PlayerDead()
    {
        if (playerInfo.playerState == PlayerInfo.PlayerState.PLAYER_DEAD)
        {
            currentTime += Time.deltaTime;

            if (currentTime > delayTime)
            {
                player.position = new Vector3(0, -3, -0.1f);
                playerInfo.playerDeadCount++;
                playerInfo.playerState = PlayerInfo.PlayerState.PLAYER_ALIVE;
                playerInfo.isInvincible = true;
                playerBody.SetActive(true);
                ScoreMgr.instance.AddDeadCount();
                currentTime = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (playerInfo.playerState == PlayerInfo.PlayerState.PLAYER_ALIVE && playerInfo.isInvincible == false)
        {
            // 사운드 재생
            audio.clip = audioClip[0];
            audio.Play();

            // 적 본체와 충돌했을 경우
            if (coll.gameObject.tag == "ENEMY")
            {
                // 폭발 이펙트 출력
                ShowEffect();
                // 플레이어 오브젝트 재설정
                playerBody.SetActive(false);
                playerInfo.playerState = PlayerInfo.PlayerState.PLAYER_DEAD;
            }
            // 적 총알과 충돌했을 경우
            else if (coll.gameObject.layer == LayerMask.NameToLayer("ENEMY_BULLET"))
            {
                // 폭발 이펙트 출력
                ShowEffect();
                // 플레이어 오브젝트 재설정
                playerBody.SetActive(false);
                playerInfo.playerState = PlayerInfo.PlayerState.PLAYER_DEAD;
                // 적 총알 비활성화
                coll.gameObject.SetActive(false);
                GameObject.Find("BulletManager").GetComponent<BulletMgr>().bulletPool.Enqueue(coll.gameObject);
            }
        }
    }

    // 폭발 이펙트 출력 함수
    void ShowEffect()
    {
        GameObject fx = Instantiate(fxObject);
        fx.transform.position = transform.position;
    }
}
