using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static int scoreValue = 0;
    
    Text score;

	//Room Notes Bools
	public static bool libraryNote1 = true;
	public static bool libraryNote2 = true;

	public static bool dormNote1 = true;
	public static bool dormNote2 = true;

	public static bool lockersNote1 = true;
	public static bool lockersNote2 = true;


	public static bool studyNote1 = true;
	public static bool studyNote2 = true;

	public static bool classNote1 = true;
	public static bool classNote2 = true;

	//Door return location management for the IntroScene
	public static Vector2 playerLastPos;
	public Vector2 setInitialPosition;
	public static bool firstTimeInIntroLevel = true; 

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
		
		if (firstTimeInIntroLevel == true){
			playerLastPos = setInitialPosition;
			firstTimeInIntroLevel = false;
		}
		
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "NOTES: " + scoreValue;
    }
	
	public bool checkNote(string notename){
		if (notename == "libraryNote1"){return libraryNote1;}
		else if (notename == "libraryNote2"){return libraryNote2;}

		else if (notename == "dormNote1"){return dormNote1;}
		else if (notename == "dormNote2"){return dormNote2;}

		else if (notename == "lockersNote1"){return lockersNote1;}
		else if (notename == "lockersNote2"){return lockersNote2;}

		else if (notename == "studyNote1"){return studyNote1;}
		else if (notename == "studyNote2"){return studyNote2;}

		else if (notename == "classNote1"){return classNote1;}
		else if (notename == "classNote2"){return classNote2;}
		
		else {
			Debug.Log("this note name does not yet exist");
			return false;
		} 
	}
	
	public void gotNote(string notename){
		if (notename == "libraryNote1"){libraryNote1=false;}
		else if (notename == "libraryNote2"){libraryNote2=false;}

		else if (notename == "dormNote1"){ dormNote1=false;}
		else if (notename == "dormNote2"){ dormNote2=false;}

		else if (notename == "lockersNote1"){ lockersNote1=false;}
		else if (notename == "lockersNote2"){ lockersNote2=false;}

		else if (notename == "studyNote1"){ studyNote1=false;}
		else if (notename == "studyNote2"){ studyNote2=false;}

		else if (notename == "classNote1"){ classNote1=false;}
		else if (notename == "classNote2"){ classNote2=false;}
		
		else {
			Debug.Log("this note name does not yet exist");
		} 
	}
	
	
}
