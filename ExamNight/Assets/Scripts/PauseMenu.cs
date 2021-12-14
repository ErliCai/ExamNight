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

	void Awake (){
		SetLevel (volumeLevel);
		GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
		if (sliderTemp != null){
			sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
			sliderVolumeCtrl.value = volumeLevel;
		}
	}

	void Start (){
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
	}

	public void StartTutorial(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("Tutorial");
	}

	public void StartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("IntroLevel");
	}

	public void RestartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("Start");
	}

	public void QuitGame(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}


