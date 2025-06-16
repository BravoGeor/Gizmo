using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;

    [Header("Fade Settings")]
    public Image fadeImage;
    public float fadeOutDuration = 1f;
    public float fadeInDuration = 1f;

    private void Awake()
    {
        // Singleton pattern to persist the fader across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Fade in when the game starts (or scene is loaded)
        StartCoroutine(FadeIn());
    }

    public void FadeToNextScene()
    {
        // Get the current scene index and the next scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = (currentIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // Start the fade-out and load the next scene
        StartCoroutine(FadeOutIn(nextIndex));
    }

    private IEnumerator FadeIn()
    {
        // Fade in from black
        float time = fadeInDuration;
        Color c = fadeImage.color;
        fadeImage.raycastTarget = true; // Optional: block input during fade

        while (time > 0)
        {
            time -= Time.deltaTime;
            c.a = time / fadeInDuration;
            fadeImage.color = c;
            yield return null;
        }

        c.a = 0;
        fadeImage.color = c;
        fadeImage.raycastTarget = false; // Allow input again after fade-in
    }

    private IEnumerator FadeOutIn(int sceneIndex)
    {
        // Debug log to show when fade-out starts
        Debug.Log(" Fade Out started...");

        // Fade out to black
        float time = 0f;
        fadeImage = GameObject.Find("FadeImage").GetComponent<Image>();
        Color c = fadeImage.color;
        fadeImage.raycastTarget = true; // Block input during fade-out

        while (time < fadeOutDuration)
        {
            time += Time.deltaTime;
            c.a = time / fadeOutDuration;
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1;
        fadeImage.color = c;

        // Load the next scene
        SceneManager.LoadScene(sceneIndex);
        yield return null;

        // Fade back in after scene is loaded
        StartCoroutine(FadeIn());
    }
}
