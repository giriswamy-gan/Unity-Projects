using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2D : MonoBehaviour
{
    Rigidbody2D rb;
    //Animation 
    public Animator animator;
    //Serialize Field initializes value
    public float speed = 10f;
    public float jump_force = 15f;
    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public float checkGroundRadius = 0.1f; 
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Punch();
        Kick();
        CheckIfGrounded();
    }
    
    //Flipping the body wrt button Clicked
    void flip(float x){
        Vector3 theScale = transform.localScale;
        if(x!=0){
            theScale.x = (x>0)? 1:-1;
        }  
        transform.localScale = theScale;
    }
    //2D Horizontal Movement
    void Move(){
        float x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal",Mathf.Abs(x));
        flip(x);
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    //Player Jump
    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
            animator.SetTrigger("Space");
        }
    }
    //Player Kick
    void Kick(){
        if(Input.GetButton("Fire2"))
        {
            animator.SetTrigger("Kick");
        }
    }
    //Player punch
    void Punch(){
        if(Input.GetButton("Fire1"))
        {
            animator.SetTrigger("Punch");
        }
    }
    //Checking if on Ground
    void CheckIfGrounded() { 
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
        if (collider != null) { 
            isGrounded = true;
        } 
        else { 
            isGrounded = false;
        } 
    }
}
