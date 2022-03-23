using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallScript : MonoBehaviour
{
    public AudioSource falling;

    private void Start()
    {
        falling = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            falling.Play();
        }
    }
}
