using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public float countdownTimer;
    public float openTimer;
    public float waitTimer;
    public float setWaitTimer;
    public float movementSpeed;
    public bool isGateOpen;
    public Vector3 TargetPosition;

    void Start()
    {
        TargetPosition = transform.position;
    }

    void Update()
    {
        if (Game.GameIsRunning == false)
            return;

        openTimer -= Time.deltaTime;

        if (openTimer <= 0)
        {
            openTimer = countdownTimer;
            TargetPosition.y += 16;
            isGateOpen = true;
        }

        if (isGateOpen == true)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                waitTimer = setWaitTimer;
                TargetPosition.y -= 16;
                isGateOpen = false;
            }
        }

        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * movementSpeed);
    }
}
