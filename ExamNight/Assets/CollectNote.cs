using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectNote : MonoBehaviour
{
    // Start is called before the first frame update
    private Note thisNote;
    
    private void Awake(){
      thisNote = GetComponent<Note>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
      if (collision.CompareTag("player")){
        Destroy(gameObject);
      }
    }
}
