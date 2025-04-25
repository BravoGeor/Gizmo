using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTerrainScene : MonoBehaviour
{
    void Start()
    {
        // Keep this object alive across scenes
        DontDestroyOnLoad(gameObject);

        // Load the terrain scene additively
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }
}