using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_player : MonoBehaviour
{
  
    public GameObject falling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
      if (collision.gameObject.tag.Equals("Player")){
        Debug.Log("reseting player");
        Vector3 new_pos = falling.transform.position;
        new_pos.z = 0;
        collision.gameObject.transform.position = new_pos;
      }
    }
}
