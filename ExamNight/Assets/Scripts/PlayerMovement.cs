using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
  public Rigidbody2D rb;
  public float moveSpeed = 5f;
  public Vector2 movement;
  private float lastJump = 0f;
 

  // Auto-load the RigidBody component into the variable: 
  void Start(){
        rb = GetComponent<Rigidbody2D> ();
  }
  // Listen for player input to move the object: 
  void FixedUpdate(){
        movement.x = Input.GetAxisRaw ("Horizontal");
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space)){
            if (Time.time > lastJump + 1) {
              rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
              lastJump = Time.time;
            }
        }
  } 

  // Makes objects with the tag "tree" disappear on contact: 
  void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == ""){
        }
  }
} 