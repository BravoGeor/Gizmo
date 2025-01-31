using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizLight : MonoBehaviour
{
    [SerializeField] GameObject GizmoLight;
    private bool GizmoLightOn = false;

    // Start is called before the first frame update
    void Start()
    {
        GizmoLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GizmoLightOn == false)
            {
                GizmoLight.gameObject.SetActive(true);
                GizmoLightOn = true;

            }
            else
            {
                GizmoLight.gameObject.SetActive(false);
                GizmoLightOn = false;

            }
        }
    }

    // Tutorial code was referanced from https://youtu.be/vRKrg9Ku8Aw?si=ppcqxembEk9X8NYg
}

