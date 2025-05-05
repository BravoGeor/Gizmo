using UnityEngine;

public class LogAudio : MonoBehaviour
{
    [Header("Log Audios")]
    public GameObject groundAudioObject;
    public GameObject loopAudioObject;
    public GameObject hitPlayerAudioObject;
    public GameObject hitTreeAudioObject;

    [Header("Zones")]
    public GameObject triggerZone;
    public GameObject targetObject;

    [Header("Ground Layer")]
    public string groundLayerName = "Ground";

    private int groundLayer;
    private AudioSource loopSource;
    private bool isLooping = false;
    private bool loopEnded = false;

    void Start()
    {
        loopSource = loopAudioObject.GetComponent<AudioSource>();
        loopSource.loop = true;

        // Convert layer name to layer index
        groundLayer = LayerMask.NameToLayer(groundLayerName);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject == triggerZone)
        {
            //triggerAudioObject.GetComponent<AudioSource>().Play();

            if (!isLooping)
            {
                loopSource.Play();
                isLooping = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;

        // Check against ground layer
        if (collided.layer == groundLayer)
        {
            groundAudioObject.GetComponent<AudioSource>().Play();
        }

        if (isLooping && !loopEnded)
        {
            loopSource.Stop();
            loopEnded = true;

            if (collided.CompareTag("Player"))
            {
                hitPlayerAudioObject.GetComponent<AudioSource>().Play();
            }
            else if (collided == targetObject)
            {
                hitTreeAudioObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}