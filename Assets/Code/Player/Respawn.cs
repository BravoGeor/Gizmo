using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour


{

   // [SerializeField] private Transform Player;
   public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {

        //Player.transform.position = respawnPoint.transform.position;

        if (other.tag == "Player")
        {
            Debug.Log("Player contact");

            CharacterController cc = other.GetComponent <CharacterController>();
           

                if (cc != null) 
            {
                cc.enabled = false;
            }
            other.transform.position = respawnPoint.transform.position;
            StartCoroutine(CCEnableRoutine(cc));    
        }

    }

    IEnumerator CCEnableRoutine(CharacterController Controller)
    {
        yield return new WaitForSeconds(0.2f);
        Controller.enabled = true;
    }

}

//Referanced Code https://youtu.be/FPU3uR3HYGo?si=XSVOgP78MUd3Y5Qd
