using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour { 
    public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
    public KeyCode spacebar;
    public KeyCode L;
    public KeyCode R;
    public KeyCode slide;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    //public AudioClip jump1;
    //public AudioClip jump2;
    // Start is called before the first frame update
    public void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        //AudioManager.instance.RandomizeSfx(jump1, jump2);
    }
    public void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
   
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        
    }
    
   
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Slide", false);
        anim.SetBool("speed", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(spacebar) && grounded)
        {
            jump();
            anim.SetBool("grounded", grounded);
        }
        grounded = true;
        anim.SetBool("grounded", grounded);
        if (Input.GetKey(L))
        {
           
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
            anim.SetBool("speed", true);
           
        }
        if (Input.GetKey(R))
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
            anim.SetBool("speed",true);
        }
        if (Input.GetKey(slide))
        {
            anim.SetBool("Slide", true);
        }
        
    }
   

} 
