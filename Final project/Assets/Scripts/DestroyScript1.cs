using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript1 : MonoBehaviour
{

    void Update()
    {
        if (Game.GameIsRunning == true)
        {
            Destroy(gameObject);
        }
    }
}
