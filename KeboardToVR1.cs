using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardToVR : MonoBehaviour
{
    public Button vrInteractButton; // Assign in Inspector

    void Start()
    {
        // Ensure the button is assigned
        if (vrInteractButton != null)
        {
            vrInteractButton.onClick.AddListener(SimulateEKeyPress);
        }
    }

    public void SimulateEKeyPress()
    {
        StartCoroutine(SimulateKeyPress());
    }

    IEnumerator SimulateKeyPress()
    {
        yield return null; // Wait a frame
        Input.GetKeyDown(KeyCode.E);
    }
}
