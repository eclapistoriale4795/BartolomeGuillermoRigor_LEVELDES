using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int objectID;
    [Header("Scriptable Object")]
    [SerializeField] private Item item;
    [SerializeField] private Player receiver;

    void GetAmmo()
    {
        receiver.tempAmmo += item.incrementAmmo;
        if (receiver.tempAmmo > receiver.baseAmmo)
        {
            int overloadedAmmo;
            overloadedAmmo = receiver.tempAmmo - receiver.baseAmmo;
            receiver.tempAmmo -= overloadedAmmo;
            receiver.ammo += overloadedAmmo;
        }
        item.canCollect = false;
        Destroy(this.gameObject);
    }
    void GetHealth()
    {
        if (receiver.tempHP < receiver.baseHP)
        {
            receiver.tempHP += item.incrementHP;
            if (receiver.tempHP >= receiver.baseHP)
            {
                receiver.tempHP = receiver.baseHP;
            }
            item.canCollect = false;
            Destroy(this.gameObject);
        }
        else
        {
            print("You cannot get a health kit now, your health is full.");
        }
    }
    void GetKey()
    {
        if (receiver.tempHP >= 101)
        {
            receiver.tempHP += item.incrementHP;
            if (receiver.tempHP >= receiver.baseHP)
            {
                receiver.tempHP = receiver.baseHP;
            }
            item.canCollect = false;
            Destroy(this.gameObject);
        }
        else
        {
            print("You cannot get a health kit now, your health is full.");
        }
    }
    private void Update()
    {
        if (item.canCollect)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (objectID)
                {
                    case 0: GetAmmo(); break; //objectID = 0 -> Ammo Box Item
                    case 1: GetHealth(); break; //objectID = 1 -> Health Kit Item
                    case 2: GetKey(); break; //objectID = 2 -> Key for next level
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            item.canCollect = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            item.canCollect = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            item.canCollect = false;
        }
    }
}
