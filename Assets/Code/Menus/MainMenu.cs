using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }

    public void QuitGame ()
    {
        Debug.Log("QuitEnabled");
        Application.Quit();
    }
}
//Referanced Code https://youtu.be/zc8ac_qUXQY?si=S9OVOwa9kGSQgApV