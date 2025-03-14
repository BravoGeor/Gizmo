using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            animator.SetTrigger("GizmoTitleGame");
        }
    }
}