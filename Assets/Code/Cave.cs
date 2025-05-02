using UnityEngine;
using UnityEngine.SceneManagement;

public class Cave : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
//referanced from here https://www.youtube.com/watch?v=-TXEchDnVI0