using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;
    public string trigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(trigger);
        }
    }
}