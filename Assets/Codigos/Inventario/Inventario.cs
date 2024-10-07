using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventario : MonoBehaviour
{
/*
    private bool inventoryEnabled;

    public GameObject inventory;

    private int allSlots;

    private int enabledSlot;

    private GameObject[] slots;

    public GameObject slotHolder;


    void Start()
    {
        allSlots = slotHolder.transform.childCount;

        slots = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;


        }
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(other.tag == "Item")
        {
            GameObject itempickedUp = other.GameObject;

            Item item = itempickedUp.GetComponent<Item>();

            AddItem(itempickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for( int i = 0;i < allSlots; i++)
        {
            if (slots[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slots[i].GetComponent<Slot>().item = itemObject;
                slots[i].GetComponent<Slot>().ID = itemID;
                slots[i].GetComponent<Slot>().type = itemType;
                slots[i].GetComponent<Slot>().description = itemDescription;
                slots[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slots[i].transform;
                itemObject.SetActive(true);

                slots[i].GetComponent<Slot>().empty = false;
            }
        }
    }
    */
}
