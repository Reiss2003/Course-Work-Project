using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    
     private Rigidbody2D body;
    [SerializeField]private float speed;
    [SerializeField]private float jumpForce;  
    private Animator anim;
    private bool grounded;
    
    private void Awake()
    {
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
   
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        
        
        
        if(Input.GetKey(KeyCode.Space) && grounded) 
            Jump();
            
            anim.SetBool("Run", horizontalInput != 0);
            anim.SetBool("grounded", grounded);
    }
        
    private void Jump()    
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        anim.SetTrigger("jump");
        grounded = false;
    }    
            
    private void OnCollisionEnter2D(Collision2D collision)    
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }    
        
    
     
        
}
