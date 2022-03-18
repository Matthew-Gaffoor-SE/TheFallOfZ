using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // rotating camera with mouse - https://www.youtube.com/watch?v=lYIRm4QEqro&ab_channel=LearnEverythingFast
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float MovementSpeed;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -20f, 20f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
