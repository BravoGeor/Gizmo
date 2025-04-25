using UnityEngine;

public class ToggleTreePrefabs : MonoBehaviour
{
    public GameObject[] treeGroups; // groups or individual tree objects

    void Awake()
    {
        bool treesState = PlayerPrefs.GetInt("TreesVisible", 1) == 1; // Default to 1 (true)
        SetTreesVisible(treesState);
    }

    public void SetTreesVisible(bool visible)
    {
        foreach (GameObject treeGroup in treeGroups)
        {
            if (treeGroup != null)
                treeGroup.SetActive(visible);
        }
    }
}