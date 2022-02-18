using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutboundsScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }
}
