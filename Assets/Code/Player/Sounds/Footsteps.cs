using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound;

    void Update()
    {
        bool pressingKeys = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        bool running = Input.GetKey(KeyCode.LeftShift);

        footstepsSound.enabled = pressingKeys && !running;
        sprintSound.enabled = pressingKeys && running;
    }
}


//Link to referance. Code found in comments https://www.youtube.com/watch?v=uNYF1gsvD1A&t=11s
