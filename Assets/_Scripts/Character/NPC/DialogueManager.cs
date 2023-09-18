using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueNPC
{
    public class DialogueManager : MonoBehaviour
    {
        public Text nameText;
        public Text dialogueText;


        public GameObject DialogueBox;
        public GameObject QuizBox;
        public GameObject RewardKey;

        public Animator animator;


        private Queue<string> sentences;

        void Start()
        {
            sentences = new Queue<string>();
            DialogueBox.SetActive(false);
            RewardKey.SetActive(false);

        }

        public void StartDialogue (Dialogue dialogue)
        {
            DialogueBox.SetActive(true);
            animator.Play("DialogueBoxOpen");
            nameText.text = dialogue.Name;
            sentences.Clear();
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
                DisplayNextSentence(); 
        }

        public void DisplayNextSentence()
        {
                if (sentences.Count == 0)
                {
                    EndDialogue();
                    return;
                }
                string sentence = sentences.Dequeue();
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence (string sentence)
        {
                dialogueText.text = "";
                foreach (char letter in sentence.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return null;
                }
        }

        void EndDialogue()
        {
            animator.Play("DialogueBoxClose");
            QuizBox.SetActive(true); 
        }
    }
}
