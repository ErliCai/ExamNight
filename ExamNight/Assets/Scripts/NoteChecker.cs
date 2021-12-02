using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteChecker : MonoBehaviour{
	public GameObject[] noteOBJs;
	public string[] noteNames;
		
	private GameHandler gameHandler;

    void Start()
    {
		if (GameObject.FindWithTag("GameHandler") != null){
			gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		}
		
		
		//foreach (int i in noteNames.Length){
		for(int i = 0; i < noteNames.Length; i++){
			if (gameHandler.checkNote(noteNames[i]) == true){
				noteOBJs[i].SetActive(true);
			} else {
				noteOBJs[i].SetActive(false);
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
