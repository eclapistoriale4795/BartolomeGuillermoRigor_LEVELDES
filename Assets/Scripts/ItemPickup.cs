using System.Collections;
using System.Collections.Generic;
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
            int overloadedAmmo = receiver.tempAmmo - receiver.baseAmmo;
            receiver.tempAmmo -= overloadedAmmo;
            receiver.ammo += overloadedAmmo;
        }
        item.canCollect = false;
        Destroy(gameObject);
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
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You cannot get a health kit now, your health is full.");
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
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You cannot get a health kit now, your health is full.");
        }
    }

    private void Update()
    {
        if (item.canCollect && Input.GetKeyDown(KeyCode.E))
        {
            switch (objectID)
            {
                case 0: GetAmmo(); break;
                case 1: GetHealth(); break;
                case 2: GetKey(); break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            item.canCollect = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            item.canCollect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            item.canCollect = false;
        }
    }
}
