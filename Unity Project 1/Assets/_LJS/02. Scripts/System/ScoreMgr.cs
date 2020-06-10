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

    public Text scoreTxt;               // 일반 UI 텍스트
    public Text highScoreTxt;           // 일반 UI 텍스트
    public TextMeshProUGUI textTxt;     // 텍스트메시프로 텍스트

    int score = 0;
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 하이 스코어 불러오기
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text = "HighScore : " + highScore;
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
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreTxt.text = "HighScore" + highScore;
        }
    }

    // 점수 추가 및 텍스트 업데이트
    public void AddScore()
    {
        score++;
        scoreTxt.text = "Score : " + score;

        textTxt.text = "test : " + score;
    }
}