using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBow : MonoBehaviour
{
    public Transform EquipPosition;
    public float Distance = 10f;
    public GameObject Bow;
    public GameObject PickupCanvas;
    GameObject CurrentWeapon;
    GameObject wp;
    bool canGrab;

    private void Update()
    {
        CheckWeapons();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
    }

    void CheckWeapons()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Distance))
        {
            if (hit.transform.tag == "Bow")
            {
                PickupCanvas.SetActive(true);
                canGrab = true;
                wp = hit.transform.gameObject;
            }
            else
            {
                canGrab = false;
            }
        }
        else
        {
            PickupCanvas.SetActive(false);
        }
    }

    void PickUp()
    {
        Bow.SetActive(true);
        CurrentWeapon = wp;
        Destroy(CurrentWeapon);
        FireScript FS = Bow.GetComponent<FireScript>();
        
        FS.IsEquip = true;

    }
}
