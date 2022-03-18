using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutboundsScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }
}
