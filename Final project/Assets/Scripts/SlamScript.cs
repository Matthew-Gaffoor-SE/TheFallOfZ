using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamScript : MonoBehaviour
{
    public float Strength;

    public Animator animator;

    public bool IsEquip;

    void Start()
    {
        animator = GetComponent<Animator>();
        IsEquip = false;
    }

    void Update()
    {

        if (Game.GameIsRunning == true)
        {
            if (IsEquip == false)
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Slammer");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            direction.y = 0;
            other.GetComponent<Rigidbody>().AddForce(direction * Strength);
        }
    }
}
