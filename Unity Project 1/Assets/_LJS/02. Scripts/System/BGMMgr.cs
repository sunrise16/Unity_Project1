using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMgr : MonoBehaviour
{
    // 모든 씬에서 사용이 가능해야 하므로 BGMManager를 삭제하지 말아야 함
    // BGMManager 싱글톤 만들기
    public static BGMMgr instance;

    // Dictionary를 사용할 경우 변수명은 보통 **Table 식으로 많이 사용 (코딩 규약)
    Dictionary<string, AudioClip> bgmTable;
    // 메인 오디오
    AudioSource audioMain;
    // 서브 오디오
    AudioSource audioSub;

    [Range(0.0f, 1.0f)]         // 이런 형식을 Attribute라 함 (Inspector 창에서 값을 Range 범위 안으로 고정시킴)
    public float masterVolume = 1.0f;
    float volumeMain = 0.0f;
    float volumeSub = 0.0f;
    float crossFadeTime = 1.5f;

    void Awake()
    {
        // BGMManager가 존재한다면 새로 생성되는 BGMManager는 삭제하고 바로 빠져나오게 함
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        // instance가 NULL일 때
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // BGM 테이블 생성
        bgmTable = new Dictionary<string, AudioClip>();
        // 오디오 소스 코드 추가
        audioMain = gameObject.AddComponent<AudioSource>();
        audioSub = gameObject.AddComponent<AudioSource>();
        // 오디오 소스 볼륨 초기화
        audioMain.volume = 0.0f;
        audioSub.volume = 0.0f;
    }

    void Update()
    {
        // BGM이 플레이 중일 때 메인 볼륨을 올리고 서브 볼륨을 내리기
        if (audioMain.isPlaying)
        {
            // 메인 오디오 볼륨 올리기
            if (volumeMain < 1.0f)
            {
                volumeMain += Time.deltaTime / crossFadeTime;
                if (volumeMain >= 1.0f)
                {
                    volumeMain = 1.0f;
                }
            }
            // 서브 오디오 볼륨 내리기
            if (volumeSub > 0.0f)
            {
                volumeSub -= Time.deltaTime / crossFadeTime;
                if (volumeSub <= 0.0f)
                {
                    volumeSub = 0.0f;
                    // 서브 오디오 정지
                    audioSub.Stop();
                }
            }
        }

        // 볼륨 조정
        audioMain.volume = volumeMain * masterVolume;
        audioSub.volume = volumeSub * masterVolume;
    }
    public void PlayBGM(string bgmName)
    {
        // Dictionary 안에 BGM이 없을 경우
        if (!bgmTable.ContainsKey(bgmName))
        {
            // 유니티 엔진에서 특별한 기능을 수행하는 Resources 폴더가 존재 (어디에서든 파일을 로드할 수 있음)
            // BGM을 Resource 폴더에서 찾아 새로 추가 (가져올 파일이 어떤 종류인지 아직 모르므로 자료형을 명시해 주어야 함)
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            // AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;       // 예전 방식

            // Resources 폴더에 찾을 BGM 파일이 존재하지 않을 경우 리턴
            if (bgm == null) return;
            
            // Dictionary에 BGM 추가
            bgmTable.Add(bgmName, bgm);
        }

        // 메인 오디오의 클립에 새로운 오디오 클립을 연결
        audioMain.clip = bgmTable[bgmName];
        // 메인 오디오 재생
        audioMain.Play();
        // 오디오 볼륨값 세팅
        volumeMain = 1.0f;
        volumeSub = 0.0f;
    }

    // BGM 크로스페이드 플레이
    public void CrossFadeBGM(string bgmName, float cfTime = 1.0f)
    {
        // Dictionary 안에 BGM이 없을 경우
        if (!bgmTable.ContainsKey(bgmName))
        {
            // 유니티 엔진에서 특별한 기능을 수행하는 Resources 폴더가 존재 (어디에서든 파일을 로드할 수 있음)
            // BGM을 Resource 폴더에서 찾아 새로 추가 (가져올 파일이 어떤 종류인지 아직 모르므로 자료형을 명시해 주어야 함)
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            // AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;       // 예전 방식

            // Resources 폴더에 찾을 BGM 파일이 존재하지 않을 경우 리턴
            if (bgm == null) return;

            // Dictionary에 BGM 추가
            bgmTable.Add(bgmName, bgm);
        }

        // 크로스페이드 타임
        crossFadeTime = cfTime;

        // 메인 오디오와 서브 오디오 및 볼륨값 스왑
        AudioSource tempAudio = audioMain;
        audioMain = audioSub;
        audioSub = tempAudio;
        float tempVolume = volumeMain;
        volumeMain = volumeSub;
        volumeSub = tempVolume;

        // 메인 오디오의 클립에 새로운 오디오 클립 연결
        audioMain.clip = bgmTable[bgmName];
        // 메인 오디오 재생
        audioMain.Play();
    }

    // BGM 일시 정지
    public void PauseBGM()
    {
        audioMain.Pause();
    }

    // BGM 다시 재생
    public void ResumeBGM()
    {
        audioMain.Play();
    }
}
