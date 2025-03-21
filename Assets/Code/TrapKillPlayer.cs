using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapKillPlayer : MonoBehaviour
{
    ThirdPersonMovement player;
    public void KillPlayer()
    {
        if (player)
        {
            player.Respawn();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        player = collider.GetComponent<ThirdPersonMovement>();
    }
}
