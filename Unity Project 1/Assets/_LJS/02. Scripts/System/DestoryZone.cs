﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryZone : MonoBehaviour
{
    // 트리거 감지 후 해당 오브젝트 삭제
    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 감지된 오브젝트 제거
        Destroy(other.gameObject);
    }
}