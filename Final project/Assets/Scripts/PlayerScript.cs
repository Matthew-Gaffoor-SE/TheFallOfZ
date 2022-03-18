using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // rotating camera with mouse - https://www.youtube.com/watch?v=lYIRm4QEqro&ab_channel=LearnEverythingFast

    public float MovementSpeed;
    public float speedH = 2.0f;
    private float yaw = 0.0f;

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Camera.main.transform.forward * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Camera.main.transform.forward * MovementSpeed * 2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Camera.main.transform.forward * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Camera.main.transform.right * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Camera.main.transform.right * MovementSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Game.GameIsRunning = true;
    }
}
