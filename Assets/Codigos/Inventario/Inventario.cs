using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventario : MonoBehaviour
{


    public bool inventoryEnabled;

    public GameObject inventory;

    
    private int allSlots;

    private int enabledSlots;

    public GameObject[] slot;

    //public GameObject slotHolder;

    /*
    private void Start()
    {
        allSlots = slotHolder.transform.childCount;

        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if(slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }
    */

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pocion")
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.descripcion, item.icon);
        }else if(other.tag == "Espada")
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.descripcion, item.icon);
        }else if(other.tag == "Gema")
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.descripcion, item.icon);
        }
    }
    
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescripcion, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                // Marca el objeto como recogido
                itemObject.GetComponent<Item>().pickedUp = true;

                // Asigna el objeto al slot
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().descripcion = itemDescripcion;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().empty = false;

                break;
            }
        }
    }
    
}
