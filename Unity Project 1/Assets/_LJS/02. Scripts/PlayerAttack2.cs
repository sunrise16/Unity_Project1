using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    [SerializeField] private GameObject PlayerBullet;
    private float createTime = 0.05f;
    private float currentCreateTime = 0.04f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            currentCreateTime += Time.deltaTime;
            if (currentCreateTime > createTime)
            {
                Instantiate(PlayerBullet, transform.position, Quaternion.LookRotation(transform.forward));
                currentCreateTime = 0.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentCreateTime = 0.04f;
        }
    }
}
