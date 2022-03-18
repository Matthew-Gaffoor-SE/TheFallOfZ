using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float power;

    public Animator animator;

    public bool IsEquip;

    public AudioClip shoot;

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
            animator.SetTrigger("Fire");
            AudioSource.PlayClipAtPoint(shoot, transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            Vector3 direction = transform.position - other.transform.position.normalized;
            direction.y = 0;
            other.GetComponent<Rigidbody>().AddForce(direction * power);
        }
    }
}
