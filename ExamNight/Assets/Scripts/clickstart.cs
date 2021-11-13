using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickstart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseOver(){
      
      GetComponent<Transform>().localScale = new Vector3 (1.2f, 1.2f, 1);
      GetComponent<TextMesh>().color = new Color (0,1,0,1);
    }
    
    void OnMouseExit(){
      
      GetComponent<Transform>().localScale = new Vector3 (1, 1, 1);
      GetComponent<TextMesh>().color = new Color (1,1,1,1);
    }
    
    void OnMouseDown(){
      
      SceneManager.LoadScene("IntroLevel");
    }    
    
}
