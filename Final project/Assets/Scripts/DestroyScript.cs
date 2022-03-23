using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    public GameObject SpawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Game.GameIsRunning == true)
        {
            SpawnPoint.SetActive(false);
        }
    }
}
