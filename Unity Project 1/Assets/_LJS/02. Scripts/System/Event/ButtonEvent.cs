using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    private GameObject button;

    void Start()
    {
        button = GameObject.Find("ButtonObject");
    }

    public void OnStartButtonClick()
    {
        button.SetActive(false);
        SceneMgr.instance.LoadScene("Stage1");
        StageMgr.instance.currentStage++;
    }
}

