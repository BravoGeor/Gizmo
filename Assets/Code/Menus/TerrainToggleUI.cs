using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TerrainToggleUI : MonoBehaviour
{
    public Toggle treeToggle;

    IEnumerator Start()
    {
        yield return new WaitUntil(() => ToggleTreePrefabs.Instance != null);

        treeToggle.isOn = ToggleTreePrefabs.Instance.AreTreesVisible();
        treeToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool showTrees)
    {
        if (ToggleTreePrefabs.Instance != null)
        {
            ToggleTreePrefabs.Instance.SetTreesVisible(showTrees);
        }
    }
}
