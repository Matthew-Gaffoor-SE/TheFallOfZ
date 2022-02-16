using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public GameObject ZombieMesh;
    public float SpawnTime;
    public float SpawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", SpawnTime, SpawnDelay);  
    }

    void Update()
    {
        if (Game.GameIsRunning == false)
            return;

        SpawnTime -= Time.deltaTime;

        if (SpawnTime <= 0)
        {
            SpawnTime = SpawnDelay;

            Instantiate(ZombieMesh, transform.position, transform.rotation);
        }
    }
}
