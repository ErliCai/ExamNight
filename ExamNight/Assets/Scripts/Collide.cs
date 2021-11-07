using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collide : MonoBehaviour
{
    public GameObject enemy;
    public int gameTime = 20;
    private float gameTimer = 0f;
    public GameObject timeText;

    // Start is called before the first frame update
    void Start() {
        UpdateTime();
    }

    void Update() {
        
    }
    
    void FixedUpdate(){
      gameTimer += 0.02f;
      if (gameTimer >= 1f){
                  gameTime -= 1;
                  gameTimer = 0;
                  UpdateTime();
      }
      if (gameTime <= 0){
                  gameTime = 0;
                  SceneManager.LoadScene("ExamMiss");                                                   // restart same level
      }
  }
  
  public void UpdateTime(){
      Text timeTextB = timeText.GetComponent<Text>();
      timeTextB.text = "TIME: " + gameTime;
  }
    
    //Collect note
    void OnCollisionEnter2D(Collision2D other){
        //if the player gets to the door
        if (enemy.gameObject.tag == "Finish"){
            if (GameHandler.scoreValue == 2){
                SceneManager.LoadScene("WinA");                                                   // restart same level
            } else {
                SceneManager.LoadScene("WinC");                                                   // restart same level
            }
        }
        else if (enemy.gameObject.tag == "Note"){
            GameHandler.scoreValue += 1;        
        }        
        Destroy(enemy);
    }
    
}
