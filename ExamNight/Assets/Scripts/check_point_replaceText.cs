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
    
    void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag.Equals("Player")){
        Debug.Log("reaching checkpoint");
        ttext.GetComponent<Text>().text = new_string;
      }
      
      if (kickedout){
        SceneManager.LoadScene("Start"); 
      }
    }
}
