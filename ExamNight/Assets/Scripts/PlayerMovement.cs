using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
  public Rigidbody2D rb;
  public GameObject player;
  public float moveSpeed = 5f;
  public Vector2 movement;
  private float lastJump = 0f;
  public Animator animator;
  bool canJump = false;
  public float lastHeight = 0f;
  private float contactPoint = 0f;
    
    //[HideInInspector]
    //public bool isFacingLeft;
    //[HideInInspector]
    

    //private Vector2 facingLeft;

    //protected virtual void initialization()
    //{
    //    facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
    //}

    //protected virtual void Flip()
    //{
    //    if (isFacingLeft)
    //    {
    //        transform.localScale = facingLeft;
    //    }
    //    if (!isFacingLeft)
    //    {
    //        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    //    }
    //}

    // Auto-load the RigidBody component into the variable: 
    void Start(){
        rb = GetComponent<Rigidbody2D> ();
        //isFacingLeft = false;
        //isFacingRight = true;
        //isJumping = false;
    }

  // Listen for player input to move the object: 
  void FixedUpdate(){
        movement.x = Input.GetAxisRaw ("Horizontal");
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        if (movement.x > 0)
        {
            animator.SetBool("lastLeft", false);
        }
        else if (movement.x < 0)
        {
            animator.SetBool("lastLeft", true);
        }
      
        if (Input.GetKey(KeyCode.Space) | Input.GetKeyDown(KeyCode.UpArrow)){
            if (canJump) {
              rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
              lastJump = Time.time;
              canJump = false;
                //animator.SetBool("IsJumping", true);
            }

        }

  } 

  // Makes objects with the tag "tree" disappear on contact: 
  void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Ground"){
      canJump = true;
    }
  }
} 