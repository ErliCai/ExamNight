using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;


public class Pickups : MonoBehaviour
{
    // ParticleSystem collectnote;
    public Rigidbody2D rb;
    //public PlayerMovement MyMovement;
    public float new_speed = 10f;
    public bool open = false;
	//public bool hasRamen = false;
    //public static bool hasRamen = false; //moved to gamehandler

	public string pickUpName;
	private GameHandler gameHandler;

    public GameObject particlesPrefab;
    public Transform particleSpawn;
    // Start is called before the first frame update

    void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
		//MyMovement = 
		
        Physics2D.IgnoreLayerCollision(7, 8);
		if (GameObject.FindWithTag("GameHandler") != null){
			gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		}
		
		particleSpawn = gameObject.transform;
		
    }

    void Update() {

    }


    //Collect note
    
    void OnTriggerEnter2D(Collider2D other){
        if (this.gameObject.tag == "Note"){
			if (other.gameObject.tag == "Player"){
                Destroy(gameObject);
                GameHandler.scoreValue += 1; 
				gameHandler.gotNote(pickUpName);
                // ParticleSystem.Play();
                GameObject ps = Instantiate(particlesPrefab, particleSpawn.position, Quaternion.identity);
            }   
        } else if (this.gameObject.tag == "Ramen"){
			if (other.gameObject.tag == "Player"){
				PlayerMovement.hasRamen = true;
				//other.gameObject.GetComponent<PlayerMovement>().moveSpeed = new_speed;
				//hasRamen = true;   //speak to gamehandler 
			}   
        }
    }
    
}
