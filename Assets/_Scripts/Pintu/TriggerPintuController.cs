using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerPintuController : MonoBehaviour
{
    [SerializeField] private Animator myDoor1 = null;
    [SerializeField] private Animator myDoor2 = null;

    [SerializeField] private AudioSource OpenCloseDoor;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    [SerializeField] private string doorOpen = "OpenDoor";
    [SerializeField] private string doorClose = "CloseDoor";
    [SerializeField] private string doorOpenKiri = "OpenDoorKiri";
    [SerializeField] private string doorCloseKiri = "CloseDoorKiri";


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                myDoor1.Play(doorOpen, 0, 0.0f);
                myDoor2.Play(doorOpenKiri, 0, 0.0f);
                gameObject.SetActive(false);
                OpenCloseDoor.Play();
            }

            else if (closeTrigger)
            {
                myDoor1.Play(doorClose,0, 0.0f);
                myDoor2.Play(doorCloseKiri, 0, 0.0f);
                gameObject.SetActive(false);
            }
        }

    }

    
}
