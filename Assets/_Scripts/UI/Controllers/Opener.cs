using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opener : MonoBehaviour {

    public GameObject OpenPanel = null;

    private bool _isInsideTrigger = false;

    public Animator _animator;
    

    private bool _isOpen = false; 


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            // _animator.SetBool("Open", false);
            OpenPanel.SetActive(false);
        }
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    void Update () {
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // OpenPanel.SetActive(true);
                _isOpen = !_isOpen;
                // _animator.SetBool("Open", true);
                _animator.SetBool("Open", _isOpen);
            }
        }
    }
}
