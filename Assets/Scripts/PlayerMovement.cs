using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;


    float horzInput;
    float vertInput;

    Vector3 moveDir;
    Rigidbody rb;

    public bool isClimbing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

    }

    void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //Debug.Log(grounded);

        if (!isClimbing)
        {
            myInput();

            SpeedControl();

            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
        }
    }

    void FixedUpdate()
    {
        if (!isClimbing)
        {
            movePlayer();
        }
    }

    void myInput()
    {

        horzInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
       // Debug.Log("readuy + " + readyToJump);
        //Debug.Log("groun + " + grounded);
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        

    }

    void movePlayer()
    {

        moveDir = orientation.forward * vertInput + orientation.right * horzInput;

        if(grounded)
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {

            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);


        }
    }

    void Jump()
    {
        Debug.Log("jump");
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    void ResetJump()
    {

        readyToJump = true;


    }
}
