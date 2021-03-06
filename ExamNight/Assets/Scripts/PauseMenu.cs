 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject pauseMenuUI;
    
	[SerializeField] private bool isPaused;
	public AudioMixer mixer;
	public static float volumeLevel = 1.0f;
	private Slider sliderVolumeCtrl;
	
	public Follow cameraFollowScript;

	void Awake (){
		SetLevel (volumeLevel);
		GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
		if (sliderTemp != null){
			sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
			sliderVolumeCtrl.value = volumeLevel;
		}
	}

	void Start (){
		
		if (GameObject.FindWithTag("MainCamera") != null){
			cameraFollowScript = GameObject.FindWithTag("MainCamera").GetComponent<Follow>();
		}
		
		pauseMenuUI.SetActive(false);
	}	
	
    public void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			isPaused = !isPaused;
		}
      
		if (isPaused){
			PauseGame();
		}
		else{
			Resume();
		}
    }
    
    void PauseGame(){
      Time.timeScale = 0f;
      pauseMenuUI.SetActive(true);
    }
    
    public void Resume(){
      Time.timeScale = 1f;
      isPaused = false;
      pauseMenuUI.SetActive(false);
    }
    

	public void SetLevel (float sliderValue){
		mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
		volumeLevel = sliderValue;
		AudioSourceLoop.volume = sliderValue;
		AudioListener.volume = sliderValue;
		Debug.Log(sliderValue);
	}

	public void StartTutorial(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("Tutorial");
		cameraFollowScript.resetClock();
	}

	public void StartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("IntroLevel");
		cameraFollowScript.resetClock();
	}

	public void RestartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("Start");
		cameraFollowScript.resetClock();
	}

	public void QuitGame(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}


