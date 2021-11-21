using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collide : MonoBehaviour
{
    public GameObject enemy;
    public Rigidbody2D rb;
    public PlayerMovement MyMovement;


    // Start is called before the first frame update
    void Start() {
        Physics2D.IgnoreLayerCollision(7, 8);
    }

    void Update() {
        
    }
    
    
    //Collect note
    void OnCollisionEnter2D(Collision2D other){
        //if the player gets to the door
        if (enemy.gameObject.tag == "Finish"){
            if (GameHandler.scoreValue >= 5){
                SceneManager.LoadScene("WinA");  
            } else if (GameHandler.scoreValue == 4){
                SceneManager.LoadScene("WinB");                                                   // restart same level 
            } else if (GameHandler.scoreValue >= 2){ 
                SceneManager.LoadScene("WinC");                                                   // restart same level                                                    // restart same level
            } else if (GameHandler.scoreValue == 1){ 
                SceneManager.LoadScene("WinD");                                                   // restart same level                                                    // restart same level                                                    // restart same level                                                    // restart same level
            } else {
                SceneManager.LoadScene("WinF");                                                   // restart same level                                                    // restart same level                                                    // restart same level                                                    // restart same level
            }
            Destroy(enemy);
        }
        if (enemy.gameObject.tag == "Lib"){
                SceneManager.LoadScene("Library"); 
        }
        if (enemy.gameObject.tag == "Dorm"){
                SceneManager.LoadScene("DormRoom"); 
        }
        if (enemy.gameObject.tag == "CheckFalling"){
                SceneManager.LoadScene("LoseFriend"); 
        }
        if (enemy.gameObject.tag == "Room1"){
                SceneManager.LoadScene("IntroLevel"); 
        }
        else if (enemy.gameObject.tag == "Note"){
          if (other.gameObject.tag == "Player"){
            GameHandler.scoreValue += 1; 
            Destroy(enemy);
          }   
        } else if (enemy.gameObject.tag == "Ramen"){
          if (other.gameObject.tag == "Player"){
            Destroy(enemy);
            MyMovement.moveSpeed = 10f;
            //TODO:APPLY OVER LIMITED TIME
          }   
        }
        // if player touch friend
        else if (enemy.gameObject.tag == "Friend"){
          Vector3 contactPoint = other.contacts[0].point;
          Vector3 center = enemy.GetComponent<Collider2D>().bounds.center;
          if (other.gameObject.tag == "Player"){
            Debug.Log(center.y);
            Debug.Log(contactPoint.y);
            if (contactPoint.y - center.y < 0.4){
              SceneManager.LoadScene("LoseFriend");
              Destroy(enemy);
              }
            else{
              Destroy(enemy);
            }
          }
        }    
    }
    
}
