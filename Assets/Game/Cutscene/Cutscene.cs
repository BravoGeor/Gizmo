using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false;
    }

    // This method will be called at the end of the animation
    public void OnAnimationEnd()
    {
        // Replace "NextSceneName" with the name of your next scene
        SceneManager.LoadScene("Game");
    }
}
