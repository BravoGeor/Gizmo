using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCollider : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        // Ensure the Animator component is assigned
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specific collider
        if (collision.gameObject.tag == "Player")
        {
            // Trigger the animation
            animator.SetTrigger("BridgeTrigger");
        }
    }
}