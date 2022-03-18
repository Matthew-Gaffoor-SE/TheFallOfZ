using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAxe : MonoBehaviour
{
    public Transform EquipPosition;
    public float Distance = 10f;
    public GameObject Axe;
    GameObject CurrentWeapon;
    GameObject wp;

    private SlamScript _SLS;
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
         // HUD.CloseMessagePanel();

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
            if (hit.transform.tag == "Axe")
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
        Axe.transform.position = EquipPosition.position;
        Axe.transform.parent = EquipPosition;
        _SLS = GameObject.Find("axe(1)").GetComponent<SlamScript>();
        _SLS.IsEquip = true;
    }

    void Drop()
    {
        CurrentWeapon.transform.parent = null;
        CurrentWeapon = null;
    }
}
