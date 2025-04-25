using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TerrainToggleUI : MonoBehaviour
{
    public Toggle treeToggle;

    void Start()
    {
        // Load the saved toggle state from PlayerPrefs
        bool treesState = PlayerPrefs.GetInt("TreesVisible", 1) == 1; // Default to 1 (true)

        // If the Toggle is not null
        if (treeToggle != null)
        {
            treeToggle.isOn = treesState;

            // Add listener for when the toggle changes
            treeToggle.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    // This method is called when the toggle value changes
    void OnToggleChanged(bool showTrees)
    {
        // Save the toggle state to PlayerPrefs (1 = true, 0 = false)
        PlayerPrefs.SetInt("TreesVisible", showTrees ? 1 : 0);
    }
}