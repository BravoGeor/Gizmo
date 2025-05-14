using UnityEngine;

public class BridgeCreak : MonoBehaviour
{
    public AudioSource creakAudio;          
    public float movementThreshold = 0.1f;  // Speed to count as "walking"
    public float minPitch = 0.95f;
    public float maxPitch = 1.05f;
    public float minCreakInterval = 0.5f;
    public float maxCreakInterval = 1.5f;

    private bool playerOnBridge = false;
    private Transform player;
    private Vector3 lastPosition;
    private float creakTimer = 0f;
    private float nextCreakTime = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBridge = true;
            player = other.transform;
            lastPosition = player.position;
            SetNextCreakTime();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBridge = false;
            player = null;
            creakAudio.Stop();
        }
    }

    void Update()
    {
        if (playerOnBridge && player != null)
        {
            float movementSpeed = (player.position - lastPosition).magnitude / Time.deltaTime;

            if (movementSpeed > movementThreshold)
            {
                creakTimer += Time.deltaTime;
                if (creakTimer >= nextCreakTime)
                {
                    PlayCreak();
                    SetNextCreakTime();
                    creakTimer = 0f;
                }
            }
            else
            {
                creakTimer = 0f; // Reset if player stops
            }

            lastPosition = player.position;
        }
    }

    void PlayCreak()
    {
        creakAudio.pitch = Random.Range(minPitch, maxPitch);
        creakAudio.PlayOneShot(creakAudio.clip);
    }

    void SetNextCreakTime()
    {
        nextCreakTime = Random.Range(minCreakInterval, maxCreakInterval);
    }
}
