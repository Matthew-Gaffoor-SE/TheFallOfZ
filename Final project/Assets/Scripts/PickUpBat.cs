using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBat : MonoBehaviour
{
    public Transform EquipPosition;
    public float Distance = 10f;
    public GameObject Bat;
    GameObject CurrentWeapon;
    GameObject wp;

    private SwingScript _SS;
    bool canGrab;

    private void Update()
    {
        CheckWeapons();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (CurrentWeapon != null)
                    Drop();


                PickUp();
            }
        }

        if (CurrentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Drop();
            }
        }
    }

    void CheckWeapons()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Distance))
        {
            if (hit.transform.tag == "Bat")
            {
                canGrab = true;
                wp = hit.transform.gameObject;
            }
            else
            {
                canGrab = false;
            }
        }
    }

    void PickUp()
    {
        CurrentWeapon = wp;
        Destroy(CurrentWeapon);
        Bat.transform.position = EquipPosition.position;
        Bat.transform.parent = EquipPosition;
        _SS = GameObject.Find("pCylinder1").GetComponent<SwingScript>();
        _SS.IsEquip = true;
    }

    void Drop()
    {
        CurrentWeapon.transform.parent = null;
        CurrentWeapon = null;
    }
}
