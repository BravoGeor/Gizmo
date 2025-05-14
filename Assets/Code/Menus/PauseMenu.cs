using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject Loading;
    public GameObject pauseMenuUI;
    public bool loadingActive = false;

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Loading.activeSelf)
        {
            loadingActive = false;
        }
        else
        {
            loadingActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (loadingActive == false)
            {
                if (GameIsPaused)
                {
                    Resume();

                }
                else
                {
                    Pause();
                }
            }
          

        }
    }

     public void Resume () 
    { 
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Debug.Log("resumeNotWorking");
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Pause");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}

//Referanced code https://youtu.be/JivuXdrIHK0?si=9dbST9WwK4zupKlK
