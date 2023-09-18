using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HadiansyahAL.PlayerControl
{
    public class TriggerKeyDoorController : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private string openDoor = "OpenLockedDoor";
        [SerializeField] private GameObject IntruksiOpenDoor;
        [SerializeField] private AudioSource OpenCloseDoor;
        [SerializeField] private GameObject showDoorLockedUI = null;
        [SerializeField] private int timeToShowUI = 1;

        private bool isOpen = false;
        // private bool isClose = true;

        private PlayerController keys;

        void Start()
        {   
            keys = FindObjectOfType<PlayerController>();
            anim = GetComponent<Animator>();  
        }

        void Update()
        {
            if (isOpen == true && (Input.GetKeyDown(KeyCode.F)) && keys.KeyAmount >= 1)
            {
                keys.KeyAmount -= 1;
                OpenCloseDoor.Play();
                anim.Play(openDoor, 0, 0.0f);
                isOpen = false;
                // isClose = false;
            }
            else if ((isOpen == true && (Input.GetKeyDown(KeyCode.F)) && keys.KeyAmount <= 1))
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.tag == "Player")
            {
                isOpen = true;
                IntruksiOpenDoor.SetActive(true);
            }
        }

        IEnumerator ShowDoorLocked()
            {
                showDoorLockedUI.SetActive(true);
                yield return new WaitForSeconds(timeToShowUI);
                showDoorLockedUI.SetActive(false);
            }

        private void OnTriggerExit(Collider other) 
        {
            IntruksiOpenDoor.SetActive(false);
        }
    }
}

