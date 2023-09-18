using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualMuseum.Menu{
public class CheckSFXVolume : MonoBehaviour
{
        public void  Start (){
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
			Debug.Log(PlayerPrefs.GetFloat("SFXVolume"));
		}

		public void UpdateVolume (){
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
		}
    }
}
