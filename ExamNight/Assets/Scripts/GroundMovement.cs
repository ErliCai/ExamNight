using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool MoveRight; 
    public float range;
    public float distance;
    public float verticalspeed;
    public float verticalrange;
    public float verticaldistance = 0;
    public bool MoveUp;
    
    void Start()
    {
        MoveRight = true;
        MoveUp = true;
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
        
        if (MoveUp){
          transform.Translate(0, 2 * Time.deltaTime * verticalspeed,0);
          verticaldistance += 2 * Time.deltaTime * verticalspeed;
          if (verticaldistance > verticalrange){
            MoveUp = ! MoveUp;
          }
        }
        else{
          transform.Translate(0, -2 * Time.deltaTime * verticalspeed,0);
          verticaldistance -= 2 * Time.deltaTime * verticalspeed;
          if (verticaldistance < 0){
            MoveUp = ! MoveUp;
          }
        }
    }
}
