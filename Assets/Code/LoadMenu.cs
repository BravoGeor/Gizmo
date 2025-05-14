using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LoadMenu : MonoBehaviour
{
    public GameObject myText; 


    IEnumerator Start()
    {
        yield return new WaitForSeconds(0);
        myText.SetActive(true); // Enable the text so it shows
        yield return new WaitForSeconds(5);
        myText.SetActive(false); // Disable the text so it is hidden
    }
}
