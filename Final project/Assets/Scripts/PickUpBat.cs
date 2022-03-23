using UnityEngine;

public class PickUpBat : MonoBehaviour
{
    public Transform EquipPosition;
    public float Distance = 10f;
    public GameObject Bat;
    GameObject CurrentWeapon;
    GameObject wp;
    public GameObject PickupCanvas;

    private SwingScript SS;
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
            if (hit.transform.tag == "Bat")
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
        Bat.transform.position = EquipPosition.position;
        Bat.transform.parent = EquipPosition;
        SS = GameObject.Find("eBat").GetComponent<SwingScript>();
        SS.IsEquip = true;
    }
}
