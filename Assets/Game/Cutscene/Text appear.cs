using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class CanvasScript : MonoBehaviour
{
    public GameObject myText; // Assign the text to this in the inspector


    IEnumerator Start()
    {
        yield return new WaitForSeconds(16);
        myText.SetActive(true); // Enable the text so it shows
        yield return new WaitForSeconds(5);
        myText.SetActive(false); // Disable the text so it is hidden
    }
}