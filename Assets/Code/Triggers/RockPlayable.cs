using UnityEngine;
using UnityEngine.Playables;

public class Rockplayable : MonoBehaviour
{
    public PlayableDirector director;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            director.Play();
        }
    }
}