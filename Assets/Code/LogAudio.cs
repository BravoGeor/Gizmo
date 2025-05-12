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

    void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;

        if (collided.CompareTag("Player"))
        {
            hitPlayerAudioObject.GetComponent<AudioSource>().Play();
        }
        else if (collided == targetObject)
        {
            Debug.Log($"Hit target: is looping {isLooping} loop ended {loopEnded}");
            hitTreeAudioObject.GetComponent<AudioSource>().Play();
            if (isLooping && !loopEnded)
            {
                Debug.Log("Stop loop");
                loopSource.Stop();
                loopEnded = true;
            }
        }
        // Check against ground layer
        else if (collided.layer == groundLayer)
        {
            groundAudioObject.GetComponent<AudioSource>().Play();
            if (!isLooping)
            {
                Debug.Log("Looping sound");
                loopSource.Play();
                isLooping = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        loopSource.Stop();
        loopEnded = true;
        isLooping = false;
    }
}