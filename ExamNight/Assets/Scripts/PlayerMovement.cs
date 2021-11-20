using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
  public Rigidbody2D rb;
  public float moveSpeed = 5f;
  public Vector2 movement;
  private float lastJump = 0f;
  public Animator animator;
    
    [HideInInspector]
    public bool isFacingLeft;
    [HideInInspector]
    public bool isFacingRight;
    [HideInInspector]
    public bool isJumping;

    private Vector2 facingLeft;

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
        //if (movement.x > 0 && )
        if (Input.GetKey(KeyCode.Space) | Input.GetKeyDown(KeyCode.UpArrow)){
            if (Time.time > lastJump + 2) {
              rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
              lastJump = Time.time;
                animator.SetBool("IsJumping", true);
            }

        }

  } 

  // Makes objects with the tag "tree" disappear on contact: 
  void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == ""){
        }
  }
} 