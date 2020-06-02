using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondary : MonoBehaviour
{
    public GameObject secondary;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (secondary.activeSelf == false)
            {
                secondary.SetActive(true);
            }
            else
            {
                secondary.SetActive(false);
            }
        }
    }
}
