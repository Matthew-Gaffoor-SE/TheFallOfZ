using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float power;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            Vector3 direction = (transform.forward);
            direction.y = 0;
            other.GetComponent<Rigidbody>().AddForce(direction * power);
        }
    }
}
