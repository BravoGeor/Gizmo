using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hint : MonoBehaviour
{
    [SerializeField] GameObject Hint1;
    private bool hint1Open = false;

    // Start is called before the first frame update
    void Start()
    {
      Hint1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hint1Open == false)
            {
                Hint1.gameObject.SetActive(true);
                hint1Open = true;

            }
            else
            {
                Hint1.gameObject.SetActive(false);
                hint1Open = false;

            }
        }
    }

    // Tutorial code was referanced from https://youtu.be/vRKrg9Ku8Aw?si=ppcqxembEk9X8NYg
}
