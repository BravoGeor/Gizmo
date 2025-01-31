using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("QuitEnabled");
        Application.Quit();
    }
}
//Referanced Code https://youtu.be/zc8ac_qUXQY?si=S9OVOwa9kGSQgApV