using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirePrimary : MonoBehaviour
{
    // 플레이어 정보를 저장할 변수
    private PlayerInfo playerInfo;
    // 총알 오브젝트를 담을 변수
    public GameObject bulletObject;
    // 총알 부모 오브젝트를 담을 변수
    public GameObject bulletParent;
    // 총알 발사 위치를 담을 변수
    public GameObject[] firePoint;
    // 사운드 정보를 담을 변수
    private AudioSource audio;
    public AudioClip[] audioClip;

    // 플레이어 메인 샷 발사 딜레이
    private float primaryDelay = 0.05f;
    // 플레이어 메인 샷 발사 딜레이 누적값
    private float primaryTimer = 0.04f;

    // 오브젝트 풀링
    // 풀 최초 사이즈 설정
    int poolSize = 100;
    // int fireIndex = 0;
    // 1. 배열
    // GameObject[] bulletPool;
    // 2. 리스트
    // public List<GameObject> bulletPool;
    // 3. 큐
    public Queue<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 오브젝트 찾기
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();

        // 오디오 소스 컴포넌트 캐스팅
        audio = GetComponent<AudioSource>();

        // 오브젝트 풀링 초기화
        InitObjectPooling();
    }

    // 오브젝트 풀링 초기화 함수
    void InitObjectPooling()
    {
        // 1. 배열
        // bulletPool = new GameObject[poolSize];
        // for (int i = 0; i < poolSize; i++)
        // {
        //     // 총알 게임오브젝트 생성
        //     GameObject bullet = Instantiate(bulletObject);
        //     // 총알 오브젝트의 위치 지정
        //     // bullet.transform.position = transform.position;
        //     bullet.transform.position = firePoint.transform.position;
        // }

        // 2. 리스트
        // bulletPool = new List<GameObject>();
        // for (int i = 0; i < poolSize; i++)
        // {
        //     GameObject bullet = Instantiate(bulletObject);
        //     bullet.SetActive(false);
        //     bulletPool.Add(bullet);
        // }

        // 3. 큐
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletObject);
            bullet.SetActive(false);
            bullet.transform.SetParent(bulletParent.transform);
            bulletPool.Enqueue(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfo.playerState == PlayerInfo.PlayerState.PLAYER_ALIVE)
        {
            // 메인 샷 발사
            PrimaryShot();
        }
    }

    // 메인 샷 발사 함수
    public void PrimaryShot()
    {
        // Z 키를 누르고 있을 경우
        if (Input.GetKey(KeyCode.Z))
        {
            // 플레이어 메인 샷 발사 딜레이 누적값 증가
            primaryTimer += Time.deltaTime;
            // 누적값이 발사 딜레이 기준점을 넘어섰을 경우
            if (primaryTimer > primaryDelay)
            {
                // 사운드 재생
                audio.clip = audioClip[0];
                audio.Play();

                // 1. 배열 오브젝트 풀링으로 총알 발사
                // bulletPool[fireIndex].SetActive(true);
                // bulletPool[fireIndex].transform.position = firePoint.transform.position;
                // bulletPool[fireIndex].transform.up = firePoint.transform.up;
                // fireIndex++;
                // if (fireIndex > poolSize)
                // {
                //     fireIndex = 0;
                // }

                // 2. 리스트 오브젝트 풀링으로 총알 발사
                // bulletPool에 여분의 총알이 남아있는 경우
                // if (bulletPool.Count > 0)
                // {
                //     GameObject bullet = bulletPool[0];
                //     bullet.SetActive(true);
                //     bullet.transform.position = firePoint.transform.position;
                //     bullet.transform.up = firePoint.transform.up;
                //     // 오브젝트 풀에서 제거
                //     bulletPool.Remove(bullet);
                // }
                // // bulletPool에 여분의 총알이 하나도 없을 경우
                // else
                // {
                //     GameObject bullet = Instantiate(bulletObject);
                //     bullet.SetActive(false);
                //     // 오브젝트 풀에 추가
                //     bulletPool.Add(bullet);
                //     poolSize++;
                // }

                // 3. 큐 오브젝트 풀링으로 총알 발사
                if (bulletPool.Count > 0)
                {
                    if (gameObject.GetComponent<PlayerInfo>().playerPower == 1.0f)
                    {
                        GameObject bullet = bulletPool.Dequeue();
                        bullet.SetActive(true);
                        bullet.transform.position = firePoint[0].transform.position;
                        bullet.transform.up = firePoint[0].transform.up;
                    }
                    else if (gameObject.GetComponent<PlayerInfo>().playerPower == 2.0f)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject bullet = bulletPool.Dequeue();
                            bullet.SetActive(true);
                            bullet.transform.position = firePoint[i].transform.position;
                            bullet.transform.up = firePoint[i].transform.up;
                        }
                    }
                    else if (gameObject.GetComponent<PlayerInfo>().playerPower == 3.0f)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            GameObject bullet = bulletPool.Dequeue();
                            bullet.SetActive(true);
                            bullet.transform.position = firePoint[i].transform.position;
                            bullet.transform.up = firePoint[i].transform.up;
                        }
                    }
                }
                else
                {
                    GameObject bullet = Instantiate(bulletObject);
                    bullet.SetActive(false);
                    bullet.transform.SetParent(bulletParent.transform);
                    bulletPool.Enqueue(bullet);
                }

                // 플레이어 메인 샷 발사 딜레이 누적값 초기화
                primaryTimer = 0.0f;
            }
        }
        // Z 키를 누르고 있다가 뗐을 경우
        if (Input.GetKeyUp(KeyCode.Z))
        {
            // 플레이어 메인 샷 발사 딜레이 누적값 재설정
            primaryTimer = 0.04f;
        }
    }
}