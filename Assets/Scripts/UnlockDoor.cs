using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UnlockDoor : MonoBehaviour
{
    public bool interactable;
    public Player receiver;

    private void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (receiver.holdingKey)
                {
                    receiver.holdingKey = false;
                    Debug.Log("Door has been opened");
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Where is your key?");
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = false;
        }
    }
}
