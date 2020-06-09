using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreMgr : MonoBehaviour
{
    // 스코어 매니저 싱글톤 제작
    public static ScoreMgr instance;
    private void Awake() => instance = this;

    public Text scoreTxt;
    public Text highScoreTxt;
    public TextMeshProUGUI textTxt;


    int score = 0;
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 하이 스코어 불러오기
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text = "HIGH SCORE : " + highScore;
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
            highScoreTxt.text = "HIGH SCORE : " + highScore;
        }
    }

    // 점수 추가 및 텍스트 업데이트
    public void AddScore()
    {
        score++;
        scoreTxt.text = "SCORE : " + score;

        textTxt.text = "TEST...";
    }
}