using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickmenu : MonoBehaviour
{
	public Follow cameraFollowScript;	
	public Color startColor;
	
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("MainCamera") != null){
			cameraFollowScript = GameObject.FindWithTag("MainCamera").GetComponent<Follow>();
		}
		
		startColor = GetComponentInChildren<TextMesh>().color;
		
    }

    
    void OnMouseOver(){
      gameObject.transform.localScale = new Vector3 (1.2f, 1.2f, 1);
      GetComponentInChildren<TextMesh>().color = new Color (0,1,0,1);
    }
    
    void OnMouseExit(){
      
      gameObject.transform.localScale = new Vector3 (1, 1, 1);
      GetComponentInChildren<TextMesh>().color = startColor;
    }
    
    void OnMouseDown(){
		GameHandler.scoreValue = 0;
		cameraFollowScript.resetClock();
		SceneManager.LoadScene("Start");
    }    
    
}