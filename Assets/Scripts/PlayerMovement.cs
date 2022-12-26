using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    //Input
    float x;
    public bool canJump = true, canCrouch = true;
    bool space, control;
    public float crouchSize = .25f;
    public float jumpForce = 25f, jumpCooldown = 0.5f, jumpCheckDistance = 0.2f;
    //movement
    public float xSpeed = 60, maxXSpeed = 8, zSpeed = 10;
    //checking if grounded
    public LayerMask whatIsGround;
    float spaceTimer;
    public float spacebarGracePeriod = 0.25f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        if(canJump) Jump();
        if(canCrouch) Crouch();
    }

    void Update()
    {
        GetInput();
    }

    void Movement()
    {
        //extra gravity
        rb.AddForce(Vector3.down * 10f);

        //cancel out input if above max velocity so that player does not go above it
        if(Mathf.Abs(rb.velocity.x) > maxXSpeed)
            x = 0;

        int zLimit = 1;
        if(rb.velocity.z >  zSpeed) zLimit = 0;

        //move
        rb.AddForce(transform.right * x * xSpeed);
        rb.AddForce(Vector3.forward * zLimit * zSpeed * 5);
    }

    void Jump()
    {
        bool grounded = Physics.Raycast(GetComponent<Transform>().position, Vector3.down, GetComponent<Transform>().localScale.y / 2  + jumpCheckDistance, whatIsGround);
        if(grounded && space){
            //resetting y velocity in case the player is falling
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Crouch()
    {
        Transform transform = GetComponent<Transform>();
        if(control){
            transform.localScale = new Vector3(crouchSize, crouchSize, crouchSize);
        } else if(transform.localScale.z == crouchSize) {
            transform.Translate(Vector3.up * 0.5f);
            transform.localScale = new Vector3(1f, 1f, 1f);  
        }
    }

    void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        if(space) {
            spaceTimer += Time.deltaTime;
            if(spaceTimer >= spacebarGracePeriod){ 
                space = false;
                spaceTimer = 0f;
            }
        } else {
            space = Input.GetKeyDown(KeyCode.Space);
        }
        
        control = Input.GetKey(KeyCode.LeftControl);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Bouncy")
            rb.AddForce(other.collider.GetComponent<BouncepadInfo>().bounceDirection * other.collider.GetComponent<BouncepadInfo>().bounceForce, ForceMode.Impulse);
        
    }

    
}
