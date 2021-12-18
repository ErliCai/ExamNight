using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Follow : MonoBehaviour
{
    public Transform followPos;
    public static float gameTime = 300;
	public float startGameTime = 300;
    private float gameTimer = 0f;
    public GameObject timeText;
    public bool TutorialLevel;
    //public GameObject doorText;
    
    void Start(){
        UpdateTime();
        // if (TutorialLevel) {gameTime += 50000000;}
		//gameTime = startGameTime;
		
		if (GameObject.FindWithTag("Player") != null){
			followPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
			 
		} else {
			followPos = GameObject.FindWithTag("EndCamPos").GetComponent<Transform>();
			Debug.Log("No player in scene");
		}
		
    }
    
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followPos.position.x, followPos.position.y, this.transform.position.z);
        
		if (TutorialLevel==false){
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
			// if(!Door.closeToDoor){
			//     Text sampleText = doorText.GetComponent<Text>();
			//     sampleText.text = " "; 	
			// } else {
			//     Text sampleText = doorText.GetComponent<Text>();
			//     sampleText.text = "Press \"e\" to enter "; 	
			// }
		}
    }
    
    public void UpdateTime(){
        Text timeTextB = timeText.GetComponent<Text>();
        timeTextB.text = "TIME: " + gameTime;
    } 
        
	public void resetClock(){
		gameTime = startGameTime;
	}	
		
}
