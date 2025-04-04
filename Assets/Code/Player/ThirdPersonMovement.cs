


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
    private Vector3 moveDirection;
  

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator animator;


   // public bool isMoving = false;
    public float movementSpeed = 125;


    Vector3 velocity;
    bool isGrounded;
    private bool isJumping;


    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
       // animator = GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {
        if (!controller.enabled) return;

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

        //Player Grounded
        //animator.SetBool("IsGrounded", true);                                          //
      //  isGrounded = true;                                                                        //
     //   animator.SetBool("IsJumping", false);                                          // 
      //  isJumping = false;                                                                          // 
      //  animator.SetBool("IsFalling", false);                                             //




        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //animator.SetBool("isJumping, "true);                                             //
            //isJumping = true;                                                                           //
           // animator.SetBool("IsGrounded" false);
          //  isGrounded = false; 

      
        }


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            float moveSpeed = speed;
           
            //Sprint 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed *= 2;
                
            }
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        //Animation 
        {
            if (direction == Vector3.zero)
            {
                //Idle 
                animator.SetFloat("Speed", 0);
            }
            else if (!Input.GetKey(KeyCode.LeftShift))
            {
                //Walk
                animator.SetFloat("Speed", 0.5f);
            }
            else
            {
                //Run
                animator.SetFloat("Speed", 1);
            }

        }
    }
    //Respawn 
    public void Respawn()
    {
        controller.enabled = false;
        animator.SetTrigger("BearDeath");
        StartCoroutine(RespawnPlayer());
    }

    bool AnimationIsFinished(string animationName)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        return info.IsName(animationName) && info.normalizedTime >= 1f;
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitUntil(() => AnimationIsFinished("BearDeath"));

        animator.SetTrigger("Respawn");
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
