using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;


public class Pickups : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerMovement MyMovement;
    public float new_speed = 10f;
    public bool open = false;
	public bool hasRamen = false;
    //public static bool hasRamen = false; //moved to gamehandler

	public string pickUpName;
	private GameHandler gameHandler;

    // Start is called before the first frame update
    void Start() {
        Physics2D.IgnoreLayerCollision(7, 8);
		
		if (GameObject.FindWithTag("GameHandler") != null){
			gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		}
    }

    void Update() {

        if(hasRamen){
            StartCoroutine(Ramen());
            //TODO
            //SET PLAYER SPEED BACK HERE
            //Add timer
        }
    }
    
    IEnumerator Ramen(){
        yield return new WaitForSeconds(3f);
	}
    
    //Collect note
    void OnTriggerEnter2D(Collider2D other){
        if (this.gameObject.tag == "Note"){
			if (other.gameObject.tag == "Player"){
				GameHandler.scoreValue += 1; 
				gameHandler.gotNote(pickUpName);
				Destroy(gameObject);
			}   
        } else if (this.gameObject.tag == "Ramen"){
			if (other.gameObject.tag == "Player"){
				MyMovement.moveSpeed = new_speed;
				//GameHandler.hasRamen = true;   //speak to gamehandler 
				StartCoroutine(Ramen()); 
				Destroy(gameObject);			
			}   
        }
    }
    
}
