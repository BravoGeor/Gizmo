using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }

    void OnTriggerExit(Collider other) 
    {
        onTriggerExit.Invoke();
    }
}
//Referanced code https://youtu.be/p1ZgS2z-LTs?si=T2lslte8rLNYyWCU
