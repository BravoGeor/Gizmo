


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


   // public bool isMoving = false;
    public float movementSpeed = 125;


    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }




    // Update is called once per frame
    void Update()
    {
        //Death 
        //gravity 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        //movements 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            float moveSpeed = speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed *= 2;
            }
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }
    }

    public void Respawn()
    {
        controller.enabled = false;
        controller.transform.position = CheckPoint.GetActiveCheckPointPosition();
        controller.enabled = true;

        TrapReset[] traps = GameObject.FindObjectsByType<TrapReset>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (TrapReset trap in traps)
        {
            trap.ResetState();
        }
    }

    // Referanced code https://youtu.be/4HpC--2iowE?si=B015v73MhrT-OZyz
    // check if the player hits a trap
    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        TrapReset trap = collision.collider.GetComponent<TrapReset>();
        if (trap)
        {
            trap.CheckTrap(this);
        }
    }
}
