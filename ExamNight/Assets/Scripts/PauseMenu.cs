using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    
    [SerializeField] private bool isPaused;
    
    public void Update(){
      if (Input.GetKeyDown(KeyCode.Escape)){
        isPaused = !isPaused;
      }
      
      if (isPaused){
        ActivateMenu();
      }
      else{
        DeactivateMenu();
      }
    }
    
    void ActivateMenu(){
      pauseMenuUI.SetActive(true);
    }
    
    void DeactivateMenu(){
      pauseMenuUI.SetActive(false);
    }
    
}
