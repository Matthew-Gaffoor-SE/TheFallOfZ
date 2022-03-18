using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFaller : MonoBehaviour
{
    public float FallTime;
    public float FallTimer;
    public GameObject[] tileObj;

    void Start()
    {

    }

    void Update()
    {
        if (Game.GameIsRunning == false)
            return;

        FallTimer -= Time.deltaTime;

        if (FallTimer <= 0)
        {
            FallTimer = FallTime;

            // random falling tile - https://forum.unity.com/threads/getting-a-random-object.313705/

            Transform[] tileObj = (Transform[])gameObject.GetComponentsInChildren<Transform>();
            GameObject randomTile = (GameObject)((Transform)tileObj[Random.Range(0, tileObj.Length)]).gameObject;
            Rigidbody rb = randomTile.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
