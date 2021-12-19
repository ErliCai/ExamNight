using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class check_point_replaceText : MonoBehaviour
{
    public GameObject ttext;
    public string new_string;
    public bool kickedout = false;
    public bool angryFace = false;
    public GameObject angryteacher;
    public GameObject happyteacher;
    public static bool angry = false;
    
    void Start(){
      angryteacher = GameObject.FindWithTag("AngryTeacher");
      happyteacher = GameObject.FindWithTag("HappyTeacher");
    }
    
    void FixedUpdate(){
      if (angry) {
        angryteacher.SetActive(true);
        happyteacher.SetActive(false);
      }
      else{
        happyteacher.SetActive(true);
        angryteacher.SetActive(false);
      }
    }
    
    void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag.Equals("Player")){
        Debug.Log("reaching checkpoint");
        ttext.GetComponent<Text>().text = new_string;
        
        if (angryFace) {
          angry = true;
        }
        else{
          angry = false;
        }
        
      }
      
      if (kickedout){
        SceneManager.LoadScene("Start"); 
      }
      
    }
    
}
