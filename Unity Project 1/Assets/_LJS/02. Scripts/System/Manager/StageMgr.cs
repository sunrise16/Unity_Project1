using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : MonoBehaviour
{
    // SceneManager는 시작, 게임, 종료 씬 모두를 관리해야 하며, 씬이 변경되도 삭제되지 않아야 함
    // SceneManager 싱글톤 만들기
    public static StageMgr instance;
    public int currentStage = 1;

    private void Awake()
    {
        // SceneManager가 존재한다면 새로 생성되는 SceneManager는 삭제하고 바로 빠져나오게 함
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        // instance가 NULL일 때
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CurrentStage(int value)
    {
        currentStage = value;
    }
}