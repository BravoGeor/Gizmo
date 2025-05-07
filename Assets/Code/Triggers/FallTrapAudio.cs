using UnityEngine;

public class FallTrapAudio : MonoBehaviour
{
   
    public GameObject audioSourceObject;
    public AudioClip collisionClip;

    private AudioSource externalAudioSource;

    void Start()
    {
        if (audioSourceObject != null)
        {
            externalAudioSource = audioSourceObject.GetComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && externalAudioSource != null && collisionClip != null)
        {
            externalAudioSource.PlayOneShot(collisionClip);
        }
    }
}

//Code referanced here: https://discussions.unity.com/t/playing-audio-on-collision/161497
