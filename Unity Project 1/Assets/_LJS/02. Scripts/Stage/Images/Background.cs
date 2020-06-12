using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Material 오브젝트를 담을 변수
    private Material mat;
    // 배경 스크롤 속도 변수
    private float scrollSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        // 배경의 MeshRenderer 컴포넌트 안의 Material 오브젝트 추출
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // 배경 스크롤 처리
        BackgroundScrolling();
    }

    // 배경 스크롤을 처리하는 함수
    void BackgroundScrolling()
    {
        // Offset 값 설정
        Vector2 offset = mat.mainTextureOffset;
        offset.Set(0, offset.y + (scrollSpeed * Time.deltaTime));
        mat.mainTextureOffset = offset;

        if (offset.y >= 1.0f)
        {
            offset.Set(0, offset.y -1.0f);
            mat.mainTextureOffset = offset;
        }
    }
}
