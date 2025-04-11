


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

    //Jumping bools 
    private bool IsJumping;
    private bool IsGrounded;
    private bool IsFalling;

    //Crouching Bools 
    private bool IsCrouched;


   // public bool isMoving = false;
    public float movementSpeed = 125;


    Vector3 velocity;
    

    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // animator = GetComponent<Animator>();
        //Player Grounded
        animator.SetBool("IsGrounded", true);                                          //
        IsGrounded = true;                                                                        //
        animator.SetBool("IsJumping", false);                                          // 
        IsJumping = false;                                                                          // 
        animator.SetBool("IsFalling", false);                                             //
        IsFalling = false;
    }




    // Update is called once per frame
    void Update()
    {
        //grass
        Shader.SetGlobalVector("_Player", transform.position); 

        if (!controller.enabled) return;

            //gravity 
            IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        //movements 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;





        if (IsGrounded)
        {
            if (!IsCrouched && Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                animator.SetBool("IsJumping", true);                                             //
                IsJumping = true;                                                                           //
                animator.SetBool("IsGrounded", false);
                IsGrounded = false;
            }
            else if (Input.GetButtonDown("Crouch"))
            {
                animator.SetBool("IsCrouched", true);                                             //
                IsCrouched = true;                                                                           //
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                animator.SetBool("IsCrouched", false);
                IsCrouched = false;
            }
        }

        if (IsJumping && velocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
            IsFalling = true;
        }

        if (IsFalling && IsGrounded)
        {
            animator.SetBool("IsGrounded", true);
            IsJumping = false;
            animator.SetBool("IsJumping", false);
            IsFalling = false;
            animator.SetBool("IsFalling", false);
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
