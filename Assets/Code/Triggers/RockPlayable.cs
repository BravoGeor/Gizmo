using System.Collections;
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
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(4);
        director.time = 0;
        director.Evaluate();
    }
}