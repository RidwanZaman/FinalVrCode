using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SceneTransitionText : MonoBehaviour
{
    public TMP_Text transitionText;
    public Image blackBackground; // The black panel image
    public GameObject questPanel; // Your Quest panel GameObject
    public GameObject dataPanel;  // Your Data panel GameObject

    void Start()
    {
        StartCoroutine(ShowTransitionText());
    }

    IEnumerator ShowTransitionText()
    {
        // Hide Quest & Data Panels
        questPanel.SetActive(false);
        dataPanel.SetActive(false);

        // Activate black background and initial text
        blackBackground.gameObject.SetActive(true);
        blackBackground.color = new Color(0, 0, 0, 1); // Full black
        transitionText.gameObject.SetActive(true);

        // First message
        transitionText.text = "This is the alternate version of the ocean when climate change takes effect…";

        yield return new WaitForSeconds(4f);

        // Second message
        transitionText.text = "The water is murky due to the loss of plankton, disrupting the ecosystem.";

        yield return new WaitForSeconds(4f);

        // Hide transition elements
        blackBackground.gameObject.SetActive(false);
        transitionText.gameObject.SetActive(false);

        // Optionally, bring Quest & Data panels back (if needed later)
        questPanel.SetActive(true);
        dataPanel.SetActive(true);
    }
}
