using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Door : MonoBehaviour{
    
	public Animator anim; 
    public bool open = false;
	public static bool closeToDoor = false;
	public string nextScene;
    public AudioSource doorOpen;
	public bool isIntroSceneDoor = false;
    public static bool leaveTut = false;


    // Start is called before the first frame update
    void Start() {
		anim = GetComponentInChildren<Animator>();
		anim.SetBool("open", false);
    }

    void Update() {
		if (closeToDoor==true){
			if(Input.GetKey("e")){
                string SceneName = SceneManager.GetActiveScene().name;
                if (SceneName == "Tutorial"){
                    GameHandler.firstTimeInIntroLevel = true; 
                }
				open = true;
				anim.SetBool("open", true);
				StartCoroutine(door());
			}
        }			
	}

	IEnumerator door(){
		yield return new WaitForSeconds(3f);
		open = false;
		anim.SetBool("open", false);
	}
    
    //Collect note
    void OnTriggerStay2D(Collider2D other){
        //if the player gets to the door
		if (other.gameObject.tag == "Player"){
			closeToDoor = true;
		}
        if(open){
            // doorOpen.Play();
            if (this.gameObject.tag == "Finish"){
                if (GameHandler.scoreValue >= 5){
                    SceneManager.LoadScene("WinA");
                    GameHandler.scoreValue = 0; 
                } else if (GameHandler.scoreValue == 4){
                    SceneManager.LoadScene("WinB");
                    GameHandler.scoreValue = 0; 
                } else if (GameHandler.scoreValue >= 2){ 
                    SceneManager.LoadScene("WinC");        
                    GameHandler.scoreValue = 0;                           
                } else if (GameHandler.scoreValue == 1){ 
                    SceneManager.LoadScene("WinD");
                    GameHandler.scoreValue = 0;                         
                }
            }
            
			//put the player back on the platform where they entered the room 
			if (isIntroSceneDoor==true){
				GameHandler.playerLastPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
				Debug.Log("playerLastPos = " + GameHandler.playerLastPos);
			} else {}
            
			SceneManager.LoadScene(nextScene); 
        
		}
		else{Debug.Log("press 'e' to open");}
    }
    
	void OnTriggerExit2D(Collider2D other){
        //if the player gets to the door
		if (other.gameObject.tag == "Player"){
			closeToDoor = false;	
		}
	}
	
}
