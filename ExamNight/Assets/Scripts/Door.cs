using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour{
    
	public Animator anim; 
    public bool open = false;
	public bool closeToDoor = false;
	public string nextScene;
    public AudioSource doorOpen;
	public bool isIntroSceneDoor = false;

    // Start is called before the first frame update
    void Start() {
		anim = GetComponentInChildren<Animator>();
		anim.SetBool("open", false);
    }

    void Update() {
		if (closeToDoor==true){
			if(Input.GetKey("e")){
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
            doorOpen.Play();
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
            
			if (isIntroSceneDoor==true){
				GameHandler.playerLastPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
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
