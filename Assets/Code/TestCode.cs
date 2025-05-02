using UnityEngine;

public class AudioEventFromGameObjects : MonoBehaviour
{
    [Header("Audio Source GameObjects")]
    public GameObject triggerAudioObject;   // 1: Trigger zone sound
    public GameObject groundAudioObject;    // 2: Hits ground
    public GameObject loopAudioObject;      // 3: Loops until collision
    public GameObject hitPlayerAudioObject; // 4: Hits player
    public GameObject hitTargetAudioObject; // 5: Hits specific object

    [Header("Target References")]
    public GameObject triggerZone;          // The trigger collider object
    public GameObject targetObject;         // The specific object for condition B

    private AudioSource loopSource;
    private bool isLooping = false;
    private bool loopEnded = false;

    void Start()
    {
        loopSource = loopAudioObject.GetComponent<AudioSource>();
        loopSource.loop = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // Player enters specified trigger
        if (other.CompareTag("Player") && other.gameObject == triggerZone)
        {
            triggerAudioObject.GetComponent<AudioSource>().Play();

            if (!isLooping)
            {
                loopSource.Play();
                isLooping = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundAudioObject.GetComponent<AudioSource>().Play();
        }

        if (isLooping && !loopEnded)
        {
            loopSource.Stop();
            loopEnded = true;

            if (collision.gameObject.CompareTag("Player"))
            {
                hitPlayerAudioObject.GetComponent<AudioSource>().Play();
            }
            else if (collision.gameObject == targetObject)
            {
                hitTargetAudioObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
