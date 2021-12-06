using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectNote : MonoBehaviour
{
    // Start is called before the first frame update
    private Note thisNote;
    public AudioSource noteNoise;

    
    private void Awake(){
      thisNote = GetComponent<Note>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
      if (collision.gameObject.tag.Equals("player")){
        noteNoise.Play();
        Destroy(gameObject);
      }
    }
}
