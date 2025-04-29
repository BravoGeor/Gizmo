using UnityEngine;
using Cinemachine;

public class CameraZone : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;
    public int activePriority = 20;
    public int inactivePriority = 5;

    private bool playerInside = false;

    private void Awake()
    {
        // Get the CinemachineFreeLook camera in this zone
        freeLookCamera = GetComponentInChildren<CinemachineFreeLook>();
        if (freeLookCamera == null)
        {
            Debug.LogError("No CinemachineFreeLook camera found in the zone: " + name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerInside && freeLookCamera != null)
            {
                freeLookCamera.Priority = activePriority;
                playerInside = true;
                Debug.Log("Player entered zone: " + name + ". FreeLook Camera Priority set to " + activePriority);
            }
            else if (playerInside && freeLookCamera != null)
            {
                // Optional: Add a check for priority mismatches
                if (freeLookCamera.Priority != activePriority)
                {
                    Debug.LogWarning("Priority mismatch in zone: " + name);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && freeLookCamera != null)
        {
            freeLookCamera.Priority = inactivePriority;
            playerInside = false;
            Debug.Log("Player exited zone: " + name + ". FreeLook Camera Priority set to " + inactivePriority);
        }
    }
}
