using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainGameFader : MonoBehaviour
{
    public static MainGameFader Instance;

    [Header("Fade Settings")]
    public Image fadeImage;
    public float fadeOutDuration = 1f;
    public float fadeInDuration = 1f;

    [Header("Fade Timing")]
    public float fadeInDelay = 0f; // Time to wait before starting fade-in

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

        // Ensure fadeImage is assigned
        if (fadeImage == null)
        {
            Debug.LogError("SceneFader: fadeImage is not assigned in the Inspector!");
        }
    }

    private void Start()
    {
        // Fade in when the game starts (or scene is loaded)
        StartCoroutine(FadeIn());
    }

    public void FadeToNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = (currentIndex + 1) % SceneManager.sceneCountInBuildSettings;
        StartCoroutine(FadeOutIn(nextIndex));
    }

    public void FadeToScene(int sceneIndex)
    {
        StartCoroutine(FadeOutIn(sceneIndex));
    }

    private IEnumerator FadeIn()
    {
        // Optional delay before fade starts
        if (fadeInDelay > 0f)
            yield return new WaitForSeconds(fadeInDelay);

        float time = fadeInDuration;
        Color c = fadeImage.color;
        fadeImage.raycastTarget = true; // Block input during fade

        while (time > 0)
        {
            time -= Time.deltaTime;
            c.a = time / fadeInDuration;
            fadeImage.color = c;
            yield return null;
        }

        c.a = 0;
        fadeImage.color = c;
        fadeImage.raycastTarget = false; // Allow input again
    }

    private IEnumerator FadeOutIn(int sceneIndex)
    {
        Debug.Log("Fade Out started...");

        float time = 0f;
        Color c = fadeImage.color;
        fadeImage.raycastTarget = true; // Block input during fade

        while (time < fadeOutDuration)
        {
            time += Time.deltaTime;
            c.a = time / fadeOutDuration;
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1;
        fadeImage.color = c;

        // Load new scene and wait a frame before fading in
        SceneManager.LoadScene(sceneIndex);
        yield return null;

        StartCoroutine(FadeIn());
    }
}
