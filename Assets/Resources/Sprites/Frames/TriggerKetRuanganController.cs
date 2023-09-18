using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKetRuanganController : MonoBehaviour
{
    [SerializeField] private Animator myKet = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] private GameObject ketRuangan;
    [SerializeField] private string slideOpenAnim = "SlideOpenAnim";
    [SerializeField] private string slideCloseAnim = "SlideCloseAnim";


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                gameObject.SetActive(false);
                ketRuangan.SetActive(true);
                myKet.Play(slideOpenAnim, 0, 0.0f);
            }

            if (closeTrigger)
            {
                gameObject.SetActive(false);
                ketRuangan.SetActive(true);
                myKet.Play(slideCloseAnim, 0, 0.0f);
            }
        }

    }
}
