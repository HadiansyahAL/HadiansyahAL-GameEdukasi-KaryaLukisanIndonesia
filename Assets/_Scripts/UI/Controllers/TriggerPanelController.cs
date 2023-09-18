using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPanelController : MonoBehaviour
{
    public GameObject TextIntruksiOpen;
    public GameObject PanelLukisan;
    private bool Action = false;
    public AudioSource OpenClosePanel;


    public void Start()
    {
        PanelLukisan.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            TextIntruksiOpen.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        TextIntruksiOpen.SetActive(false);
        Action = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                OpenClosePanel.Play();
                TextIntruksiOpen.SetActive(false);
                PanelLukisan.SetActive(true);
                PanelLukisan.GetComponent<Animator>().Play("OpenPanel");
                Action = false;  
            }
            else
            {
                OpenClosePanel.Play();
                PanelLukisan.GetComponent<Animator>().Play("ClosePanel");
                Action = false;
            }
        }
    }
}
