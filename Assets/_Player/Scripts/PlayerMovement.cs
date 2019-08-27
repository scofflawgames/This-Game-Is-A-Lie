using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Public References")]
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;

    [SerializeField]
    private Animator playerAnim = null;

    private Vector3 moveDirection;
    //private Rigidbody rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

       if (controller.isGrounded)
        {         
            if (Input.GetButtonDown("Jump"))
            {
                //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);
        Move(x, y);

        Punch();
    }

    private void Move(float x, float y)
    {
        playerAnim.SetFloat("VelX", x);
        playerAnim.SetFloat("VelY", y);
    }

    private void Punch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.Play("RightPunch");
            print("RIGHT PUNCH!!");
        }
    }

}
