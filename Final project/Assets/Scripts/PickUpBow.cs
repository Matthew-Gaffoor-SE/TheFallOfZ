using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBow : MonoBehaviour
{
    public Transform EquipPosition;
    public float Distance = 10f;
    public GameObject Bow;
    GameObject CurrentWeapon;
    GameObject wp;
    public GameObject PickupCanvas;

    private FireScript _FS;
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
        CurrentWeapon = wp;
        Destroy(CurrentWeapon);
        Bow.transform.position = EquipPosition.position;
        Bow.transform.parent = EquipPosition;
        _FS = GameObject.Find("arc_copie(2)").GetComponent<FireScript>();
        _FS.IsEquip = true;
    }
}
