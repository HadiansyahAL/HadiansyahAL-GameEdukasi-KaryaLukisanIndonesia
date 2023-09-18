using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace VirtualMuseum.Menu{
    public class UIMenuManager : MonoBehaviour {
        private Animator CameraObject;

        [Header("MENU")]
        public GameObject mainMenu;
        public GameObject firstMenu;
        public GameObject playMenu;
        public GameObject exitMenu;

        [Header("PANELS")]
		public GameObject bgCanvas;
        public GameObject mainCanvas;
		public GameObject settingCanvas;
		public GameObject creditCanvas;
        public GameObject PanelControls;
        public GameObject PanelGame;
        public GameObject PanelVideo;

        [Header("SETTINGS SCREEN")]
        public GameObject lineGame;
        public GameObject lineControls;
        public GameObject lineVideo;

        [Header("LOADING SCREEN")]
        public bool waitForInput = true;
        public GameObject loadingMenu;
        public Slider loadingBar;
        public TMP_Text loadPromptText;
		public KeyCode userPromptKey;

        [Header("SFX")]
        public AudioSource hoverSound;
		public AudioSource clickSound;
		public AudioSource sliderSound;
        public AudioSource swooshSound;



        void Start(){
			CameraObject = transform.GetComponent<Animator>();
			playMenu.SetActive(false);
			exitMenu.SetActive(false);
			// if(creditMenu) creditMenu.SetActive(false);
			firstMenu.SetActive(true);
			mainMenu.SetActive(true);
			bgCanvas.SetActive(true);
		}
        public void PlayCampaign(){
			exitMenu.SetActive(false);
			playMenu.SetActive(true);
		}
        public void ReturnMenu(){
			playMenu.SetActive(false);
			// if(creditMenu) creditMenu.SetActive(false);
			exitMenu.SetActive(false);
			firstMenu.SetActive(true);
		}
        public void LoadScene(string scene){
			if(scene != ""){
				StartCoroutine(LoadAsynchronously(scene));
			}
		}
        public void  DisablePlayCampaign(){
			playMenu.SetActive(false);
			bgCanvas.SetActive(false);
		}
		public void Position3(){
			DisablePlayCampaign();
			settingCanvas.SetActive(false);
			creditCanvas.SetActive(true);
			CameraObject.SetFloat("Animate",1);
		}
        public void Position2(){
			DisablePlayCampaign();
			creditCanvas.SetActive(false);
			settingCanvas.SetActive(true);
			CameraObject.SetFloat("Animate",1);
		}
		public void Position1(){
			bgCanvas.SetActive(true);
			CameraObject.SetFloat("Animate",0);
		}
		void DisablePanels(){
            PanelControls.SetActive(false);
			PanelVideo.SetActive(false);
			PanelGame.SetActive(false);

			lineGame.SetActive(false);
            lineControls.SetActive(false);
			lineVideo.SetActive(false);
		}
        public void GamePanel(){
			DisablePanels();
			PanelGame.SetActive(true);
			lineGame.SetActive(true);
		}
		public void VideoPanel(){
			DisablePanels();
			PanelVideo.SetActive(true);
			lineVideo.SetActive(true);
		}
        public void ControlsPanel(){
			DisablePanels();
			PanelControls.SetActive(true);
			lineControls.SetActive(true);
		}
        public void PlayHover(){
			hoverSound.Play();
		}
		public void PlaySFXHover(){
			sliderSound.Play();
		}
		public void PlaySwoosh(){
			swooshSound.Play();
		}
		public void PlayClick()
		{
			clickSound.Play();
		}


		// Are You Sure - Quit Panel Pop Up
		public void AreYouSure(){
			exitMenu.SetActive(true);
			DisablePlayCampaign();
			bgCanvas.SetActive(true);
			firstMenu.SetActive(false);
		}

		// public void CreditMenu(){
		// 	playMenu.SetActive(false);
		// 	// if(creditMenu) creditMenu.SetActive(false);
		// 	exitMenu.SetActive(false);
		// }

		public void QuitGame(){
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}

        // Load Bar synching animation
		IEnumerator LoadAsynchronously(string sceneName){ // scene name is just the name of the current scene being loaded
			AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
			operation.allowSceneActivation = false;
			mainCanvas.SetActive(false);
			bgCanvas.SetActive(false);
			loadingMenu.SetActive(true);

			while (!operation.isDone){
				float progress = Mathf.Clamp01(operation.progress / .95f);
				loadingBar.value = progress;

				if (operation.progress >= 0.9f && waitForInput){
					loadPromptText.text = "Press " + userPromptKey.ToString().ToUpper() + " to continue";
					loadingBar.value = 1;


					if (Input.GetKeyDown(userPromptKey)){
						operation.allowSceneActivation = true;
					}
                }else if(operation.progress >= 0.9f && !waitForInput){
					operation.allowSceneActivation = true;
				}

				yield return null;
			}
		}

    }
}