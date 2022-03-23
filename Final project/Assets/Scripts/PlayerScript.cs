using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // rotating camera with mouse - https://www.youtube.com/watch?v=lYIRm4QEqro&ab_channel=LearnEverythingFast

    public float MovementSpeed;
    public float speedH = 2.0f;
    private float yaw = 0.0f;

    public GameObject PauseUI;
    public bool Paused;

    public GameObject Ms;
    public CameraScript Cs;

    void Start()
    {
        Cursor.visible = false;
        Cs.GetComponent<CameraScript>();
        Time.timeScale = 1;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
            PauseUI.SetActive(Paused);
            Time.timeScale = Paused ? 0 : 1;
            Cs = Ms.GetComponent<CameraScript>();
            Cs.enabled = !Cs.enabled;
        }
        if (Paused)
        {
            return;
        }

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
