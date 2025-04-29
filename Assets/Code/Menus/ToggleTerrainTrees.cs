using UnityEngine;

public class ToggleTerrainTrees : MonoBehaviour
{
    public Terrain[] treeGroups; // groups or individual tree objects

    void Awake()
    {
        bool treesState = PlayerPrefs.GetInt("TreesVisible", 1) == 1; // Default to 1 (true)
        SetTreesVisible(treesState);
    }

    public void SetTreesVisible(bool visible)
    {
        foreach (Terrain treeGroup in treeGroups)
        {
            if (treeGroup != null)
                treeGroup.drawTreesAndFoliage = visible;
        }
    }
}