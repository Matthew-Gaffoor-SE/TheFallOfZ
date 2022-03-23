using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{

    public float MovementSpeed;
    public Transform Player;

    void Update()
    {
        transform.LookAt(Player);
        Vector3 dirToPlayer = (Player.position - transform.position).normalized;

        transform.position += dirToPlayer * MovementSpeed * Time.deltaTime;
    }
}
