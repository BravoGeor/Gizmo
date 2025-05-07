using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FalltrapGroundSoundTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    void OnTriggerEnter(Collider other)
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                onTriggerEnter.Invoke();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                onTriggerExit.Invoke();
            }
        }

    }
}

//Referanced code https://youtu.be/p1ZgS2z-LTs?si=T2lslte8rLNYyWCU
