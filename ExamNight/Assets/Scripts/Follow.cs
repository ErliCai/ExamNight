using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Follow : MonoBehaviour
{
    public Transform followTransform;
    public static float gameTime = 200;
    private float gameTimer = 0f;
    public GameObject timeText;
    public bool TutorialLevel;
    
    void Start(){
        UpdateTime();
        if (TutorialLevel) {gameTime += 50000000;}
    }
    
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        gameTimer += 0.02f;
        if (gameTimer >= 1f){
                    gameTime -= 1f;
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
        
}
