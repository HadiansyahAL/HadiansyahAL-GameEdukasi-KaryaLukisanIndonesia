using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VirtualMuseum.Gallery
{
    public class UIDescManager : MonoBehaviour
    {
        private Animator Animator;

        [Header("DESKRIPSI LUKISAN")]
        public GameObject L1_1;
        public GameObject L1_2;
        public GameObject L1_3;
        public GameObject L1_4;
        public GameObject L1_5;
        public GameObject L1_6;
        public GameObject L1_7;
        public GameObject L1_8;
        public GameObject L1_9;
        public GameObject L1_10;
        public GameObject L1_11;
        public GameObject L1_12;




        public void BackMenu()
        {
            DisableDescLukisan();
        }


        void DisableDescLukisan()
        {
            L1_1.SetActive(false);
            L1_2.SetActive(false);
            L1_3.SetActive(false);
            L1_4.SetActive(false);
            L1_5.SetActive(false);
            L1_6.SetActive(false);
            L1_7.SetActive(false);
            L1_8.SetActive(false);
            L1_9.SetActive(false);
            L1_10.SetActive(false);
            L1_11.SetActive(false);
            L1_12.SetActive(false);
        }



        public void Lukisan1_1()
        {
            DisableDescLukisan();
            L1_1.SetActive(true);
        }

        public void Lukisan1_2()
        {
            DisableDescLukisan();
            L1_2.SetActive(true);
        }

        public void Lukisan1_3()
        {
            DisableDescLukisan();
            L1_3.SetActive(true);
        }
        public void Lukisan1_4()
        {
            DisableDescLukisan();
            L1_4.SetActive(true);
        }
        public void Lukisan1_5()
        {
            DisableDescLukisan();
            L1_5.SetActive(true);
        }
        public void Lukisan1_6()
        {
            DisableDescLukisan();
            L1_6.SetActive(true);
        }
        public void Lukisan1_7()
        {
            DisableDescLukisan();
            L1_7.SetActive(true);
        }
        public void Lukisan1_8()
        {
            DisableDescLukisan();
            L1_8.SetActive(true);
        }
        public void Lukisan1_9()
        {
            DisableDescLukisan();
            L1_9.SetActive(true);
        }
        public void Lukisan1_10()
        {
            DisableDescLukisan();
            L1_10.SetActive(true);
        }
        public void Lukisan1_11()
        {
            DisableDescLukisan();
            L1_11.SetActive(true);
        }
        public void Lukisan1_12()
        {
            DisableDescLukisan();
            L1_12.SetActive(true);
        }


    }
}

