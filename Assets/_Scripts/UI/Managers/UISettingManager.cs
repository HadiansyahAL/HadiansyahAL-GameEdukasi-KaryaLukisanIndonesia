using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


namespace VirtualMuseum.Menu {
    public class UISettingManager : MonoBehaviour {


        [Header("VIDEO SETTINGS")]
        public GameObject fullscreentext;
        public GameObject texturelowtextLINE;
		public GameObject texturemedtextLINE;
		public GameObject texturehightextLINE;


        [Header("CONTROLS & GAME SETTINGS")]

        // sliders
		public GameObject musicSlider;
		public GameObject mouseSmoothSlider;

        // private float sliderValue = 0.0f;
		private float sliderValueSmoothing = 0.0f;


        public void Start(){
            // check slider values
			musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
			mouseSmoothSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MouseSmoothing");
        

            // check full screen
			if(Screen.fullScreen == true){
				fullscreentext.GetComponent<TMP_Text>().text = "on";
			}
			else if(Screen.fullScreen == false){
				fullscreentext.GetComponent<TMP_Text>().text = "off";
            }


            // check texture quality
			if(PlayerPrefs.GetInt("Textures") == 0){
				QualitySettings.masterTextureLimit = 2;
				texturelowtextLINE.gameObject.SetActive(true);
				texturemedtextLINE.gameObject.SetActive(false);
				texturehightextLINE.gameObject.SetActive(false);
			}
			else if(PlayerPrefs.GetInt("Textures") == 1){
				QualitySettings.masterTextureLimit = 1;
				texturelowtextLINE.gameObject.SetActive(false);
				texturemedtextLINE.gameObject.SetActive(true);
				texturehightextLINE.gameObject.SetActive(false);
			}
			else if(PlayerPrefs.GetInt("Textures") == 2){
				QualitySettings.masterTextureLimit = 0;
				texturelowtextLINE.gameObject.SetActive(false);
				texturemedtextLINE.gameObject.SetActive(false);
				texturehightextLINE.gameObject.SetActive(true);
			}
        }

        public void Update (){
			//sliderValue = musicSlider.GetComponent<Slider>().value;
			sliderValueSmoothing = mouseSmoothSlider.GetComponent<Slider>().value;
		}

        public void FullScreen (){
			Screen.fullScreen = !Screen.fullScreen;

			if(Screen.fullScreen == true){
				fullscreentext.GetComponent<TMP_Text>().text = "on";
			}
			else if(Screen.fullScreen == false){
				fullscreentext.GetComponent<TMP_Text>().text = "off";
			}
		}


        public void MusicSlider (){
			//PlayerPrefs.SetFloat("MusicVolume", sliderValue);
			PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
		}


        public void SensitivitySmoothing (){
			PlayerPrefs.SetFloat("MouseSmoothing", sliderValueSmoothing);
			Debug.Log(PlayerPrefs.GetFloat("MouseSmoothing"));
		}


        public void TexturesLow (){
			PlayerPrefs.SetInt("Textures",0);
			QualitySettings.masterTextureLimit = 2;
			texturelowtextLINE.gameObject.SetActive(true);
			texturemedtextLINE.gameObject.SetActive(false);
			texturehightextLINE.gameObject.SetActive(false);
		}

		public void TexturesMed (){
			PlayerPrefs.SetInt("Textures",1);
			QualitySettings.masterTextureLimit = 1;
			texturelowtextLINE.gameObject.SetActive(false);
			texturemedtextLINE.gameObject.SetActive(true);
			texturehightextLINE.gameObject.SetActive(false);
		}

		public void TexturesHigh (){
			PlayerPrefs.SetInt("Textures",2);
			QualitySettings.masterTextureLimit = 0;
			texturelowtextLINE.gameObject.SetActive(false);
			texturemedtextLINE.gameObject.SetActive(false);
			texturehightextLINE.gameObject.SetActive(true);
		}


    }
}
