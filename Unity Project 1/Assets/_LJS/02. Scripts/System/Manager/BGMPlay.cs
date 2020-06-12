using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    private bool loop = false;

    // Update is called once per frame
    void Update()
    {
        PlayingBGM();
    }

    void PlayingBGM()
    {
        switch (StageMgr.instance.currentStage)
        {
            case 0:
                if (BGMMgr.instance.IsPlaying() == false)
                {
                    BGMMgr.instance.PlayBGM("Title");
                }
                break;
            case 1:
                if (loop == false && BGMMgr.instance.IsPlaying() == false)
                {
                    BGMMgr.instance.PlayBGM("Stage1_Entry");
                    loop = true;
                }
                else if (loop == true && BGMMgr.instance.IsPlaying() == false)
                {
                    BGMMgr.instance.PlayBGM("Stage1_Loop");
                }
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
