using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreMgr : MonoBehaviour
{
    // 스코어 매니저 싱글톤 만들기
    public static ScoreMgr instance;
    private void Awake() => instance = this;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;
    public TextMeshProUGUI deadCountTxt;
    // public TextMeshProUGUI textTxt;

    int score = 0;
    int highScore = 0;
    int deadCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 하이 스코어 불러오기
        highScore = PlayerPrefs.GetInt("HIGH SCORE");
        highScoreTxt.text = "" + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        // 하이 스코어 저장
        SaveHighScore();
    }

    private void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGH SCORE", highScore);
            highScoreTxt.text = "" + highScore;
        }
    }

    // 점수 추가 및 텍스트 업데이트
    public void AddScore(int value)
    {
        score += value;
        scoreTxt.text = "" + score;
    }

    // 죽은 횟수 추가 및 텍스트 업데이트
    public void AddDeadCount()
    {
        deadCount++;
        deadCountTxt.text = "" + deadCount;
    }
}