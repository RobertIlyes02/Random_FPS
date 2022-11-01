using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    private bool isGrounded;

    public float gravity = -9.81f;
    public float jumpforce = 8f;
    public float jumpheight = 3f;
    Vector3 velocity;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool sprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        // {
        //     HandleJump();
        // }

        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown("space") && isGrounded)
        {
            Debug.Log("jump");
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !sprinting && isGrounded)
        {
            Debug.Log("Sprint");
            speed = 24f;
            sprinting = true;
        } else if (Input.GetKeyDown(KeyCode.LeftShift) && sprinting && isGrounded)
        {
            speed = 12f;
            sprinting = false;
        }
    }

    private void HandleJump()
    {
        //transform.direction = jumpforce;
    }
}
