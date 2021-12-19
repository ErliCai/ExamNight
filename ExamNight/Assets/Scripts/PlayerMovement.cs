using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{	
	public Rigidbody2D rb;
	//public GameObject player;
	public float moveSpeed = 5f;
	public float jumpSpeed = 8f;
	public float startMoveSpeed = 5f;
	public float startJumpSpeed = 8f;
	private Vector2 movement;
	private float lastJump = 0f;
	public Animator animator;
	bool canJump = false;
	//public float lastHeight = 0f;
	//private float contactPoint = 0f;
	public GameObject booster;
	public GameObject bText;
	public static int bTime = 20;
	private float bTimer = 0f;
	public AudioSource jSound;



  
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
		animator = GetComponentInChildren<Animator> ();
        //isFacingLeft = false;
        //isFacingRight = true;
        //isJumping = false;
		
		string thisLevel = SceneManager.GetActiveScene().name;
		if (thisLevel == "IntroLevel"){
			gameObject.transform.position = GameHandler.playerLastPos;
		}
		moveSpeed = startMoveSpeed;
		jumpSpeed = startJumpSpeed;
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
      
        if (Input.GetButtonDown("Jump")){
            if (canJump) {
			jSound.Play();
              rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
              lastJump = Time.time;
              canJump = false;
              animator.SetTrigger("Jump");
            }

        }
		if(Pickups.hasRamen){
			StartCoroutine(Boost());
			bTimer += 0.02f;
	        if (bTimer >= 1f){
				bTime -= 1;
				bTimer = 0;
				moveSpeed = 10;
				jumpSpeed = 10;
				if (bTime <=0){
					bTime=20;
					booster.SetActive(true);
					Pickups.hasRamen = false;
					moveSpeed = startMoveSpeed;
					jumpSpeed = startJumpSpeed;
				}
	        }
			Text timeTextC = bText.GetComponent<Text>();
	        timeTextC.text = "RAMEN TIME: " + bTime; 
		} else {
			Text timeTextC = bText.GetComponent<Text>();
			timeTextC.text = " "; 
		}
  } 
  
  IEnumerator Boost()
    {
        animator.SetBool("ramen", true);
        booster.SetActive(false);
        //Print the time of when the function is first called.
        Debug.Log("Boost");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(20);

        //After we have waited 5 seconds print the time again.
		// Collide.hasRamen = false;
        animator.SetBool("ramen", false);
    }

  // Makes objects with the tag "tree" disappear on contact: 
  void OnCollisionEnter2D(Collision2D other){
      if (other.gameObject.tag != "Note"){
		canJump = true;
      }
  }
} 