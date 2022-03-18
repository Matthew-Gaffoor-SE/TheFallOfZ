using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Transform ArrowSpawn;
    public float ArrowSpeed;
    public float lifeTime;

    void Start()
    {
        
    }
    // Firing Arrows - https://www.youtube.com/watch?v=1UekWA1osNw&t=299s&ab_channel=Omnirift

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject Arrow = Instantiate(ArrowPrefab);

        Physics.IgnoreCollision(Arrow.GetComponent<Collider>(),
            ArrowSpawn.parent.GetComponent<Collider>());

        Arrow.transform.position = ArrowSpawn.position;

        Vector3 rotation = Arrow.transform.rotation.eulerAngles;

        Arrow.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        Arrow.GetComponent<Rigidbody>().AddForce(ArrowSpawn.forward * ArrowSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyArrowAfterTime(Arrow, lifeTime));
    }

    public IEnumerator DestroyArrowAfterTime(GameObject Arrow, float Delay)
    {
        yield return new WaitForSeconds(Delay);
        Destroy(Arrow);
    }
}
