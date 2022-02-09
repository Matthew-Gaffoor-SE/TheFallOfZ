using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate3 : MonoBehaviour
{
    public float countdownTimer;
    public float openTimer;
    public float waitTimer;
    public float setWaitTimer;
    public float movementSpeed;
    public bool isGateOpen;

    void Update()
    {
        openTimer -= Time.deltaTime;

        if (openTimer <= 0)
        {
            openTimer = countdownTimer;
            transform.position = new Vector3(-90.15f, 26f, -1.97f);
            isGateOpen = true;
        }

        if (isGateOpen == true)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                waitTimer = setWaitTimer;
                transform.position = new Vector3(-90.15f, 10.4f, -1.97f);
                isGateOpen = false;
            }
        }
    }
}
