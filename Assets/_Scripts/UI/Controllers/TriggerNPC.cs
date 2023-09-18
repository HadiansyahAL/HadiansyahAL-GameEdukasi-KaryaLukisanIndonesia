using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNPC : MonoBehaviour
{
    public GameObject TextIntruksi;
    public GameObject PanelQuiz;
    private bool Action = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            TextIntruksi.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        TextIntruksi.SetActive(false);
        Action = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                TextIntruksi.SetActive(false);
                PanelQuiz.SetActive(true);
            }
        }
    }
}
