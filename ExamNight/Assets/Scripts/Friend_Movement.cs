using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend_Movement : MonoBehaviour
{
  
    public float speed;
    public bool MoveRight; 
    public float range;
    public float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveRight = true;
    }

    // Update is called once per frame
    void Update()
    {   
        if (MoveRight){
          transform.Translate(2 * Time.deltaTime * speed, 0,0);
          distance += 2 * Time.deltaTime * speed;
          if (distance > range){
            MoveRight = ! MoveRight;
          }
        }
        else{
          transform.Translate(-2 * Time.deltaTime * speed, 0,0);
          distance -= 2 * Time.deltaTime * speed;
          if (distance < 0){
            MoveRight = ! MoveRight;
          }
        }
    }
}
