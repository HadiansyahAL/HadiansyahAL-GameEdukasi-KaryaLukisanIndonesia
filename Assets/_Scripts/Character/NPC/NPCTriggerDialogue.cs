using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueNPC
{
public class NPCTriggerDialogue : MonoBehaviour
{


    public GameObject IntruksiQuiz;
    public AudioSource OpenPanel;
    public Dialogue dialogue;

    private bool isOpen = false;

    void Update()
    {
        if (isOpen == true && (Input.GetKeyDown(KeyCode.C)))
        {
            TriggerDialogue();
            Cursor.visible = true;
            OpenPanel.Play();
            IntruksiQuiz.SetActive(false);
            isOpen = false;
        }
        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
            IntruksiQuiz.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        IntruksiQuiz.SetActive(false);

    }
    
}
}

