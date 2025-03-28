using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    public GameObject speechBubbleCanvas; // The entire speech UI
    public TextMeshProUGUI speechText; // The text element

    void Start()
    {
        if (speechBubbleCanvas != null)
        {
            speechBubbleCanvas.SetActive(false); // Hide it at the start
        }
    }

    public void ShowSpeech(string message)
    {
        if (speechBubbleCanvas != null && speechText != null)
        {
            speechText.text = message;
            speechBubbleCanvas.SetActive(true); // Show speech bubble
            Invoke("HideSpeech", 3f); // Hide after 3 seconds
        }
        else
        {
            Debug.LogError("SpeechBubble references are missing!");
        }
    }

    void HideSpeech()
    {
        if (speechBubbleCanvas != null)
        {
            speechBubbleCanvas.SetActive(false); // Hide speech bubble
        }
    }
}
