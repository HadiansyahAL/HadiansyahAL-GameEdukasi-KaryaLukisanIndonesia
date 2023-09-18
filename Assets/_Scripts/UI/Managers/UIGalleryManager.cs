using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace VirtualMuseum.Gallery
{
    public class UIGalleryManager : MonoBehaviour
    {
        [Header("MENU")]
        public GameObject mainMenu;
        public GameObject menu;
        public GameObject DescMenu;

        [Header("PANELS")]
        public GameObject mainCanvas;
        public GameObject PanelRuangan1;
        public GameObject PanelRuangan2;
        public GameObject PanelRuangan3;
        public GameObject PanelRuangan4;
        public GameObject PanelRuangan5;
        public GameObject PanelRuangan6;
        public GameObject PanelRuangan7;

        [Header("SETTINGS SCREEN")]
        public GameObject lineRuangan1;
        public GameObject lineRuangan2;
        public GameObject lineRuangan3;
        public GameObject lineRuangan4;
        public GameObject lineRuangan5;
        public GameObject lineRuangan6;
        public GameObject lineRuangan7;

        [Header("SFX")]
        public AudioSource hoverSound;
        public AudioSource clickSound;



        void Start()
        {
            mainMenu.SetActive(true);
            lineRuangan1.SetActive(true);
        }

        public void ReturnMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        void DisablePanels()
        {
            PanelRuangan1.SetActive(false);
            PanelRuangan2.SetActive(false);
            PanelRuangan3.SetActive(false);
            PanelRuangan4.SetActive(false);
            PanelRuangan5.SetActive(false);
            PanelRuangan6.SetActive(false);
            PanelRuangan7.SetActive(false);

            lineRuangan1.SetActive(false);
            lineRuangan2.SetActive(false);
            lineRuangan3.SetActive(false);
            lineRuangan4.SetActive(false);
            lineRuangan5.SetActive(false);
            lineRuangan6.SetActive(false);
        }

        

        public void Ruangan1()
        {
            DisablePanels();
            PanelRuangan1.SetActive(true);
            lineRuangan1.SetActive(true);
        }

        public void Ruangan2()
        {
            DisablePanels();
            PanelRuangan2.SetActive(true);
            lineRuangan2.SetActive(true);
        }

        public void Ruangan3()
        {
            DisablePanels();
            PanelRuangan3.SetActive(true);
            lineRuangan3.SetActive(true);
        }

        public void Ruangan4()
        {
            DisablePanels();
            PanelRuangan4.SetActive(true);
            lineRuangan4.SetActive(true);
        }

        public void Ruangan5()
        {
            DisablePanels();
            PanelRuangan5.SetActive(true);
            lineRuangan5.SetActive(true);
        }

        public void Ruangan6()
        {
            DisablePanels();
            PanelRuangan6.SetActive(true);
            lineRuangan6.SetActive(true);
        }

        public void Ruangan7()
        {
            DisablePanels();
            PanelRuangan7.SetActive(true);
            lineRuangan7.SetActive(true);
        }

        public void PlayHover()
        {
            hoverSound.Play();
        }

        public void ClickSound()
        {
            clickSound.Play();
        }


        

    }
}

