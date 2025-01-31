using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lay : MonoBehaviour
{
    private Vector3 layScale = new Vector3(1, 0.2f, 1);
    private Vector3 playerScale = new Vector3(1, 1f, 1);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))

        {
            transform.localScale = layScale;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            transform.localScale = playerScale;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
    }
}

//Referanced Code https://youtu.be/_nJiM62edas?si=7DDTaO1ChjzsQH38