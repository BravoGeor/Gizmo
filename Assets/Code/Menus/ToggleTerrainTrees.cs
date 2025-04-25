using UnityEngine;

public class ToggleTreePrefabs : MonoBehaviour
{
    public static ToggleTreePrefabs Instance { get; private set; }

    public GameObject[] treeGroups; // groups or individual tree objects

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // optional
    }

    public void SetTreesVisible(bool visible)
    {
        foreach (GameObject treeGroup in treeGroups)
        {
            if (treeGroup != null)
                treeGroup.SetActive(visible);
        }
    }

    public bool AreTreesVisible()
    {
        return treeGroups.Length > 0 && treeGroups[0].activeSelf;
    }
}
