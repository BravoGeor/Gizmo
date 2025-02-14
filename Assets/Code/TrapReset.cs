using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapReset : MonoBehaviour
{
    Vector3 position;
    Quaternion rotation;
    Vector3 velocity;
    Vector3 angularVelocity;

    public void SaveState()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            // TODO handle reset of animator
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            position = transform.position;
            rotation = transform.rotation;
            velocity = Vector3.zero;
            angularVelocity = Vector3.zero;
        }
    }

    public void ResetState()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            // TODO handle reset of animator
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = velocity;
            rb.angularVelocity = angularVelocity;
            rb.isKinematic = true;
            rb.position = position;
            rb.rotation = rotation;
        }
    }
}
