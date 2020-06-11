using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHit : MonoBehaviour
{
    // 이펙트 오브젝트를 저장할 변수
    public GameObject fxObject;
    // 사운드 정보를 담을 변수
    private AudioSource audio;
    public AudioClip[] audioClip;

    // Start is called before the first frame update
    void Start()
    {
        // 오디오 소스 컴포넌트 캐스팅
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        // 사운드 재생
        audio.clip = audioClip[0];
        audio.Play();

        // 적 본체와 충돌했을 경우
        if (coll.gameObject.tag == "ENEMY")
        {
            // 폭발 이펙트 출력
            ShowEffect();
            // 플레이어 오브젝트만 제거
            Destroy(gameObject);
        }
        // 적 총알과 충돌했을 경우
        else if (coll.gameObject.layer == LayerMask.NameToLayer("ENEMY_BULLET"))
        {
            // 폭발 이펙트 출력
            ShowEffect();
            // 플레이어 오브젝트와 충돌한 적 총알 전부 제거
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

    // 폭발 이펙트 출력 함수
    void ShowEffect()
    {
        GameObject fx = Instantiate(fxObject);
        fx.transform.position = transform.position;
    }
}
