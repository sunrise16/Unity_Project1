using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoad : MonoBehaviour
{
    // CanvasGroup 컴포넌트를 저장할 변수
    public CanvasGroup fadeCG;
    // 화면 전환 처리 변수
    private bool changeImage = false;
    // Fade In 처리 시간
    [Range(1.0f, 2.0f)]
    public float fadeDuration = 1.0f;

    // Start 함수 호출
    void Start()
    {
        // 처음 알파값을 설정 (불투명)
        fadeCG.alpha = 1.0f;

        StartCoroutine(FadeOut());
    }

    // Fade Out 함수
    IEnumerator FadeOut()
    {
        // 절대값 함수로 백분율 계산
        float fadeSpeed = Mathf.Abs(fadeCG.alpha - 0.0f) / fadeDuration;

        // 알파값 조정
        while (!Mathf.Approximately(fadeCG.alpha, 0.0f))
        {
            fadeCG.alpha = Mathf.MoveTowards(fadeCG.alpha, 0.0f, fadeSpeed * Time.deltaTime);

            yield return null;
        }

        // Fade Out이 완료된 후 Fade In으로 넘어감
        changeImage = true;
        StartCoroutine(FadeIn());
    }

    // Fade In 함수
    IEnumerator FadeIn()
    {
        // 절대값 함수로 백분율 계산
        float fadeSpeed = Mathf.Abs(fadeCG.alpha - 1.0f) / fadeDuration;

        // 알파값 조정
        while (!Mathf.Approximately(fadeCG.alpha, 1.0f))
        {
            fadeCG.alpha = Mathf.MoveTowards(fadeCG.alpha, 1.0f, fadeSpeed * Time.deltaTime);

            yield return null;
        }

        // Fade In이 완료된 후 씬 전환
        SceneMgr.instance.LoadScene("TitleLoad");
    }
}
