using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;


public class Collide : MonoBehaviour
{
    public GameObject enemy;
    public Rigidbody2D rb;
    public PlayerMovement MyMovement;
    public float new_speed = 10f;
    public bool open = false;
    public static bool hasRamen = false;


    // Start is called before the first frame update
    void Start() {
        Physics2D.IgnoreLayerCollision(7, 8);
    }

    void Update() {
        if(Input.GetKey("e")){
            open = true;
            StartCoroutine(door());
        }
        if(hasRamen){
            StartCoroutine(Ramen());
            //TODO
            //SET PLAYER SPEED BACK HERE
            //Add timer
        }   

    }
    
    IEnumerator door(){
        yield return new WaitForSeconds(3f);
        open = false;
    }
    
    IEnumerator Ramen(){
        yield return new WaitForSeconds(3f);
}
    
    //Collect note
    void OnCollisionEnter2D(Collision2D other){
        //if the player gets to the door
        if(open){
            if (enemy.gameObject.tag == "Finish"){
                if (GameHandler.scoreValue >= 5){
                    SceneManager.LoadScene("WinA");
                    Destroy(enemy); 
                    GameHandler.scoreValue = 0; 
                } else if (GameHandler.scoreValue == 4){
                    SceneManager.LoadScene("WinB");
                    Destroy(enemy);
                    GameHandler.scoreValue = 0; 
                } else if (GameHandler.scoreValue >= 2){ 
                    SceneManager.LoadScene("WinC");
                    Destroy(enemy);         
                    GameHandler.scoreValue = 0;                           
                } else if (GameHandler.scoreValue == 1){ 
                    SceneManager.LoadScene("WinD");
                    Destroy(enemy);
                    GameHandler.scoreValue = 0;                         
                }
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
        }
        // end check here
        else if (enemy.gameObject.tag == "Note"){
          if (other.gameObject.tag == "Player"){
            GameHandler.scoreValue += 1; 
            Destroy(enemy);
          }   
        } else if (enemy.gameObject.tag == "Ramen"){
          if (other.gameObject.tag == "Player"){
            Destroy(enemy);
            MyMovement.moveSpeed = new_speed;
            hasRamen = true;    
            StartCoroutine(Ramen());   
          }   
        }
        // if player touch friend
        else if (enemy.gameObject.tag == "Friend"){
          Vector3 contactPoint = other.contacts[0].point;
          Vector3 center = enemy.GetComponent<Collider2D>().bounds.center;
          if (other.gameObject.tag == "Player"){
            // Debug.Log(center.y);
            // Debug.Log(contactPoint.y);
            if (contactPoint.y - center.y < enemy.GetComponent<BoxCollider2D>().size.y / 2 - 0.02){
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
