using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            BGMMgr.instance.PlayBGM("BGM1");
        }
        if (Input.GetKeyDown("2"))
        {
            BGMMgr.instance.PlayBGM("BGM2");
        }
        if (Input.GetKeyDown("3"))
        {
            BGMMgr.instance.CrossFadeBGM("BGM1", 1.5f);
        }
        if (Input.GetKeyDown("4"))
        {
            BGMMgr.instance.CrossFadeBGM("BGM2", 1.5f);
        }
    }
}
